using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using NetMQ;
using Aro.Message;

namespace MonitoringAppSimulation
{
    public partial class Form1 : Form
    {
        private bool running = false;
        private Thread subscribeThread;
        private String address = "tcp://localhost:12347";
        private String topic = "All";
        private NetmqSubscriber subscriber;
        private VehicleCommandDataStatus vehicleCommandDataStatus;
        private int msgCount = 0;

        private string publishAddress = "tcp://*:12345";
        private string publishTopic = "VehicleCommand";

        private bool tailLampOn = false;
        private bool fogLampOn = false;
        private bool downLampOn = false;
        private bool upperLampOn = false;
        private bool turnLeftLampOn = false;
        private bool turnRightLampOn = false;
        private bool autoDrivingOn = false;

        private Bitmap tailLampImage;
        private Bitmap fogLampImage;
        private Bitmap downLampImage;
        private Bitmap upperLampImage;
        private Bitmap turnLeftImage;
        private Bitmap turnRightImage;

        private Bitmap tailLampImageOff;
        private Bitmap fogLampImageOff;
        private Bitmap downLampImageOff;
        private Bitmap upperLampImageOff;
        private Bitmap turnLeftImageOff;
        private Bitmap turnRightImageOff;

        private Bitmap carIconAutoDrivingMode;
        private Bitmap carIconManualDrivingMode;
        private Bitmap carIconDrivingMode;
        private Bitmap carIconBackGround;

        public Form1()
        {
            InitializeComponent();

            this.FormClosed += OnAppClosed;
            this.Text = "Monitoring App Simulation";
            this.Paint += new PaintEventHandler(this.Form1_Paint);
            this.MouseMove += new MouseEventHandler(this.Form1_MouseMove);

            vehicleCommandDataStatus = new VehicleCommandDataStatus();

            tailLampImage = new Bitmap(Properties.Resources.tail_lamp);
            fogLampImage = new Bitmap(Properties.Resources.fog_lamp);
            downLampImage = new Bitmap(Properties.Resources.down_lamp);
            upperLampImage = new Bitmap(Properties.Resources.upper_lamp);
            turnLeftImage = new Bitmap(Properties.Resources.turn_left_signal);
            turnRightImage = new Bitmap(Properties.Resources.turn_right_signal);

            tailLampImageOff = new Bitmap(Properties.Resources.tail_lamp_off);
            fogLampImageOff = new Bitmap(Properties.Resources.fog_lamp_off);
            downLampImageOff = new Bitmap(Properties.Resources.down_lamp_off);
            upperLampImageOff = new Bitmap(Properties.Resources.upper_lamp_off);
            turnLeftImageOff = new Bitmap(Properties.Resources.turn_left_signal_off);
            turnRightImageOff = new Bitmap(Properties.Resources.turn_right_signal_off);

            carIconAutoDrivingMode = new Bitmap(Properties.Resources.auto_driving_mode_car);
            carIconManualDrivingMode = new Bitmap(Properties.Resources.manual_driving_mode_car);
            carIconDrivingMode = carIconManualDrivingMode;
            carIconBackGround = new Bitmap(Properties.Resources.auto_driving_mode_car_off);
            carIconBackGround.SetResolution(120, 115);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (tailLampOn)
                e.Graphics.DrawImage(tailLampImage, tailLampLabel.Location.X, tailLampLabel.Location.Y + tailLampLabel.ClientSize.Height + 3);
            else
                e.Graphics.DrawImage(tailLampImageOff, tailLampLabel.Location.X, tailLampLabel.Location.Y + tailLampLabel.ClientSize.Height + 3);

            if (fogLampOn)
                e.Graphics.DrawImage(fogLampImage, fogLampLabel.Location.X, fogLampLabel.Location.Y + fogLampLabel.ClientSize.Height + 3);
            else
                e.Graphics.DrawImage(fogLampImageOff, fogLampLabel.Location.X, fogLampLabel.Location.Y + fogLampLabel.ClientSize.Height + 3);

            if (downLampOn)
                e.Graphics.DrawImage(downLampImage, downLampLabel.Location.X, downLampLabel.Location.Y + downLampLabel.ClientSize.Height + 3);
            else
                e.Graphics.DrawImage(downLampImageOff, downLampLabel.Location.X, downLampLabel.Location.Y + downLampLabel.ClientSize.Height + 3);

            if (upperLampOn)
                e.Graphics.DrawImage(upperLampImage, upperLampLabel.Location.X, upperLampLabel.Location.Y + upperLampLabel.ClientSize.Height + 3);
            else
                e.Graphics.DrawImage(upperLampImageOff, upperLampLabel.Location.X, upperLampLabel.Location.Y + upperLampLabel.ClientSize.Height + 3);

            if (turnLeftLampOn)
                e.Graphics.DrawImage(turnLeftImage, turnLeftSignalLabel.Location.X+25, turnLeftSignalLabel.Location.Y + turnLeftSignalLabel.ClientSize.Height + 3);
            else
                e.Graphics.DrawImage(turnLeftImageOff, turnLeftSignalLabel.Location.X + 25, turnLeftSignalLabel.Location.Y + turnLeftSignalLabel.ClientSize.Height + 3);

            if (turnRightLampOn)
                e.Graphics.DrawImage(turnRightImage, turnRightSignalLabel.Location.X+25, turnRightSignalLabel.Location.Y + turnRightSignalLabel.ClientSize.Height + 3);
            else
                e.Graphics.DrawImage(turnRightImageOff, turnRightSignalLabel.Location.X + 25, turnRightSignalLabel.Location.Y + turnRightSignalLabel.ClientSize.Height + 3);

            e.Graphics.DrawImage(carIconBackGround,
                            tailLampLabel.Location.X,
                            turnLeftSignalLabel.Location.Y + turnLeftSignalLabel.ClientSize.Height + turnLeftImage.Height + 10);

            if (autoDrivingOn)
                e.Graphics.DrawImage(carIconAutoDrivingMode,
                            tailLampLabel.Location.X,
                            turnLeftSignalLabel.Location.Y + turnLeftSignalLabel.ClientSize.Height + turnLeftImage.Height + 10);
            else
                e.Graphics.DrawImage(carIconManualDrivingMode ,
                            tailLampLabel.Location.X,
                            turnLeftSignalLabel.Location.Y + turnLeftSignalLabel.ClientSize.Height + turnLeftImage.Height + 10);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            pointCoordinate.Text = "(" + e.X + "," + e.Y + ")";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        void StartSubscribe()
        {
            running = true;

            initializeListView();
            subscribeThread = new Thread(new ThreadStart(SubscribeThread));
            subscribeThread.Start();
        }

        void StopSubscribe()
        {
            bool res = false;
            if (running)
            {
                running = false;
                subscriber.Stop();
                listView1.Clear();

                try
                {
                    subscribeThread.Interrupt();
                    res = subscribeThread.Join(300);
                }
                catch (ThreadStateException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("join thread exception occured!");
                }

                Console.WriteLine("res: " + res.ToString());
            }
        }

        void SubscribeThread()
        {

            Console.WriteLine("Thread#{0}: Begin", Thread.CurrentThread.ManagedThreadId);
            // Do Something

            msgCount = 0;

            subscriber = new NetmqSubscriber();

            subscriber.OnDataReceived += (msg) => Invoke(
                new Action(() => OnMQMsgUpdated(msg)));

            while (running)
            {
                msgCount++;
                subscriber.Run(topic, address);
                
                try
                {
                    Thread.Sleep(300);
                }
                catch (System.Threading.ThreadInterruptedException e)
                {
                    Console.WriteLine("thread interrupted Exception occured");
                    Console.WriteLine(e);
                    break;
                }
                subscriber.Stop();
            }

            Console.WriteLine("Thread#{0}: End", Thread.CurrentThread.ManagedThreadId);
        }

        void OnAppClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("앱을 종료합니다.");
            StopSubscribe();
            System.Windows.Forms.Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnIPInput.Enabled = true;
            btnTopicInput.Enabled = true;
            btnSubscribe.Enabled = true;
            btnUnsubscribe.Enabled = false;

            batteryGage.Style = ProgressBarStyle.Continuous;
            batteryGage.Minimum = 0;
            batteryGage.Maximum = 100;
            batteryGage.Step = 1;
            batteryGage.Value = 0;

            //Program.cbMainForm("Form1_Load!");
        }

        private void OnBtnSubscribeClick(object sender, EventArgs e)
        {
            txtRx.Text = "NetMQ 메시지 수신 시작!";
            btnIPInput.Enabled = false;
            btnTopicInput.Enabled = false;
            btnSubscribe.Enabled = false;
            btnUnsubscribe.Enabled = true;

            textIPInput.Enabled = false;
            textTopicInput.Enabled = false;
            
            StartSubscribe();
        }

        private void OnBtnUnsubscribeClick(object sender, EventArgs e)
        {
            txtRx.Text = "NetMQ 메시지 수신 종료!";
            StopSubscribe();
            btnIPInput.Enabled = true;
            btnTopicInput.Enabled = true;
            btnSubscribe.Enabled = true;
            btnUnsubscribe.Enabled = false;

            textIPInput.Enabled = true;
            textTopicInput.Enabled = true;
        }

        private void OnIPBtnClicked(object sender, EventArgs e)
        {
            address = textIPInput.Text;
            txtRx.Text = "입력된 Subscribe IP 주소: " + address;
        }

        private void OnTopicBtnClicked(object sender, EventArgs e)
        {
            topic = textTopicInput.Text;
            txtRx.Text = "입력된 Subscribe Topic : " + topic;
        }

        public void initializeListView()
        {
            listView1.BeginUpdate();

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Sorting = SortOrder.None;//SortOrder.Descending; //SortOrder.Ascending;

            listView1.Columns.Clear();
            listView1.Columns.Add("n", 30);
            listView1.Columns.Add("key", 120);
            listView1.Columns.Add("value", 120);

            listView1.EndUpdate();
        }

        public void OnMQMsgUpdated(object data)//(string msg)
        {
            VehicleCANData vcd = (VehicleCANData)data;

            listView1.BeginUpdate();

            UpdateCanDataListView(data);

            UpdateBatteryGage(vcd.BatteryRemains);
            UpdateDrivingDistance(vcd.DrivingDistance);
            UpdateDrivingTime(vcd.DrivingHour, vcd.DrivingMinutes);
            //UpdateTotalDrivingDistance(vcd.)//현재 정의되지 않은 데이터
            UpdateBatteryChargingStatus(vcd.BatteryCharing);
            UpdateLamps(vcd);
            UpdateDrivingMode(vcd.DrivingMode);
            UpdateAvailableDistance(vcd.AvailableDistance);

            listView1.Items[listView1.Items.Count - 1].EnsureVisible();

            listView1.EndUpdate();
        }

        public void UpdateCanDataListView(object data)
        {
            VehicleCANData vcd = (VehicleCANData)data;

            listView1.Items.Clear();

            ListViewItem item;
            item = new ListViewItem(msgCount.ToString());
            item.SubItems.Add("VehicleSpeed");
            item.SubItems.Add(vcd.VehicleSpeed.ToString());
            listView1.Items.Add(item);

            item = new ListViewItem(msgCount.ToString());
            item.SubItems.Add("GearMode");
            item.SubItems.Add(vcd.GearMode.ToString());
            listView1.Items.Add(item);

            item = new ListViewItem(msgCount.ToString());
            item.SubItems.Add("DrivingReady");
            item.SubItems.Add(vcd.DrivingReady.ToString());
            listView1.Items.Add(item);

            item = new ListViewItem(msgCount.ToString());
            item.SubItems.Add("DrivingHour");
            item.SubItems.Add(vcd.DrivingHour.ToString());
            listView1.Items.Add(item);

            item = new ListViewItem(msgCount.ToString());
            item.SubItems.Add("DrivingMinutes");
            item.SubItems.Add(vcd.DrivingMinutes.ToString());
            listView1.Items.Add(item);

            item = new ListViewItem(msgCount.ToString());
            item.SubItems.Add("DrivingDistance");
            item.SubItems.Add(vcd.DrivingDistance.ToString());
            listView1.Items.Add(item);

            item = new ListViewItem(msgCount.ToString());
            item.SubItems.Add("BatteryRemains");
            item.SubItems.Add(vcd.BatteryRemains.ToString());
            listView1.Items.Add(item);

            item = new ListViewItem(msgCount.ToString());
            item.SubItems.Add("BatteryCharing");
            item.SubItems.Add(vcd.BatteryCharing.ToString());
            listView1.Items.Add(item);

            item = new ListViewItem(msgCount.ToString());
            item.SubItems.Add("AvailableDistance");
            item.SubItems.Add(vcd.AvailableDistance.ToString());
            listView1.Items.Add(item);

            item = new ListViewItem(msgCount.ToString());
            item.SubItems.Add("TailLampSignal");
            item.SubItems.Add(vcd.TailLamp.ToString());
            listView1.Items.Add(item);

            item = new ListViewItem(msgCount.ToString());
            item.SubItems.Add("DrivingMode");
            item.SubItems.Add(vcd.DrivingMode.ToString());
            listView1.Items.Add(item);
        }

        public void UpdateAvailableDistance(int distance)
        {
            availableDistanceLabel.Text = "주행가능거리: " + distance.ToString();
        }

        public void UpdateDrivingMode(DrivingModeEnum drivingMode)
        {
            if (drivingMode == DrivingModeEnum.DrivingAutonomous)
                autoDrivingOn = true;
            else
                autoDrivingOn = false;

            drawCarIcon();
        }

        public void drawCarIcon()
        {
            Graphics g = Graphics.FromHwnd(this.Handle);

            g.DrawImage(carIconBackGround,
                            tailLampLabel.Location.X,
                            turnLeftSignalLabel.Location.Y + turnLeftSignalLabel.ClientSize.Height + turnLeftImage.Height + 10);

            if (autoDrivingOn)
            {
                carIconDrivingMode = carIconAutoDrivingMode;
            }
            else
            {
                carIconDrivingMode = carIconManualDrivingMode;
            }

            g.DrawImage(carIconDrivingMode,
                            tailLampLabel.Location.X,
                            turnLeftSignalLabel.Location.Y + turnLeftSignalLabel.ClientSize.Height + turnLeftImage.Height + 10);
        }

        public void UpdateLamps(object data)
        {
            VehicleCANData vcd = (VehicleCANData)data;

            tailLampOn = (vcd.TailLamp == OnOffEnum.ModeOn) ? true : false;
            fogLampOn = (vcd.FogLamp == OnOffEnum.ModeOn) ? true : false;
            downLampOn = (vcd.HeadLampLow == OnOffEnum.ModeOn) ? true : false;
            upperLampOn = (vcd.HeadLampHigh == OnOffEnum.ModeOn) ? true : false;

            if (vcd.TurnSignalLamp == DirectionSignalEnum.DirectionNormal)
            {
                turnLeftLampOn = false;
                turnRightLampOn = false;
            } 
            else if (vcd.TurnSignalLamp == DirectionSignalEnum.DirectionLeft)
            {
                turnLeftLampOn = true;
                turnRightLampOn = false;
            }
            else if (vcd.TurnSignalLamp == DirectionSignalEnum.DirectionRight)
            {
                turnLeftLampOn = false;
                turnRightLampOn = true;
            }

            drawLampImages();
    }

        private void drawLampImages()
        {
            Graphics g = Graphics.FromHwnd(this.Handle);

            if (tailLampOn)
                g.DrawImage(tailLampImage, tailLampLabel.Location.X, tailLampLabel.Location.Y + tailLampLabel.ClientSize.Height + 3);
            else
                g.DrawImage(tailLampImageOff, tailLampLabel.Location.X, tailLampLabel.Location.Y + tailLampLabel.ClientSize.Height + 3);

            if (fogLampOn)
                g.DrawImage(fogLampImage, fogLampLabel.Location.X, fogLampLabel.Location.Y + fogLampLabel.ClientSize.Height + 3);
            else
                g.DrawImage(fogLampImageOff, fogLampLabel.Location.X, fogLampLabel.Location.Y + fogLampLabel.ClientSize.Height + 3);

            if (downLampOn)
                g.DrawImage(downLampImage, downLampLabel.Location.X, downLampLabel.Location.Y + downLampLabel.ClientSize.Height + 3);
            else
                g.DrawImage(downLampImageOff, downLampLabel.Location.X, downLampLabel.Location.Y + downLampLabel.ClientSize.Height + 3);

            if (upperLampOn)
                g.DrawImage(upperLampImage, upperLampLabel.Location.X, upperLampLabel.Location.Y + upperLampLabel.ClientSize.Height + 3);
            else
                g.DrawImage(upperLampImageOff, upperLampLabel.Location.X, upperLampLabel.Location.Y + upperLampLabel.ClientSize.Height + 3);

            if (turnLeftLampOn)
                g.DrawImage(turnLeftImage, turnLeftSignalLabel.Location.X + 25, turnLeftSignalLabel.Location.Y + turnLeftSignalLabel.ClientSize.Height + 3);
            else
                g.DrawImage(turnLeftImageOff, turnLeftSignalLabel.Location.X + 25, turnLeftSignalLabel.Location.Y + turnLeftSignalLabel.ClientSize.Height + 3);

            if (turnRightLampOn)
                g.DrawImage(turnRightImage, turnRightSignalLabel.Location.X + 25, turnRightSignalLabel.Location.Y + turnRightSignalLabel.ClientSize.Height + 3);
            else
                g.DrawImage(turnRightImageOff, turnRightSignalLabel.Location.X + 25, turnRightSignalLabel.Location.Y + turnRightSignalLabel.ClientSize.Height + 3);
        }

        public void UpdateBatteryGage(int gage)
        {
            batteryGage.Value = gage;
            batteryRemainLabel.Text = "Battery: " + gage.ToString() + "%,";
            batteryGage.PerformStep();
        }

        public void UpdateDrivingDistance(int distance)
        {
            drivingDistanceLabel.Text = distance.ToString() + "km";
        }

        public void UpdateDrivingTime(int hour, int minute)
        {
            drivingTime.Text = hour.ToString() + "h " + minute.ToString() + "m";
        }

        public void UpdateTotalDrivingDistance(int distance)
        {
            drivingDistanceLabel.Text = distance.ToString() + "km";
        }

        public void UpdateBatteryChargingStatus(OnOffEnum chargingStatus)
        {
            batChargingStatus.Text = (chargingStatus == OnOffEnum.ModeOff) ? "충전 중" : "";
        }

        private void OnPubIPBtnClicked(object sender, EventArgs e)
        {
            publishAddress = textPubIPInput.Text;
            txtRx.Text = "입력된 Publish 주소: " + publishAddress;
        }

        private void OnPubTopicBtnClicked(object sender, EventArgs e)
        {
            publishTopic = textPubTopicInput.Text;
            txtRx.Text = "입력된 Publish Topic: " + publishTopic;
        }

        public void PublishOnce(string argTopic, string argAddress, byte[] array)
        {
            NetmqPublisher publisher = new NetmqPublisher();

            publisher.publishOnce(argTopic, argAddress, array);
        }
        private void OnDoorOpenCheckedChanged(object sender, EventArgs e)
        {
            if (doorOpenToggle.Checked == false)
            {
                doorToggleLabel.Text = "문 닫힘";
                vehicleCommandDataStatus.OpenDoor(false);

                using (var memorySystem = new System.IO.MemoryStream())
                {
                    ProtoBuf.Serializer.Serialize(memorySystem, vehicleCommandDataStatus.GetVehicleCommandData());
#if DEBUG
                    //Console.WriteLine("Json: " + memorySystem.Length + " : " + JsonSerializer.Serialize(vehicleCommandData));
#endif
                    PublishOnce(publishTopic, publishAddress, memorySystem.ToArray());
                }
            }
            else
            {
                doorToggleLabel.Text = "문 열림";
                vehicleCommandDataStatus.OpenDoor(true);

                using (var memorySystem = new System.IO.MemoryStream())
                {
                    ProtoBuf.Serializer.Serialize(memorySystem, vehicleCommandDataStatus.GetVehicleCommandData());
#if DEBUG
                    //Console.WriteLine("Json: " + memorySystem.Length + " : " + JsonSerializer.Serialize(vehicleCommandData));
#endif
                    PublishOnce(publishTopic, publishAddress, memorySystem.ToArray());
                }
            }
        }

        private void OnAutoDrivingCheckedChanged(object sender, EventArgs e)
        {
            if (autoDrivingToggle.Checked == false)
            {
                autoDrivingLabel.Text = "수동 주행 모드";
                vehicleCommandDataStatus.OnAutoDrivingMode(false);

                using (var memorySystem = new System.IO.MemoryStream())
                {
                    ProtoBuf.Serializer.Serialize(memorySystem, vehicleCommandDataStatus.GetVehicleCommandData());
#if DEBUG
                    //Console.WriteLine("Json: " + memorySystem.Length + " : " + JsonSerializer.Serialize(vehicleCommandData));
#endif
                    PublishOnce(publishTopic, publishAddress, memorySystem.ToArray());
                }
            }
            else
            {
                autoDrivingLabel.Text = "자율 주행 모드";
                vehicleCommandDataStatus.OnAutoDrivingMode(true);
                using (var memorySystem = new System.IO.MemoryStream())
                {
                    ProtoBuf.Serializer.Serialize(memorySystem, vehicleCommandDataStatus.GetVehicleCommandData());
#if DEBUG
                    //Console.WriteLine("Json: " + memorySystem.Length + " : " + JsonSerializer.Serialize(vehicleCommandData));
#endif
                    PublishOnce(publishTopic, publishAddress, memorySystem.ToArray());
                }
            }
        }
    }
}
