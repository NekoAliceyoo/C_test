
namespace 天琴
{
    partial class main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CAN配置 = new System.Windows.Forms.Panel();
            this.CAN断开 = new System.Windows.Forms.Button();
            this.CAN连接 = new System.Windows.Forms.Button();
            this.CAN设备号 = new System.Windows.Forms.NumericUpDown();
            this.CAN屏蔽码 = new System.Windows.Forms.TextBox();
            this.CAN验收码 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CAN滤波方式 = new System.Windows.Forms.ComboBox();
            this.CAN通道 = new System.Windows.Forms.ComboBox();
            this.CAN发送方式 = new System.Windows.Forms.ComboBox();
            this.CAN波特率 = new System.Windows.Forms.ComboBox();
            this.CAN设备类型 = new System.Windows.Forms.ComboBox();
            this.遥控指令 = new System.Windows.Forms.Panel();
            this.遥测量 = new System.Windows.Forms.Panel();
            this.开关指令发送 = new System.Windows.Forms.Button();
            this.遥测源码 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CAN配置.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CAN设备号)).BeginInit();
            this.遥控指令.SuspendLayout();
            this.SuspendLayout();
            // 
            // CAN配置
            // 
            this.CAN配置.Controls.Add(this.label9);
            this.CAN配置.Controls.Add(this.遥测源码);
            this.CAN配置.Controls.Add(this.CAN断开);
            this.CAN配置.Controls.Add(this.CAN连接);
            this.CAN配置.Controls.Add(this.CAN设备号);
            this.CAN配置.Controls.Add(this.CAN屏蔽码);
            this.CAN配置.Controls.Add(this.CAN验收码);
            this.CAN配置.Controls.Add(this.label5);
            this.CAN配置.Controls.Add(this.label4);
            this.CAN配置.Controls.Add(this.label8);
            this.CAN配置.Controls.Add(this.label2);
            this.CAN配置.Controls.Add(this.label6);
            this.CAN配置.Controls.Add(this.label3);
            this.CAN配置.Controls.Add(this.label7);
            this.CAN配置.Controls.Add(this.label1);
            this.CAN配置.Controls.Add(this.CAN滤波方式);
            this.CAN配置.Controls.Add(this.CAN通道);
            this.CAN配置.Controls.Add(this.CAN发送方式);
            this.CAN配置.Controls.Add(this.CAN波特率);
            this.CAN配置.Controls.Add(this.CAN设备类型);
            this.CAN配置.Location = new System.Drawing.Point(24, 22);
            this.CAN配置.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.CAN配置.Name = "CAN配置";
            this.CAN配置.Size = new System.Drawing.Size(672, 1709);
            this.CAN配置.TabIndex = 0;
            // 
            // CAN断开
            // 
            this.CAN断开.Location = new System.Drawing.Point(356, 525);
            this.CAN断开.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.CAN断开.Name = "CAN断开";
            this.CAN断开.Size = new System.Drawing.Size(268, 80);
            this.CAN断开.TabIndex = 4;
            this.CAN断开.Text = "CAN断开";
            this.CAN断开.UseVisualStyleBackColor = true;
            this.CAN断开.Click += new System.EventHandler(this.CAN断开_Click);
            // 
            // CAN连接
            // 
            this.CAN连接.Location = new System.Drawing.Point(40, 525);
            this.CAN连接.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.CAN连接.Name = "CAN连接";
            this.CAN连接.Size = new System.Drawing.Size(268, 80);
            this.CAN连接.TabIndex = 4;
            this.CAN连接.Text = "CAN连接";
            this.CAN连接.UseVisualStyleBackColor = true;
            this.CAN连接.Click += new System.EventHandler(this.CAN连接_Click);
            // 
            // CAN设备号
            // 
            this.CAN设备号.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CAN设备号.Location = new System.Drawing.Point(356, 78);
            this.CAN设备号.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.CAN设备号.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.CAN设备号.Name = "CAN设备号";
            this.CAN设备号.Size = new System.Drawing.Size(268, 41);
            this.CAN设备号.TabIndex = 3;
            this.CAN设备号.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CAN设备号.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // CAN屏蔽码
            // 
            this.CAN屏蔽码.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CAN屏蔽码.Location = new System.Drawing.Point(356, 317);
            this.CAN屏蔽码.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.CAN屏蔽码.Name = "CAN屏蔽码";
            this.CAN屏蔽码.Size = new System.Drawing.Size(264, 41);
            this.CAN屏蔽码.TabIndex = 2;
            this.CAN屏蔽码.Text = "0xFFFFFFFF";
            // 
            // CAN验收码
            // 
            this.CAN验收码.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CAN验收码.Location = new System.Drawing.Point(356, 191);
            this.CAN验收码.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.CAN验收码.Name = "CAN验收码";
            this.CAN验收码.Size = new System.Drawing.Size(264, 41);
            this.CAN验收码.TabIndex = 2;
            this.CAN验收码.Text = "0x00000000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(356, 274);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 31);
            this.label5.TabIndex = 1;
            this.label5.Text = "屏蔽码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(356, 148);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 31);
            this.label4.TabIndex = 1;
            this.label4.Text = "验收码";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(356, 392);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 31);
            this.label8.TabIndex = 1;
            this.label8.Text = "发送方式";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "设备索引号";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 274);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 31);
            this.label6.TabIndex = 1;
            this.label6.Text = "滤波方式";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 148);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 31);
            this.label3.TabIndex = 1;
            this.label3.Text = "通道号";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 392);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 31);
            this.label7.TabIndex = 1;
            this.label7.Text = "波特率";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "设备类型";
            // 
            // CAN滤波方式
            // 
            this.CAN滤波方式.FormattingEnabled = true;
            this.CAN滤波方式.Items.AddRange(new object[] {
            "单滤波",
            "双滤波"});
            this.CAN滤波方式.Location = new System.Drawing.Point(40, 315);
            this.CAN滤波方式.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.CAN滤波方式.Name = "CAN滤波方式";
            this.CAN滤波方式.Size = new System.Drawing.Size(264, 39);
            this.CAN滤波方式.TabIndex = 0;
            // 
            // CAN通道
            // 
            this.CAN通道.FormattingEnabled = true;
            this.CAN通道.Items.AddRange(new object[] {
            "0",
            "1"});
            this.CAN通道.Location = new System.Drawing.Point(40, 190);
            this.CAN通道.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.CAN通道.Name = "CAN通道";
            this.CAN通道.Size = new System.Drawing.Size(264, 39);
            this.CAN通道.TabIndex = 0;
            // 
            // CAN发送方式
            // 
            this.CAN发送方式.FormattingEnabled = true;
            this.CAN发送方式.Items.AddRange(new object[] {
            "正常发送",
            "只听",
            "自发自收",
            "单次自发自收"});
            this.CAN发送方式.Location = new System.Drawing.Point(356, 434);
            this.CAN发送方式.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.CAN发送方式.Name = "CAN发送方式";
            this.CAN发送方式.Size = new System.Drawing.Size(264, 39);
            this.CAN发送方式.TabIndex = 0;
            // 
            // CAN波特率
            // 
            this.CAN波特率.FormattingEnabled = true;
            this.CAN波特率.Items.AddRange(new object[] {
            "1Mbps",
            "10kbps",
            "20kbps",
            "40kbps",
            "50kbps",
            "80kbps",
            "100kbps",
            "125kbps",
            "200kbps",
            "250kbps",
            "400kbps",
            "500kbps",
            "666kbps",
            "800kbps",
            "1000kbps"});
            this.CAN波特率.Location = new System.Drawing.Point(40, 434);
            this.CAN波特率.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.CAN波特率.Name = "CAN波特率";
            this.CAN波特率.Size = new System.Drawing.Size(264, 39);
            this.CAN波特率.TabIndex = 0;
            // 
            // CAN设备类型
            // 
            this.CAN设备类型.FormattingEnabled = true;
            this.CAN设备类型.Items.AddRange(new object[] {
            "USBCAN1",
            "USBCAN2"});
            this.CAN设备类型.Location = new System.Drawing.Point(40, 77);
            this.CAN设备类型.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.CAN设备类型.Name = "CAN设备类型";
            this.CAN设备类型.Size = new System.Drawing.Size(264, 39);
            this.CAN设备类型.TabIndex = 0;
            // 
            // 遥控指令
            // 
            this.遥控指令.Controls.Add(this.开关指令发送);
            this.遥控指令.Location = new System.Drawing.Point(708, 22);
            this.遥控指令.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.遥控指令.Name = "遥控指令";
            this.遥控指令.Size = new System.Drawing.Size(2444, 919);
            this.遥控指令.TabIndex = 1;
            // 
            // 遥测量
            // 
            this.遥测量.Location = new System.Drawing.Point(708, 952);
            this.遥测量.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.遥测量.Name = "遥测量";
            this.遥测量.Size = new System.Drawing.Size(2442, 777);
            this.遥测量.TabIndex = 2;
            // 
            // 开关指令发送
            // 
            this.开关指令发送.Location = new System.Drawing.Point(106, 55);
            this.开关指令发送.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.开关指令发送.Name = "开关指令发送";
            this.开关指令发送.Size = new System.Drawing.Size(268, 80);
            this.开关指令发送.TabIndex = 5;
            this.开关指令发送.Text = "开关指令发送";
            this.开关指令发送.UseVisualStyleBackColor = true;
            this.开关指令发送.Click += new System.EventHandler(this.开关指令发送_Click);
            // 
            // 遥测源码
            // 
            this.遥测源码.Location = new System.Drawing.Point(40, 669);
            this.遥测源码.Multiline = true;
            this.遥测源码.Name = "遥测源码";
            this.遥测源码.Size = new System.Drawing.Size(584, 1015);
            this.遥测源码.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 635);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 31);
            this.label9.TabIndex = 6;
            this.label9.Text = "遥测源码";
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3168, 1752);
            this.Controls.Add(this.遥测量);
            this.Controls.Add(this.遥控指令);
            this.Controls.Add(this.CAN配置);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "main";
            this.Text = "天琴上位机";
            this.Load += new System.EventHandler(this.main_Load_1);
            this.CAN配置.ResumeLayout(false);
            this.CAN配置.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CAN设备号)).EndInit();
            this.遥控指令.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel CAN配置;
        private System.Windows.Forms.Panel 遥控指令;
        private System.Windows.Forms.Panel 遥测量;
        private System.Windows.Forms.ComboBox CAN设备类型;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CAN通道;
        private System.Windows.Forms.TextBox CAN屏蔽码;
        private System.Windows.Forms.TextBox CAN验收码;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CAN滤波方式;
        private System.Windows.Forms.ComboBox CAN发送方式;
        private System.Windows.Forms.ComboBox CAN波特率;
        private System.Windows.Forms.NumericUpDown CAN设备号;
        private System.Windows.Forms.Button CAN断开;
        private System.Windows.Forms.Button CAN连接;
        private System.Windows.Forms.TextBox 遥测源码;
        private System.Windows.Forms.Button 开关指令发送;
        private System.Windows.Forms.Label label9;
    }
}

