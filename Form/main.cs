using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using CAN驱动库;



namespace 天琴
{

    public partial class main : Form
    {

        public IntPtr device_handle;
        public IntPtr channel_handle;
        uint CANStartStatus;
        uint CANTXLEN;
        //uint CANRXStatus;
        readonly uint TXID = 0x1234;
        readonly uint Sendtype = 3;  //0=正常发送，1=单次发送，2=自发自收，3=单次自发自收
        readonly uint Frame_type = 1; //帧类型,0标准帧，1扩展帧
        //readonly string Sendmassage = "11 22 33 44 55 66 77 88";
        byte[] Senddata = {0x11,0x22,0x33,0x44};
        
        /*线程*/
        const uint CAN_EFF_FLAG = 0x80000000U; /* EFF/SFF is set in the MSB */
        const uint CAN_RTR_FLAG = 0x40000000U; /* remote transmission request */
        const uint CAN_ID_FLAG = 0x1FFFFFFFU; /* id */
        RXthreads recv_data_thread_;
        List<string> list_box_data_ = new List<string>();
        static object lock_obj = new object();

        //bool m_bOpen = false;//初始化状态，正常发送指令前先判断此处
        bool m_bStart = false;

        public main()
        {
            InitializeComponent();
        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void main_Load_1(object sender, EventArgs e)
        {
            CAN设备类型.SelectedIndex = 1;
            CAN通道.SelectedIndex = 0;
            CAN滤波方式.SelectedIndex = 0;
            CAN波特率.SelectedIndex = 11;
            CAN发送方式.SelectedIndex = 0;


        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        static IntPtr rxchannel_handle;


        CAN驱动 CANDrive = new CAN驱动();
        private void CAN连接_Click(object sender, EventArgs e)
        {
            if (CAN连接.Enabled == true)
            {
                device_handle = CANDrive.CANOpen(4, (uint)CAN通道.SelectedIndex);
                if ((int)device_handle != 0)
                {
                    channel_handle = CANDrive.CANinit(device_handle, 4, (uint)CAN通道.SelectedIndex, (uint)CAN波特率.SelectedIndex, (byte)CAN滤波方式.SelectedIndex, 0x00000000, 0xFFFFFFFF, 0);
                    if ((int)channel_handle != 0)
                    {
                        CANStartStatus = CANDrive.ZCANStart(channel_handle);
                        if (CANStartStatus == 0)
                        {
                            MessageBox.Show("CANStart失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else 
                        {
                            m_bStart = true;
                            /*以下为线程调用一直监测接收的数据，实际在工程中不一定用得上*/
                            if (null == recv_data_thread_)
                            {
                                //recv_data_thread_ = new RXthreads();
                                //recv_data_thread_.setChannelHandle(channel_handle);
                                //recv_data_thread_.setStart(m_bStart);
                                //recv_data_thread_.RecvCANData += this.AddData;


                               
                            }
                            else
                            {
                                recv_data_thread_.setChannelHandle(channel_handle);
                            }

                            CAN连接.Enabled = false;
                            return; 
                        }
                    }
                    else { MessageBox.Show("CANInit失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

                }
                else { MessageBox.Show("CANOpen失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);  }
                //Thread.Sleep(5000);
            }
            else { }
        }

        private void CAN断开_Click(object sender, EventArgs e)
        {
            
            CANDrive.ZCANClose(channel_handle);
            CAN连接.Enabled = true;
        }
        public bool IsEFF(uint id)//1:extend frame 0:standard frame
        {
            return !!Convert.ToBoolean((id & CAN_EFF_FLAG));
        }

        public bool IsRTR(uint id)//1:remote frame 0:data frame
        {
            return !!Convert.ToBoolean((id & CAN_RTR_FLAG));
        }
        public uint GetId(uint id)
        {
            return id & CAN_ID_FLAG;
        }
        private void SetListBox(object sender, EventArgs e)
        {
            //int index = 0;
            lock (lock_obj)
            {
                foreach (string text in list_box_data_)
                {
                    //index = listBox.Items.Add(text);
                    遥测源码.Text = "";
                }
                list_box_data_.Clear();
            }
            //listBox.SelectedIndex = index;
        }
        public void AddData(ZCAN_Receive_Data[] data, uint len)
        {
            string text = "";
            for (uint i = 0; i < len; ++i)
            {
                ZCAN_Receive_Data can = data[i];
                uint id = data[i].frame.can_id;
                string eff = IsEFF(id) ? "扩展帧" : "标准帧";
                string rtr = IsRTR(id) ? "远程帧" : "数据帧";
                text = String.Format("ID:0x{0:X8} {1:G} {2:G} 长度:{3:D1} 数据:", GetId(id), eff, rtr, can.frame.can_dlc);

                for (uint j = 0; j < can.frame.can_dlc; ++j)
                {
                    text = String.Format("{0:G}{1:X2} ", text, can.frame.data[j]);
                }
                lock (lock_obj)
                {
                    System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
                    遥测源码.AppendText(text);
                    遥测源码.AppendText("\r\n");
                }
            }

            Object[] list = { this, System.EventArgs.Empty };
            this.遥测源码.BeginInvoke(new EventHandler(SetListBox), list);
        }
        private void 开关指令发送_Click(object sender, EventArgs e)
        {
            //uint CANlen;
            //CANTXLEN = CANDrive.CANTransmit_str(channel_handle, TXID, Sendtype, Frame_type, Sendmassage);
            
            CANTXLEN = CANDrive.CANTransmit_u8(channel_handle, TXID, Sendtype, Frame_type, 4, ref Senddata);
            if (CANTXLEN == 0)
            {
                MessageBox.Show("发送失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//第一个参数是内容，第二个是标题，第三个是按钮，第四个是图标。星号代表I符号
            }
            else 
            {
                //CANlen = CANDrive.ZCAN_Receive(channel_handle,1,50);

            }

        }
    }
}
