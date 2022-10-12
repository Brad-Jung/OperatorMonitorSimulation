using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NetMQ;
using NetMQ.Sockets;
using System.IO;
using ProtoBuf;

namespace MonitoringAppSimulation
{
    class NetmqPoller
    {
        public static IList<string> allowableCommandLineArgs
            = new[] { "Vehicle", "All" };
        String topic;
        string address;
        public bool running = false;

        public void Run(string argTopic, string argAddress = "tcp://localhost:12345")
        {
            if (!allowableCommandLineArgs.Contains(argTopic))
            {
                Console.WriteLine("Expected one argument, either " +
                                  "'TopicA', 'TopicB' or 'All'");
                Environment.Exit(-1);
            }
            topic = argTopic == "All" ? "" : argTopic;
            address = argAddress;

            Console.WriteLine("Subscriber started for Topic : {0}", topic);

            running = true;
            subscribeTopic();
            //recvThread = new Thread(new ThreadStart(subscribeTopic));
            //recvThread.Start();
        }

        public void Stop()
        {
            //running = false;
            //recvThread.Join();
            //subSocket.Unsubscribe(topic);
            //subSocket.Disconnect(address);
            //subSocket.Close();
        }

        void subscribeTopic()
        {
            //while (running)
            {
                // using poller.(response socket)
                using (var rep1 = new ResponseSocket(address))
                using (var poller = new NetMQPoller { rep1 })
                {
                    rep1.ReceiveReady += (s, a) =>
                    {
                        string msg = a.Socket.ReceiveFrameString();
                        //a.Socket.Send
                        byte[] bytes = a.Socket.ReceiveFrameBytes();

                        Console.WriteLine(msg + " , bytes = " + bytes.Length);
                    };
                }
            }
        }
    }
}
