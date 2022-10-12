
namespace MonitoringAppSimulation
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnSubscribe = new System.Windows.Forms.Button();
            this.txtRx = new System.Windows.Forms.TextBox();
            this.btnUnsubscribe = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textIPInput = new System.Windows.Forms.TextBox();
            this.textTopicInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnIPInput = new System.Windows.Forms.Button();
            this.btnTopicInput = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.key = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textPubIPInput = new System.Windows.Forms.TextBox();
            this.textPubTopicInput = new System.Windows.Forms.TextBox();
            this.btnPubIP = new System.Windows.Forms.Button();
            this.btnPubTopic = new System.Windows.Forms.Button();
            this.doorToggleLabel = new System.Windows.Forms.Label();
            this.autoDrivingLabel = new System.Windows.Forms.Label();
            this.batteryGage = new System.Windows.Forms.ProgressBar();
            this.batteryRemainLabel = new System.Windows.Forms.Label();
            this.drivingDistanceLabel = new System.Windows.Forms.Label();
            this.drivingTime = new System.Windows.Forms.Label();
            this.autoDrivingToggle = new MonitoringAppSimulation.CabinToggleButton();
            this.doorOpenToggle = new MonitoringAppSimulation.CabinToggleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.totalDrivingDistance = new System.Windows.Forms.Label();
            this.batChargingStatus = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pointCoordinate = new System.Windows.Forms.ToolStripStatusLabel();
            this.tailLampLabel = new System.Windows.Forms.Label();
            this.fogLampLabel = new System.Windows.Forms.Label();
            this.downLampLabel = new System.Windows.Forms.Label();
            this.upperLampLabel = new System.Windows.Forms.Label();
            this.turnLeftSignalLabel = new System.Windows.Forms.Label();
            this.turnRightSignalLabel = new System.Windows.Forms.Label();
            this.availableDistanceLabel = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSubscribe
            // 
            this.btnSubscribe.Location = new System.Drawing.Point(12, 84);
            this.btnSubscribe.Name = "btnSubscribe";
            this.btnSubscribe.Size = new System.Drawing.Size(96, 23);
            this.btnSubscribe.TabIndex = 0;
            this.btnSubscribe.Text = "Subscribe";
            this.btnSubscribe.UseVisualStyleBackColor = true;
            this.btnSubscribe.Click += new System.EventHandler(this.OnBtnSubscribeClick);
            // 
            // txtRx
            // 
            this.txtRx.Location = new System.Drawing.Point(13, 534);
            this.txtRx.Multiline = true;
            this.txtRx.Name = "txtRx";
            this.txtRx.Size = new System.Drawing.Size(214, 46);
            this.txtRx.TabIndex = 1;
            this.txtRx.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnUnsubscribe
            // 
            this.btnUnsubscribe.Location = new System.Drawing.Point(129, 84);
            this.btnUnsubscribe.Name = "btnUnsubscribe";
            this.btnUnsubscribe.Size = new System.Drawing.Size(96, 23);
            this.btnUnsubscribe.TabIndex = 2;
            this.btnUnsubscribe.Text = "Unsubscribe";
            this.btnUnsubscribe.UseVisualStyleBackColor = true;
            this.btnUnsubscribe.Click += new System.EventHandler(this.OnBtnUnsubscribeClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 518);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "상태";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textIPInput
            // 
            this.textIPInput.Location = new System.Drawing.Point(12, 28);
            this.textIPInput.Name = "textIPInput";
            this.textIPInput.Size = new System.Drawing.Size(132, 21);
            this.textIPInput.TabIndex = 6;
            this.textIPInput.Text = "tcp://localhost:12347";
            // 
            // textTopicInput
            // 
            this.textTopicInput.Location = new System.Drawing.Point(12, 55);
            this.textTopicInput.Name = "textTopicInput";
            this.textTopicInput.Size = new System.Drawing.Size(132, 21);
            this.textTopicInput.TabIndex = 7;
            this.textTopicInput.Text = "Vehicle";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "수신된 Data: Vehicle CAN Data";
            // 
            // btnIPInput
            // 
            this.btnIPInput.Location = new System.Drawing.Point(150, 28);
            this.btnIPInput.Name = "btnIPInput";
            this.btnIPInput.Size = new System.Drawing.Size(75, 23);
            this.btnIPInput.TabIndex = 10;
            this.btnIPInput.Text = "IP 설정";
            this.btnIPInput.UseVisualStyleBackColor = true;
            this.btnIPInput.Click += new System.EventHandler(this.OnIPBtnClicked);
            // 
            // btnTopicInput
            // 
            this.btnTopicInput.Location = new System.Drawing.Point(150, 55);
            this.btnTopicInput.Name = "btnTopicInput";
            this.btnTopicInput.Size = new System.Drawing.Size(75, 23);
            this.btnTopicInput.TabIndex = 11;
            this.btnTopicInput.Text = "Topic 설정";
            this.btnTopicInput.UseVisualStyleBackColor = true;
            this.btnTopicInput.Click += new System.EventHandler(this.OnTopicBtnClicked);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.key,
            this.value});
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(5, 230);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(251, 275);
            this.listView1.TabIndex = 12;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "(sub) Aro -> Monitoring";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "(pub) Aro <- Monitoring";
            // 
            // textPubIPInput
            // 
            this.textPubIPInput.Location = new System.Drawing.Point(13, 143);
            this.textPubIPInput.Name = "textPubIPInput";
            this.textPubIPInput.Size = new System.Drawing.Size(132, 21);
            this.textPubIPInput.TabIndex = 22;
            this.textPubIPInput.Text = "tcp://*:12345";
            // 
            // textPubTopicInput
            // 
            this.textPubTopicInput.Location = new System.Drawing.Point(13, 170);
            this.textPubTopicInput.Name = "textPubTopicInput";
            this.textPubTopicInput.Size = new System.Drawing.Size(132, 21);
            this.textPubTopicInput.TabIndex = 23;
            this.textPubTopicInput.Text = "VehicleCommand";
            // 
            // btnPubIP
            // 
            this.btnPubIP.Location = new System.Drawing.Point(151, 143);
            this.btnPubIP.Name = "btnPubIP";
            this.btnPubIP.Size = new System.Drawing.Size(75, 23);
            this.btnPubIP.TabIndex = 24;
            this.btnPubIP.Text = "IP 설정";
            this.btnPubIP.UseVisualStyleBackColor = true;
            this.btnPubIP.Click += new System.EventHandler(this.OnPubIPBtnClicked);
            // 
            // btnPubTopic
            // 
            this.btnPubTopic.Location = new System.Drawing.Point(151, 170);
            this.btnPubTopic.Name = "btnPubTopic";
            this.btnPubTopic.Size = new System.Drawing.Size(75, 23);
            this.btnPubTopic.TabIndex = 25;
            this.btnPubTopic.Text = "Topic 설정";
            this.btnPubTopic.UseVisualStyleBackColor = true;
            this.btnPubTopic.Click += new System.EventHandler(this.OnPubTopicBtnClicked);
            // 
            // doorToggleLabel
            // 
            this.doorToggleLabel.AutoSize = true;
            this.doorToggleLabel.Location = new System.Drawing.Point(276, 28);
            this.doorToggleLabel.Name = "doorToggleLabel";
            this.doorToggleLabel.Size = new System.Drawing.Size(75, 12);
            this.doorToggleLabel.TabIndex = 31;
            this.doorToggleLabel.Text = "문 열기/닫기";
            // 
            // autoDrivingLabel
            // 
            this.autoDrivingLabel.AutoSize = true;
            this.autoDrivingLabel.Location = new System.Drawing.Point(403, 28);
            this.autoDrivingLabel.Name = "autoDrivingLabel";
            this.autoDrivingLabel.Size = new System.Drawing.Size(115, 12);
            this.autoDrivingLabel.TabIndex = 32;
            this.autoDrivingLabel.Text = "자율주행 / 수동주행";
            // 
            // batteryGage
            // 
            this.batteryGage.Location = new System.Drawing.Point(285, 505);
            this.batteryGage.Name = "batteryGage";
            this.batteryGage.Size = new System.Drawing.Size(111, 23);
            this.batteryGage.TabIndex = 33;
            // 
            // batteryRemainLabel
            // 
            this.batteryRemainLabel.AutoSize = true;
            this.batteryRemainLabel.Location = new System.Drawing.Point(283, 478);
            this.batteryRemainLabel.Name = "batteryRemainLabel";
            this.batteryRemainLabel.Size = new System.Drawing.Size(52, 12);
            this.batteryRemainLabel.TabIndex = 34;
            this.batteryRemainLabel.Text = "Battery: ";
            // 
            // drivingDistanceLabel
            // 
            this.drivingDistanceLabel.AutoSize = true;
            this.drivingDistanceLabel.Location = new System.Drawing.Point(425, 498);
            this.drivingDistanceLabel.Name = "drivingDistanceLabel";
            this.drivingDistanceLabel.Size = new System.Drawing.Size(57, 12);
            this.drivingDistanceLabel.TabIndex = 35;
            this.drivingDistanceLabel.Text = "주행거리 ";
            // 
            // drivingTime
            // 
            this.drivingTime.AutoSize = true;
            this.drivingTime.Location = new System.Drawing.Point(427, 520);
            this.drivingTime.Name = "drivingTime";
            this.drivingTime.Size = new System.Drawing.Size(53, 12);
            this.drivingTime.TabIndex = 36;
            this.drivingTime.Text = "주행시간";
            // 
            // autoDrivingToggle
            // 
            this.autoDrivingToggle.Location = new System.Drawing.Point(403, 44);
            this.autoDrivingToggle.MinimumSize = new System.Drawing.Size(45, 22);
            this.autoDrivingToggle.Name = "autoDrivingToggle";
            this.autoDrivingToggle.OffBackColor = System.Drawing.Color.Gray;
            this.autoDrivingToggle.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.autoDrivingToggle.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.autoDrivingToggle.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.autoDrivingToggle.Size = new System.Drawing.Size(98, 22);
            this.autoDrivingToggle.TabIndex = 30;
            this.autoDrivingToggle.UseVisualStyleBackColor = true;
            this.autoDrivingToggle.CheckedChanged += new System.EventHandler(this.OnAutoDrivingCheckedChanged);
            // 
            // doorOpenToggle
            // 
            this.doorOpenToggle.Location = new System.Drawing.Point(275, 44);
            this.doorOpenToggle.MinimumSize = new System.Drawing.Size(45, 22);
            this.doorOpenToggle.Name = "doorOpenToggle";
            this.doorOpenToggle.OffBackColor = System.Drawing.Color.Gray;
            this.doorOpenToggle.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.doorOpenToggle.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.doorOpenToggle.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.doorOpenToggle.Size = new System.Drawing.Size(96, 22);
            this.doorOpenToggle.TabIndex = 29;
            this.doorOpenToggle.UseVisualStyleBackColor = true;
            this.doorOpenToggle.CheckedChanged += new System.EventHandler(this.OnDoorOpenCheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(412, 478);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 12);
            this.label2.TabIndex = 37;
            this.label2.Text = "Today:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(414, 542);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 12);
            this.label6.TabIndex = 38;
            this.label6.Text = "Total:";
            // 
            // totalDrivingDistance
            // 
            this.totalDrivingDistance.AutoSize = true;
            this.totalDrivingDistance.Location = new System.Drawing.Point(425, 557);
            this.totalDrivingDistance.Name = "totalDrivingDistance";
            this.totalDrivingDistance.Size = new System.Drawing.Size(85, 12);
            this.totalDrivingDistance.TabIndex = 39;
            this.totalDrivingDistance.Text = "누적 주행 거리";
            // 
            // batChargingStatus
            // 
            this.batChargingStatus.AutoSize = true;
            this.batChargingStatus.Location = new System.Drawing.Point(283, 531);
            this.batChargingStatus.Name = "batChargingStatus";
            this.batChargingStatus.Size = new System.Drawing.Size(61, 12);
            this.batChargingStatus.TabIndex = 40;
            this.batChargingStatus.Text = "충전 상태:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pointCoordinate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 583);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(554, 22);
            this.statusStrip1.TabIndex = 45;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pointCoordinate
            // 
            this.pointCoordinate.Name = "pointCoordinate";
            this.pointCoordinate.Size = new System.Drawing.Size(111, 17);
            this.pointCoordinate.Text = "마우스 포인터 좌표";
            // 
            // tailLampLabel
            // 
            this.tailLampLabel.AutoSize = true;
            this.tailLampLabel.Location = new System.Drawing.Point(283, 95);
            this.tailLampLabel.Name = "tailLampLabel";
            this.tailLampLabel.Size = new System.Drawing.Size(29, 12);
            this.tailLampLabel.TabIndex = 46;
            this.tailLampLabel.Text = "미등";
            // 
            // fogLampLabel
            // 
            this.fogLampLabel.AutoSize = true;
            this.fogLampLabel.Location = new System.Drawing.Point(333, 95);
            this.fogLampLabel.Name = "fogLampLabel";
            this.fogLampLabel.Size = new System.Drawing.Size(41, 12);
            this.fogLampLabel.TabIndex = 47;
            this.fogLampLabel.Text = "안개등";
            // 
            // downLampLabel
            // 
            this.downLampLabel.AutoSize = true;
            this.downLampLabel.Location = new System.Drawing.Point(383, 95);
            this.downLampLabel.Name = "downLampLabel";
            this.downLampLabel.Size = new System.Drawing.Size(41, 12);
            this.downLampLabel.TabIndex = 48;
            this.downLampLabel.Text = "하향등";
            // 
            // upperLampLabel
            // 
            this.upperLampLabel.AutoSize = true;
            this.upperLampLabel.Location = new System.Drawing.Point(433, 95);
            this.upperLampLabel.Name = "upperLampLabel";
            this.upperLampLabel.Size = new System.Drawing.Size(41, 12);
            this.upperLampLabel.TabIndex = 49;
            this.upperLampLabel.Text = "상향등";
            // 
            // turnLeftSignalLabel
            // 
            this.turnLeftSignalLabel.AutoSize = true;
            this.turnLeftSignalLabel.Location = new System.Drawing.Point(283, 145);
            this.turnLeftSignalLabel.Name = "turnLeftSignalLabel";
            this.turnLeftSignalLabel.Size = new System.Drawing.Size(87, 12);
            this.turnLeftSignalLabel.TabIndex = 50;
            this.turnLeftSignalLabel.Text = "방향지시등(좌)";
            // 
            // turnRightSignalLabel
            // 
            this.turnRightSignalLabel.AutoSize = true;
            this.turnRightSignalLabel.Location = new System.Drawing.Point(403, 145);
            this.turnRightSignalLabel.Name = "turnRightSignalLabel";
            this.turnRightSignalLabel.Size = new System.Drawing.Size(87, 12);
            this.turnRightSignalLabel.TabIndex = 51;
            this.turnRightSignalLabel.Text = "방향지시등(우)";
            // 
            // availableDistanceLabel
            // 
            this.availableDistanceLabel.AutoSize = true;
            this.availableDistanceLabel.Location = new System.Drawing.Point(285, 557);
            this.availableDistanceLabel.Name = "availableDistanceLabel";
            this.availableDistanceLabel.Size = new System.Drawing.Size(89, 12);
            this.availableDistanceLabel.TabIndex = 52;
            this.availableDistanceLabel.Text = "주행 가능 거리:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 605);
            this.Controls.Add(this.availableDistanceLabel);
            this.Controls.Add(this.turnRightSignalLabel);
            this.Controls.Add(this.turnLeftSignalLabel);
            this.Controls.Add(this.upperLampLabel);
            this.Controls.Add(this.downLampLabel);
            this.Controls.Add(this.fogLampLabel);
            this.Controls.Add(this.tailLampLabel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.batChargingStatus);
            this.Controls.Add(this.totalDrivingDistance);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.drivingTime);
            this.Controls.Add(this.drivingDistanceLabel);
            this.Controls.Add(this.batteryRemainLabel);
            this.Controls.Add(this.batteryGage);
            this.Controls.Add(this.autoDrivingLabel);
            this.Controls.Add(this.doorToggleLabel);
            this.Controls.Add(this.autoDrivingToggle);
            this.Controls.Add(this.doorOpenToggle);
            this.Controls.Add(this.btnPubTopic);
            this.Controls.Add(this.btnPubIP);
            this.Controls.Add(this.textPubTopicInput);
            this.Controls.Add(this.textPubIPInput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnTopicInput);
            this.Controls.Add(this.btnIPInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textTopicInput);
            this.Controls.Add(this.textIPInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUnsubscribe);
            this.Controls.Add(this.txtRx);
            this.Controls.Add(this.btnSubscribe);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Monitoring App Simulation";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubscribe;
        private System.Windows.Forms.TextBox txtRx;
        private System.Windows.Forms.Button btnUnsubscribe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textIPInput;
        private System.Windows.Forms.TextBox textTopicInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnIPInput;
        private System.Windows.Forms.Button btnTopicInput;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader key;
        private System.Windows.Forms.ColumnHeader value;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textPubIPInput;
        private System.Windows.Forms.TextBox textPubTopicInput;
        private System.Windows.Forms.Button btnPubIP;
        private System.Windows.Forms.Button btnPubTopic;
        private CabinToggleButton doorOpenToggle;
        private CabinToggleButton autoDrivingToggle;
        private System.Windows.Forms.Label doorToggleLabel;
        private System.Windows.Forms.Label autoDrivingLabel;
        private System.Windows.Forms.ProgressBar batteryGage;
        private System.Windows.Forms.Label batteryRemainLabel;
        private System.Windows.Forms.Label drivingDistanceLabel;
        private System.Windows.Forms.Label drivingTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label totalDrivingDistance;
        private System.Windows.Forms.Label batChargingStatus;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel pointCoordinate;
        private System.Windows.Forms.Label tailLampLabel;
        private System.Windows.Forms.Label fogLampLabel;
        private System.Windows.Forms.Label downLampLabel;
        private System.Windows.Forms.Label upperLampLabel;
        private System.Windows.Forms.Label turnLeftSignalLabel;
        private System.Windows.Forms.Label turnRightSignalLabel;
        private System.Windows.Forms.Label availableDistanceLabel;
    }
}

