using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;



namespace CAN驱动库
{

    public struct ZCAN
    {
        //CAN波特率 定时器0    定时器 1
        //1Mbps 80%    0xBF        0xFF
        //10Kbps          0x31         0x1C
        //20Kbps          0x18         0x1C
        //40Kbps          0x87         0xFF
        //50Kbps          0x09         0x1C
        //80Kbps          0x83         0Xff
        //100Kbps        0x04         0x1C
        //125Kbps        0x03         0x1C
        //200Kbps        0x81         0xFA
        //250Kbps        0x01         0x1C
        //400Kbps        0x80         0xFA
        //500Kbps        0x00         0x1C
        //666Kbps        0x80         0xB6
        //800Kbps        0x00         0x16
        //1000Kbps      0x00         0x14
        public uint acc_code;
        public uint acc_mask;
        public uint reserved;
        public byte filter;
        public byte timing0;
        public byte timing1;
        public byte mode;
    }

    public class Define
    {
        public const int TYPE_CAN = 0;
        public const int TYPE_CANFD = 1;
        public const int ZCAN_USBCAN1 = 3;
        public const int ZCAN_USBCAN2 = 4;
        public const int ZCAN_CANETUDP = 12;
        public const int ZCAN_CANETTCP = 17;
        public const int ZCAN_USBCAN_E_U = 20;
        public const int ZCAN_USBCAN_2E_U = 21;
        public const int ZCAN_PCIECANFD_100U = 38;
        public const int ZCAN_PCIECANFD_200U = 39;
        public const int ZCAN_PCIECANFD_200U_EX = 62;
        public const int ZCAN_PCIECANFD_400U = 61;
        public const int ZCAN_USBCANFD_200U = 41;
        public const int ZCAN_USBCANFD_100U = 42;
        public const int ZCAN_USBCANFD_MINI = 43;
        public const int ZCAN_CLOUD = 46;
        public const int ZCAN_CANFDNET_200U_TCP = 48;
        public const int ZCAN_CANFDNET_200U_UDP = 49;
        public const int ZCAN_CANFDNET_400U_TCP = 52;
        public const int ZCAN_CANFDNET_400U_UDP = 53;
        public const int ZCAN_CANFDNET_800U_TCP = 57;
        public const int ZCAN_CANFDNET_800U_UDP = 58;
        public const int STATUS_ERR = 0;
        public const int STATUS_OK = 1;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct ZCAN_CHANNEL_INIT_CONFIG
    {
        [FieldOffset(0)]
        public uint can_type; //type:TYPE_CAN TYPE_CANFD

        [FieldOffset(4)]
        public ZCAN can;

    }
    [StructLayout(LayoutKind.Sequential)]
    public struct can_frame
    {
        public uint can_id;  /* 32 bit MAKE_CAN_ID + EFF/RTR/ERR flags */
        //第 31 位(最高位)代表扩展帧标志，=0 表示标准帧，=1 代表扩展帧，第 30 位代表远程帧标志，=0 表示数据帧，=1 表示远程帧，
        //第 29 位代表错误帧标准，=0 表示 CAN 帧，=1 表示错误帧，其余位代表实际帧 ID 值
        public byte can_dlc; /* frame payload length in byte (0 .. CAN_MAX_DLEN) *///数据长度。
        public byte __pad;   /* padding *///对齐，忽略。
        public byte __res0;  /* reserved / padding *///仅作保留，不设置
        public byte __res1;  /* reserved / padding *///仅作保留，不设置
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] data;/* __attribute__((aligned(8)))*///报文数据，有效长度为 can_dlc
    };
    public struct ZCAN_Transmit_Data
    {
        public can_frame frame;
        public uint transmit_type;
    }
    public struct ZCAN_RX_Data//单帧接收缓存
    {
        public can_frame frame;
        public UInt64 timestamp;//us
    };



    class CANDLL函数
    {

        [DllImport("zlgcan.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr ZCAN_OpenDevice(uint device_type, uint device_index, uint reserved);

        [DllImport("zlgcan.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr ZCAN_InitCAN(IntPtr device_handle, uint can_index, IntPtr pInitConfig);

        [DllImport("zlgcan.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint ZCAN_StartCAN(IntPtr channel_handle);

        [DllImport("zlgcan.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint ZCAN_ResetCAN(IntPtr channel_handle);

        [DllImport("zlgcan.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint ZCAN_CloseDevice(IntPtr device_handle);

        [DllImport("zlgcan.dll", CallingConvention = CallingConvention.StdCall)]
        // pTransmit -> ZCAN_Transmit_Data
        public static extern uint ZCAN_Transmit(IntPtr channel_handle, IntPtr pTransmit, uint len);

        [DllImport("zlgcan.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint ZCAN_GetReceiveNum(IntPtr channel_handle, byte type);

        [DllImport("zlgcan.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern uint ZCAN_Receive(IntPtr channel_handle, IntPtr data, uint len, int wait_time = -1);

    }
    class CAN驱动
    {
        ZCAN_CHANNEL_INIT_CONFIG config_ = new ZCAN_CHANNEL_INIT_CONFIG();
        IntPtr CANDEVICE_HANDLE_;
        IntPtr CANCHANNEL_HANDLE_;

        //can_type  CAN设备类型
        //can_index  CAN通道号
        public IntPtr CANOpen(uint device_type, uint device_inde)
        {
            CANDEVICE_HANDLE_ = CANDLL函数.ZCAN_OpenDevice(device_type, device_inde, 0);
            return CANDEVICE_HANDLE_;
        }
        //device_handle设备资源句柄
        //can_type  CAN设备类型
        //can_index  CAN通道号
        //kbps CAN波特率
        //filter CAN滤波方式
        //acc_code CAN验收码
        //acc_mask CAN屏蔽码
        //mode  0 表示正常模式，=1 表示只听模式
        public IntPtr CANinit(IntPtr device_handle,  uint can_type, uint can_index, uint baudrate, byte filter, uint acc_code, uint acc_mask, byte mode)
        {
            //baudrate
            //0 -- 1Mbps 
            //1 -- 10Kbps 
            //2 -- 20Kbps  
            //3 -- 40Kbps 
            //4 -- 50Kbps 
            //5 -- 80Kbps 
            //6 -- 100Kbps 
            //7 -- 125Kbps 
            //8 -- 200Kbps 
            //9 -- 250Kbps 
            //10 -- 400Kbps 
            //11 -- 500Kbps 
            //12 -- 666Kbps 
            //13 -- 800Kbps 
            //14 -- 1000Kbps 
            if (baudrate == 0)      {config_.can.timing0 = 0xBF; config_.can.timing1 = 0xFF;}
            else if (baudrate == 1){config_.can.timing0 = 0x31; config_.can.timing1 = 0x1C;}
            else if (baudrate == 2){config_.can.timing0 = 0x18; config_.can.timing1 = 0x1C;}
            else if (baudrate == 3){config_.can.timing0 = 0x87; config_.can.timing1 = 0xFF;}
            else if (baudrate == 4){config_.can.timing0 = 0x09; config_.can.timing1 = 0x1C;}
            else if (baudrate == 5){config_.can.timing0 = 0x83; config_.can.timing1 = 0xFF;}
            else if (baudrate == 6){config_.can.timing0 = 0x04; config_.can.timing1 = 0x1C;}
            else if (baudrate == 7) { config_.can.timing0 = 0x03; config_.can.timing1 = 0x1C; }
            else if (baudrate == 8) { config_.can.timing0 = 0x81; config_.can.timing1 = 0xFA; }
            else if (baudrate == 9) { config_.can.timing0 = 0x01; config_.can.timing1 = 0x1C; }
            else if (baudrate == 10) { config_.can.timing0 = 0x80; config_.can.timing1 = 0xFA; }
            else if (baudrate == 11) { config_.can.timing0 = 0x00; config_.can.timing1 = 0x1C; }
            else if (baudrate == 12) { config_.can.timing0 = 0x80; config_.can.timing1 = 0xB6; }
            else if (baudrate == 13) { config_.can.timing0 = 0x00; config_.can.timing1 = 0x16; }
            else if (baudrate == 14){ config_.can.timing0 = 0x00; config_.can.timing1 = 0x14; }
            else { config_.can.timing0 = 0x00; config_.can.timing1 = 0x00; }
            config_.can_type = can_type;
            config_.can.acc_code = acc_code;
            config_.can.acc_mask = acc_mask;
            config_.can.reserved = 0;//目前默认为0
            config_.can.filter = filter;
            config_.can.mode = mode;
            IntPtr pConfig = Marshal.AllocHGlobal(Marshal.SizeOf(config_));//转换结构体作为指针地址输入
            Marshal.StructureToPtr(config_, pConfig, true);
            CANCHANNEL_HANDLE_ = CANDLL函数.ZCAN_InitCAN(device_handle, can_index, pConfig);
            Marshal.FreeHGlobal(pConfig);
            return CANCHANNEL_HANDLE_;
        }

        //channel_handle设备资源句柄
        public uint ZCANStart(IntPtr channel_handle)
        {
            return CANDLL函数.ZCAN_StartCAN(channel_handle); 
        }
        //channel_handle设备资源句柄
        public uint ZCANReset(IntPtr channel_handle)
        {
            return CANDLL函数.ZCAN_ResetCAN(channel_handle);
        }
        //channel_handle设备资源句柄
        public uint ZCANClose(IntPtr channel_handle)
        {
            return CANDLL函数.ZCAN_CloseDevice(channel_handle);
        }
        //id CANID
        //frametype 帧类型
        public uint MakeCanId(uint id, uint frametype, int ExternFlag)//ID; 0:标准帧 1:拓展帧; 0数据帧，1远程帧
        {
            uint ueff = (uint)(!!(Convert.ToBoolean(frametype)) ? 1 : 0);//帧类型 0:标准帧 1:拓展帧;
            uint urtr = (uint)(!!(Convert.ToBoolean(ExternFlag)) ? 1 : 0);//数据帧/远程
            uint uerr = (uint)(!!(Convert.ToBoolean(0)) ? 1 : 0);//0 表示 CAN 帧，1 表示错误帧，目前只能设置为 0；
            return id | ueff << 31 | urtr << 30 | uerr << 29;
        }
        private int SplitData(string data, ref byte[] transData, int maxLen)
        {
            string[] dataArray = data.Split(' ');
            for (int i = 0; (i < maxLen) && (i < dataArray.Length); i++)
            {
                transData[i] = Convert.ToByte(dataArray[i].Substring(0, 2), 16);
            }

            return dataArray.Length;
        }

        //channel_handle设备资源句柄
        //id  CANID
        //send_type 发送方式，0=正常发送，1=单次发送，2=自发自收，3=单次自发自收
        //frame_type 帧类型,0标准帧，1扩展帧
        //data16 16进制字符串，最大16字长
        public uint CANTransmit_str(IntPtr channel_handle, uint id, uint send_type, uint frame_type, string data16)//自动获取CAN数据长度，返回发送成功帧数
        {
            uint result; //发送的帧数
            const int CAN_MAX_DLEN = 8;

            ZCAN_Transmit_Data can_data = new ZCAN_Transmit_Data();
            can_data.frame.can_id = MakeCanId(id, frame_type, 0);//ID；frame_type：0数据帧/扩展帧；默认0数据帧
            can_data.frame.data = new byte[8];//不能在变量声明中定义数组大小，需要在new中初始化
            can_data.frame.can_dlc = (byte)SplitData(data16, ref can_data.frame.data, CAN_MAX_DLEN);//获取CAN数据长度
            can_data.transmit_type = send_type;//发送方式，，0=正常发送，1=单次发送，2=自发自收，3=单次自发自收
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(can_data));
            Marshal.StructureToPtr(can_data, ptr, true);
            result = CANDLL函数.ZCAN_Transmit(channel_handle, ptr, 1);//1是帧数？ptr里有一个帧长度
            Marshal.FreeHGlobal(ptr);
            return result;
           // return CANDLL函数.ZCAN_Transmit(channel_handle, pTransmit, len);//len是帧数？
        }

        //channel_handle设备资源句柄
        //id  CANID
        //send_type 发送方式，0=正常发送，1=单次发送，2=自发自收，3=单次自发自收
        //frame_type 帧类型,0标准帧，1扩展帧
        //can_dlc 一帧的数据帧长度
        //u8Data，数据，在调用时必须加上 ref
        public uint CANTransmit_u8(IntPtr channel_handle, uint id, uint send_type, uint frame_type, byte can_dlc, ref byte[] u8Data)//自动获取CAN数据长度，返回发送成功帧数
        {
            uint result; 

            ZCAN_Transmit_Data can_data = new ZCAN_Transmit_Data();
            can_data.frame.can_id = MakeCanId(id, frame_type, 0);//ID；frame_type：0数据帧/扩展帧；默认0数据帧

            can_data.frame.data = new byte[8];//不能在变量声明中定义数组大小，需要在new中初始化
            can_data.frame.can_dlc = can_dlc;

            for (int i = 0; i< can_dlc; i++)
            {
                can_data.frame.data[i] = u8Data[i];
            }

            can_data.transmit_type = send_type;//发送方式，，0=正常发送，1=单次发送，2=自发自收，3=单次自发自收
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(can_data));
            Marshal.StructureToPtr(can_data, ptr, true);
            result = CANDLL函数.ZCAN_Transmit(channel_handle, ptr, 1);//1是帧数？ptr里有一个帧长度
            Marshal.FreeHGlobal(ptr);
            return result;// 返回发送成功帧数
        }

        public uint ZCAN_GetReceiveNum(IntPtr channel_handle, byte type)
        {
            return CANDLL函数.ZCAN_GetReceiveNum(channel_handle, type);
        }

        //can_data[0]为接收一帧的数据
        //ptr 接收的完整一帧数据指针，ZCAN_RX_Data里可以查看详细数据
        public uint ZCAN_Receive(IntPtr channel_handle, uint len, int wait_time = -1)
        {
            uint RXlen;
            ZCAN_RX_Data[] can_data = new ZCAN_RX_Data[1];//1000帧？

            IntPtr ptr = Marshal.AllocHGlobal((int)len);
            RXlen = CANDLL函数.ZCAN_Receive(channel_handle, ptr, len, wait_time);
            can_data[0] = (ZCAN_RX_Data)Marshal.PtrToStructure(
            (IntPtr)((Int64)ptr), typeof(ZCAN_RX_Data));

            Marshal.FreeHGlobal(ptr);
            return RXlen;
        }


    }


}
