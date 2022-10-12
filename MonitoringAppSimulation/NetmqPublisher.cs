using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetMQ;
using NetMQ.Sockets;
using System.Collections.Concurrent;
using System.Threading;

namespace MonitoringAppSimulation
{
    public struct IpcMsg
    {
        public IpcMsg(string topic, byte[] body)
        {
            Topic = topic;
            Data = body;
        }

        public string Topic { get; }
        public byte[] Data { get; }

        public override string ToString() => $"({Topic})";
    }

    sealed class NetmqPublisher
    {
        private static PublisherSocket pubSocket = null;
        private bool running = true;

        private static ConcurrentQueue<IpcMsg> sendingQueue;

        private Thread dequeThread;
        private string pubAddress = "tcp://*:12345";
        private string pubTopic = "VehicleCommand";

        public void Initialize()
        {
            sendingQueue = new ConcurrentQueue<IpcMsg>();
            pubSocket = new PublisherSocket();
            dequeThread = new Thread(new ThreadStart(dequeueMsg));
        }

        public void publishOnce(string argTopic, string argAddress, byte[] array)
        {
            using (var pubOnceSock = new PublisherSocket())
            {
                if (argTopic == null)
                {
                    Console.WriteLine("argTopic is null!");
                    return;
                }

                if (argAddress == null)
                {
                    Console.WriteLine("argAddress is null!");
                    return;
                }

                if (pubOnceSock != null)
                {
                    Console.WriteLine("Publisher socket binding...");
                    pubOnceSock.Options.SendHighWatermark = 1000;
                    pubOnceSock.Bind(argAddress);
                    Thread.Sleep(500);
                    pubOnceSock.SendMoreFrame(argTopic).SendFrame(array);
                    Thread.Sleep(500);
                    //pubSocket.Disconnect(pubAddress);
                    //pubSocket.Close();
                }
                else
                {
                    Console.WriteLine("publish socket instance is null");
                }
            }
        }

        public void Run(string argTopic, string argAddress)
        {
            Initialize();
            running = true;

            if (argTopic != null)
            {
                pubTopic = argTopic;
            }

            if (argAddress != null)
            {
                pubAddress = argAddress;
            }

            //using (var pubSocket = new PublisherSocket())

            if (pubSocket != null)
            {
                Console.WriteLine("Publisher socket binding...");
                pubSocket.Options.SendHighWatermark = 1000;
                pubSocket.Bind(pubAddress);//NetMQ.AddressAlreadyInUseException
            }
            dequeThread.Start();
        }
        public void Stop()
        {
            if (running)
            {
                running = false;
                bool res = false;
                try
                {
                    dequeThread.Interrupt();
                    res = dequeThread.Join(100);
                }
                catch (ThreadStateException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("join thread exception occured!");
                }

                try
                {
                    pubSocket.Disconnect(pubAddress);
                    pubSocket.Close();
                }
                catch (NetMQ.EndpointNotFoundException e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("subscribe socket disconnect exception occured");
                    return;
                }

            }
        }

        public void dequeueMsg()
        {
            while ((running == true) && (sendingQueue != null))
            {
                IpcMsg msg;

                if (sendingQueue.TryDequeue(out msg))
                {
                    pubSocket.SendMoreFrame(msg.Topic).SendFrame(msg.Data);
                }

                try
                {
                    Thread.Sleep(500);
                }
                catch (System.Threading.ThreadInterruptedException e)
                {
                    Console.WriteLine("NetmqPublisher dequeMsg error: "+ System.Environment.NewLine + e);
                }
            }
        }

        public void PublishMsg(string topic, byte[] array)
        {
            //pubSocket.SendMoreFrame(topic).SendFrame(array);
            pubTopic = topic;
            if (sendingQueue != null)
            {
                var msg = new IpcMsg(topic, array);

                sendingQueue.Enqueue(msg);
            }
        }
    }
}
