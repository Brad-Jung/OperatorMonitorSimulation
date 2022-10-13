using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetMQ;
using NetMQ.Sockets;
using System.IO;
using ProtoBuf;
using System.Threading;
using System.Windows.Forms;
using Aro.Message;

namespace MonitoringAppSimulation
{
    sealed class NetmqSubscriber
    {
        public static IList<string> allowableCommandLineArgs
            = new[] { "Vehicle", "All" };

        private string topic;
        private string address;
        private bool running = false;
        private SubscriberSocket subSocket;
        private string  recvMsg;
        public event Action<VehicleCANData> OnDataReceived;

        public void Run(string argTopic, string argAddress)
        {
            if (!allowableCommandLineArgs.Contains(argTopic))
            {
                Console.WriteLine("Expected one argument, either " +
                                  "'TopicA', 'TopicB' or 'All'");
                Environment.Exit(-1);
            }
            topic = argTopic == "All" ? "" : argTopic;
            address = argAddress;
            recvMsg = "";

            Console.WriteLine("Subscriber started for Topic : {0}", topic);

            running = true;
            subscribeTopic();
        }

        public void Stop()
        {
            if (running && subSocket != null)
            {
                try
                {
                    subSocket.Unsubscribe(topic);
                    subSocket.Disconnect(address);
                    subSocket.Close();
                    subSocket = null;
                } 
                catch (NetMQ.EndpointNotFoundException e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("subscribe socket disconnect exception occured");
                    running = false;
                    return;
                }

            }

            running = false;
        }

        private void subscribeTopic()
        {
            subSocket = new SubscriberSocket();

            subSocket.Options.ReceiveHighWatermark = 1000;
            subSocket.Connect(address);
            subSocket.Subscribe(topic);
            Console.WriteLine("Subscriber socket connecting...");

            recvMsg = "";

            string messageTopicReceived;
            VehicleCANData recvData;

            try
            {
                messageTopicReceived = subSocket.ReceiveFrameString();
            }
            catch(System.Net.Sockets.SocketException e)
            {
                Console.WriteLine(e);
                Console.WriteLine("socket is already disconnected by other thread.");
                return;
            }

            byte[] bytes = subSocket.ReceiveFrameBytes();
            recvMsg = messageTopicReceived + " , bytes = " + bytes.Length.ToString();
            recvMsg += System.Environment.NewLine;

            Console.WriteLine(messageTopicReceived + " , bytes = " + bytes.Length);
            using (var memoryStream = new MemoryStream(bytes))
            {
                var message = Serializer.Deserialize<VehicleCANData>(memoryStream);
                recvData = message;
                // do something with the message
                Console.WriteLine($"Subscriber Received {message.VehicleSpeed} ");
                recvMsg += "Subscriber Received: " + System.Environment.NewLine; 
                recvMsg += "VehicleSpeed: " + message.VehicleSpeed.ToString() + System.Environment.NewLine;
                recvMsg += "GearMode: " + message.GearMode.ToString() + System.Environment.NewLine;
                recvMsg += "DrivingReady: " + message.DrivingReady.ToString() + System.Environment.NewLine;
                recvMsg += "DrivingHour: " + message.DrivingHour.ToString() + System.Environment.NewLine;
                //MessageBox.Show(recvMsg);
            }
            
            subSocket.Unsubscribe(topic);
            subSocket.Disconnect(address);
            subSocket.Close();
            subSocket = null;

            OnDataReceived(recvData);
        }

    }
}
