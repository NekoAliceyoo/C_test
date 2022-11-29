using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using CAN驱动库;
using System.Threading;
using System.Windows.Forms;

namespace 天琴
{

    [StructLayout(LayoutKind.Sequential)]

    public struct ZCAN_Receive_Data
    {
        public can_frame frame;
        public UInt64 timestamp;//us
    };


    class RXthreads
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void RecvCANDataEventHandler(ZCAN_Receive_Data[] data, uint len);//CAN数据接收事件委托

        const int TYPE_CAN = 0;

        bool m_bStart;
        IntPtr channel_handle_;
        Thread recv_thread_;
        static object locker = new object();
        public static RecvCANDataEventHandler OnRecvCANDataEvent;
        public RXthreads()
        {

        }

        public event RecvCANDataEventHandler RecvCANData
        {
            add { OnRecvCANDataEvent += new RecvCANDataEventHandler(value); }
            remove { OnRecvCANDataEvent -= new RecvCANDataEventHandler(value); }
        }


        public void setStart(bool start)
        {
            m_bStart = start;
            if (start)
            {
                recv_thread_ = new Thread(RecvDataFunc);
                recv_thread_.IsBackground = true;
                recv_thread_.Start();
            }
            else
            {
                recv_thread_.Join();
                recv_thread_ = null;
            }
        }

        public void setChannelHandle(IntPtr channel_handle)
        {
            lock (locker)
            {
                channel_handle_ = channel_handle;
            }
        }

        //数据接收函数
        protected void RecvDataFunc()
        {
            ZCAN_Receive_Data[] can_data = new ZCAN_Receive_Data[10000];
           uint len;
            while (m_bStart)
            {
                lock (locker)
                {

                    len = CANDLL函数.ZCAN_GetReceiveNum(channel_handle_, TYPE_CAN);
                    if (len > 0)
                    {
                        int size = Marshal.SizeOf(typeof(ZCAN_Receive_Data));
                        IntPtr ptr = Marshal.AllocHGlobal((int)len * size);
                        len = CANDLL函数.ZCAN_Receive(channel_handle_, ptr, len, 50);
                        for (int i = 0; i < len; ++i)
                        {
                            can_data[i] = (ZCAN_Receive_Data)Marshal.PtrToStructure(
                                (IntPtr)((Int64)ptr + i * size), typeof(ZCAN_Receive_Data));
                        }
                        OnRecvCANDataEvent(can_data, len);
                        Marshal.FreeHGlobal(ptr);
                        //MessageBox.Show("发送失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    
                }
                Thread.Sleep(1000);
            }
        }
    }
}
