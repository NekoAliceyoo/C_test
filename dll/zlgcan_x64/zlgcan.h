#ifndef ZLGCAN_H_
#define ZLGCAN_H_

#include <time.h>

#include "canframe.h"
#include "config.h"

#define ZCAN_PCI5121                        1
#define ZCAN_PCI9810                        2
#define ZCAN_USBCAN1                        3
#define ZCAN_USBCAN2                        4
#define ZCAN_PCI9820                        5
#define ZCAN_CAN232                         6
#define ZCAN_PCI5110                        7
#define ZCAN_CANLITE                        8
#define ZCAN_ISA9620                        9
#define ZCAN_ISA5420                        10
#define ZCAN_PC104CAN                       11
#define ZCAN_CANETUDP                       12
#define ZCAN_CANETE                         12
#define ZCAN_DNP9810                        13
#define ZCAN_PCI9840                        14
#define ZCAN_PC104CAN2                      15
#define ZCAN_PCI9820I                       16
#define ZCAN_CANETTCP                       17
#define ZCAN_PCIE_9220                      18
#define ZCAN_PCI5010U                       19
#define ZCAN_USBCAN_E_U                     20
#define ZCAN_USBCAN_2E_U                    21
#define ZCAN_PCI5020U                       22
#define ZCAN_EG20T_CAN                      23
#define ZCAN_PCIE9221                       24
#define ZCAN_WIFICAN_TCP                    25
#define ZCAN_WIFICAN_UDP                    26
#define ZCAN_PCIe9120                       27
#define ZCAN_PCIe9110                       28
#define ZCAN_PCIe9140                       29
#define ZCAN_USBCAN_4E_U                    31
#define ZCAN_CANDTU_200UR                   32
#define ZCAN_CANDTU_MINI                    33
#define ZCAN_USBCAN_8E_U                    34
#define ZCAN_CANREPLAY                      35
#define ZCAN_CANDTU_NET                     36
#define ZCAN_CANDTU_100UR                   37
#define ZCAN_PCIE_CANFD_100U                38
#define ZCAN_PCIE_CANFD_200U                39
#define ZCAN_PCIE_CANFD_400U                40
#define ZCAN_USBCANFD_200U                  41
#define ZCAN_USBCANFD_100U                  42
#define ZCAN_USBCANFD_MINI                  43
#define ZCAN_CANFDCOM_100IE                 44
#define ZCAN_CANSCOPE                       45
#define ZCAN_CLOUD                          46
#define ZCAN_CANDTU_NET_400                 47
#define ZCAN_CANFDNET_TCP                   48
#define ZCAN_CANFDNET_UDP                   49
#define ZCAN_CANFDWIFI_TCP                  50
#define ZCAN_CANFDWIFI_UDP                  51
#define ZCAN_CANFDNET_400U_TCP              52
#define ZCAN_CANFDNET_400U_UDP              53
#define ZCAN_CANFDBLUE_200U                 54
#define ZCAN_CANFDNET_100U_TCP              55
#define ZCAN_CANFDNET_100U_UDP              56

#define ZCAN_OFFLINE_DEVICE                 98
#define ZCAN_VIRTUAL_DEVICE                 99

#define ZCAN_ERROR_CAN_OVERFLOW             0x0001
#define ZCAN_ERROR_CAN_ERRALARM             0x0002
#define ZCAN_ERROR_CAN_PASSIVE              0x0004
#define ZCAN_ERROR_CAN_LOSE                 0x0008
#define ZCAN_ERROR_CAN_BUSERR               0x0010
#define ZCAN_ERROR_CAN_BUSOFF               0x0020
#define ZCAN_ERROR_CAN_BUFFER_OVERFLOW      0x0040

#define ZCAN_ERROR_DEVICEOPENED             0x0100
#define ZCAN_ERROR_DEVICEOPEN               0x0200
#define ZCAN_ERROR_DEVICENOTOPEN            0x0400
#define ZCAN_ERROR_BUFFEROVERFLOW           0x0800
#define ZCAN_ERROR_DEVICENOTEXIST           0x1000
#define ZCAN_ERROR_LOADKERNELDLL            0x2000
#define ZCAN_ERROR_CMDFAILED                0x4000
#define ZCAN_ERROR_BUFFERCREATE             0x8000

#define ZCAN_ERROR_CANETE_PORTOPENED        0x00010000
#define ZCAN_ERROR_CANETE_INDEXUSED         0x00020000
#define ZCAN_ERROR_REF_TYPE_ID              0x00030001
#define ZCAN_ERROR_CREATE_SOCKET            0x00030002
#define ZCAN_ERROR_OPEN_CONNECT             0x00030003
#define ZCAN_ERROR_NO_STARTUP               0x00030004
#define ZCAN_ERROR_NO_CONNECTED             0x00030005
#define ZCAN_ERROR_SEND_PARTIAL             0x00030006
#define ZCAN_ERROR_SEND_TOO_FAST            0x00030007

#define STATUS_ERR                          0
#define STATUS_OK                           1
#define STATUS_ONLINE                       2
#define STATUS_OFFLINE                      3
#define STATUS_UNSUPPORTED                  4

#define CMD_DESIP                           0
#define CMD_DESPORT                         1
#define CMD_CHGDESIPANDPORT                 2
#define CMD_SRCPORT                         2
#define CMD_TCP_TYPE                        4
#define TCP_CLIENT                          0
#define TCP_SERVER                          1

#define CMD_CLIENT_COUNT                    5
#define CMD_CLIENT                          6
#define CMD_DISCONN_CLINET                  7
#define CMD_SET_RECONNECT_TIME              8

#define TYPE_CAN                            0
#define TYPE_CANFD                          1
#define TYPE_ALL_DATA                       2

typedef void * DEVICE_HANDLE;
typedef void * CHANNEL_HANDLE;

typedef struct tagZCAN_DEVICE_INFO {
    USHORT hw_Version;
    USHORT fw_Version;
    USHORT dr_Version;
    USHORT in_Version;
    USHORT irq_Num;
    BYTE   can_Num;
    UCHAR  str_Serial_Num[20];
    UCHAR  str_hw_Type[40];
    USHORT reserved[4];
}ZCAN_DEVICE_INFO;

typedef struct tagZCAN_CHANNEL_INIT_CONFIG {
    UINT can_type;                          //type:TYPE_CAN TYPE_CANFD
    union
    {
        struct
        {
            UINT  acc_code;
            UINT  acc_mask;
            UINT  reserved;
            BYTE  filter;
            BYTE  timing0;
            BYTE  timing1;
            BYTE  mode;
        }can;
        struct
        {
            UINT   acc_code;
            UINT   acc_mask;
            UINT   abit_timing;
            UINT   dbit_timing;
            UINT   brp;
            BYTE   filter;
            BYTE   mode;
            USHORT pad;
            UINT   reserved;
        }canfd;
    };
}ZCAN_CHANNEL_INIT_CONFIG;

typedef struct tagZCAN_CHANNEL_ERR_INFO {
    UINT error_code;
    BYTE passive_ErrData[3];
    BYTE arLost_ErrData;
} ZCAN_CHANNEL_ERR_INFO;

typedef struct tagZCAN_CHANNEL_STATUS {
    BYTE errInterrupt;
    BYTE regMode;
    BYTE regStatus;
    BYTE regALCapture;
    BYTE regECCapture;
    BYTE regEWLimit;
    BYTE regRECounter;
    BYTE regTECounter;
    UINT Reserved;
}ZCAN_CHANNEL_STATUS;

typedef struct tagZCAN_Transmit_Data
{
    can_frame   frame;
    UINT        transmit_type;
}ZCAN_Transmit_Data;

typedef struct tagZCAN_Receive_Data
{
    can_frame   frame;
    UINT64      timestamp;                  //us
}ZCAN_Receive_Data;

typedef struct tagZCAN_TransmitFD_Data
{
    canfd_frame frame;
    UINT        transmit_type;
}ZCAN_TransmitFD_Data;

typedef struct tagZCAN_ReceiveFD_Data
{
    canfd_frame frame;
    UINT64      timestamp;                  //us
}ZCAN_ReceiveFD_Data;

typedef struct tagZCAN_AUTO_TRANSMIT_OBJ{
    USHORT enable;
    USHORT index;                           //0...n
    UINT   interval;                        //ms
    ZCAN_Transmit_Data obj;
}ZCAN_AUTO_TRANSMIT_OBJ, *PZCAN_AUTO_TRANSMIT_OBJ;

typedef struct tagZCANFD_AUTO_TRANSMIT_OBJ{
    USHORT enable;
    USHORT index;                           //0...n
    UINT interval;                          //ms
    ZCAN_TransmitFD_Data obj;
}ZCANFD_AUTO_TRANSMIT_OBJ, *PZCANFD_AUTO_TRANSMIT_OBJ;

//??????????????????????????, ??????????USBCANFD-X00U????????
typedef struct tagZCAN_AUTO_TRANSMIT_OBJ_PARAM
{
    USHORT index;                           // ????????????????
    USHORT type;                            // ??????????????????????1??????????????
    UINT   value;                           // ????????
}ZCAN_AUTO_TRANSMIT_OBJ_PARAM, *PZCAN_AUTO_TRANSMIT_OBJ_PARAM;

//for zlg cloud
#define ZCLOUD_MAX_DEVICES                  100
#define ZCLOUD_MAX_CHANNEL                  16

typedef struct tagZCLOUD_CHNINFO
{
    BYTE enable;                            // 0:disable, 1:enable
    BYTE type;                              // 0:CAN, 1:ISO CANFD, 2:Non-ISO CANFD
    BYTE isUpload;
    BYTE isDownload;
} ZCLOUD_CHNINFO;

typedef struct tagZCLOUD_DEVINFO
{
    int devIndex;           
    char type[64];
    char id[64];
    char name[64];
    char owner[64];
    char model[64];
    char fwVer[16];
    char hwVer[16];
    char serial[64];
    int status;                             // 0:online, 1:offline
    BYTE bGpsUpload;
    BYTE channelCnt;
    ZCLOUD_CHNINFO channels[ZCLOUD_MAX_CHANNEL];
}ZCLOUD_DEVINFO;

typedef struct tagZCLOUD_USER_DATA
{
    char username[64];
    char mobile[64];
    char dllVer[16];                        // cloud dll version
    size_t devCnt;
    ZCLOUD_DEVINFO devices[ZCLOUD_MAX_DEVICES];
}ZCLOUD_USER_DATA;

// GPS
typedef struct tagZCLOUD_GPS_FRAME
{
    float latitude;                         // + north latitude, - south latitude
    float longitude;                        // + east longitude, - west longitude           
    float speed;                            // km/h    
    struct __gps_time {
        USHORT    year;
        USHORT    mon;
        USHORT    day;
        USHORT    hour;
        USHORT    min;
        USHORT    sec;
    }tm;
} ZCLOUD_GPS_FRAME;
//for zlg cloud

//TX timestamp
typedef struct tagUSBCANFDTxTimeStamp
{
    UINT* pTxTimeStampBuffer;               //allocated by user, size:nBufferTimeStampCount * 4,unit:100us
    UINT  nBufferTimeStampCount;            //buffer size
}USBCANFDTxTimeStamp;

typedef struct tagTxTimeStamp
{
    UINT64* pTxTimeStampBuffer;             //allocated by user, size:nBufferTimeStampCount * 8,unit:1us
    UINT    nBufferTimeStampCount;          //buffer timestamp count
    int     nWaitTime;                      //Wait Time ms, -1????????????????????
}TxTimeStamp;

// Bus usage
typedef struct tagBusUsage
{
    UINT64  nTimeStampBegin;                //????????????????????us
    UINT64  nTimeStampEnd;                  //????????????????????us
    BYTE    nChnl;                          //????
    BYTE    nReserved;                      //????
    USHORT  nBusUsage;                      //??????????(%),??????????*100??????????0~10000????8050????80.50%
    UINT    nFrameCount;                    //??????
}BusUsage;

//LIN
typedef struct _VCI_LIN_MSG{
    BYTE    ID;
    BYTE    DataLen;
    USHORT  Flag;
    UINT    TimeStamp;
    BYTE    Data[8];
}ZCAN_LIN_MSG, *PZCAN_LIN_MSG;

#define LIN_MODE_MASTER                     0
#define LIN_MODE_SLAVE                      1
#define LIN_FLAG_CHK_ENHANCE                0x01
#define LIN_FLAG_VAR_DLC                    0x02

typedef struct _VCI_LIN_INIT_CONFIG
{
    BYTE    linMode;
    BYTE    linFlag;
    USHORT  reserved;
    UINT    linBaud;
}ZCAN_LIN_INIT_CONFIG, *PZCAN_LIN_INIT_CONFIG;
//end LIN

enum eZCANErrorDEF
{
    //????????????
    ZCAN_ERR_TYPE_NO_ERR                = 0,        //??????
    ZCAN_ERR_TYPE_BUS_ERR               = 1,        //????????
    ZCAN_ERR_TYPE_CONTROLLER_ERR        = 2,        //??????????
    ZCAN_ERR_TYPE_DEVICE_ERR            = 3,        //????????????

    //????????
    ZCAN_NODE_STATE_ACTIVE              = 1,        //????????
    ZCAN_NODE_STATE_WARNNING            = 2,        //????????
    ZCAN_NODE_STATE_PASSIVE             = 3,        //????????
    ZCAN_NODE_STATE_BUSOFF              = 4,        //????????

    //??????????????, errType = ZCAN_ERR_TYPE_BUS_ERR
    ZCAN_BUS_ERR_NO_ERR                 = 0,        //??????
    ZCAN_BUS_ERR_BIT_ERR                = 1,        //??????
    ZCAN_BUS_ERR_ACK_ERR                = 2,        //????????
    ZCAN_BUS_ERR_CRC_ERR                = 3,        //CRC????
    ZCAN_BUS_ERR_FORM_ERR               = 4,        //????????
    ZCAN_BUS_ERR_STUFF_ERR              = 5,        //????????
    ZCAN_BUS_ERR_OVERLOAD_ERR           = 6,        //????????
    ZCAN_BUS_ERR_ARBITRATION_LOST       = 7,        //????????

    //??????????, errType = ZCAN_ERR_TYPE_CONTROLLER_ERR
    ZCAN_CONTROLLER_RX_FIFO_OVERFLOW    = 1,        //??????????FIFO????
    ZCAN_CONTROLLER_DRIVER_RX_BUFFER_OVERFLOW  = 2, //????????????????
    ZCAN_CONTROLLER_DRIVER_TX_BUFFER_OVERFLOW  = 3, //????????????????
    ZCAN_CONTROLLER_INTERNAL_ERROR      = 4,        //??????????????

    //????????????, errType = ZCAN_ERR_TYPE_DEVICE_ERR
    ZCAN_DEVICE_APP_RX_BUFFER_OVERFLOW = 1,         //????????????????????
    ZCAN_DEVICE_APP_TX_BUFFER_OVERFLOW = 2,         //????????????????????
    ZCAN_DEVICE_APP_AUTO_SEND_FAILED   = 3,         //????????????
    ZCAN_CONTROLLER_TX_FRAME_INVALID   = 4,         //????????????
};

enum eZCANDataDEF
{
    //????????
    ZCAN_DT_ZCAN_CAN_CANFD_DATA     = 1,            // CAN/CANFD????
    ZCAN_DT_ZCAN_ERROR_DATA         = 2,            // ????????
    ZCAN_DT_ZCAN_GPS_DATA           = 3,            // GPS????
    ZCAN_DT_ZCAN_LIN_DATA           = 4,            // LIN????

    //????????????
    ZCAN_TX_DELAY_NO_DELAY          = 0,            // ??????????
    ZCAN_TX_DELAY_UNIT_MS           = 1,            // ????????????????
    ZCAN_TX_DELAY_UNIT_100US        = 2,            // ????????????100????(0.1????)

};

#pragma pack(push, 1)

// CAN/CANFD????
typedef struct tagZCANCANFDData
{
    UINT64          timeStamp;                      // ??????,??????????????????(us),??????????????,??????????????flag.unionVal.txDelay
    union
    {
        struct{
            UINT    frameType : 2;                  // ??????, 0:CAN??, 1:CANFD??
            UINT    txDelay : 2;                    // ????????????, ????????. 0:??????????, 1:????????????ms, 2:????????????100us. ????????????????????????????????timeStamp????
            UINT    transmitType : 4;               // ????????, ????????. 0:????????, 1:????????, 2:????????, 3:????????????. ????????????????????????????????????????????????
            UINT    txEchoRequest : 1;              // ????????????, ????????. ??????????????????,??????????????????1,??????????????????????????????????????????,????????????????????txEchoed??????
            UINT    txEchoed : 1;                   // ??????????????????, ????????. 0:????????????????, 1:??????????????????.
            UINT    reserved : 22;                  // ????
        }unionVal;
        UINT    rawVal;                             // ????????raw????
    }flag;                                          // CAN/CANFD????????
    BYTE        extraData[4];                       // ????????,????????
    canfd_frame frame;                              // can/canfd??ID+????
}ZCANCANFDData;

// ????????
typedef struct tagZCANErrorData
{
    UINT64  timeStamp;                              // ??????, ????????(us)
    BYTE    errType;                                // ????????, ????eZCANErrorDEF?? ???????????? ??????????
    BYTE    errSubType;                             // ??????????, ????eZCANErrorDEF?? ?????????????? ??????????
    BYTE    nodeState;                              // ????????, ????eZCANErrorDEF?? ???????? ??????????
    BYTE    rxErrCount;                             // ????????????
    BYTE    txErrCount;                             // ????????????
    BYTE    errData;                                // ????????, ??????????????????????????????????????????????, ??????????????????
    BYTE    reserved[2];                            // ????
}ZCANErrorData;

// GPS????
typedef struct tagZCANGPSData
{
    struct {
        USHORT  year;                               // ??
        USHORT  mon;                                // ??
        USHORT  day;                                // ??
        USHORT  hour;                               // ??
        USHORT  min;                                // ??
        USHORT  sec;                                // ??
        USHORT  milsec;                             // ????
    }           time;                               // UTC????
    union{
        struct{
            USHORT timeValid : 1;                   // ????????????????
            USHORT latlongValid : 1;                // ??????????????????
            USHORT altitudeValid : 1;               // ????????????????
            USHORT speedValid : 1;                  // ????????????????
            USHORT courseAngleValid : 1;            // ??????????????????
            USHORT reserved:13;                     // ????
        }unionVal;
        USHORT rawVal;
    }flag;                                          // ????????
    double latitude;                                // ???? ????????????, ????????????
    double longitude;                               // ???? ????????????, ????????????
    double altitude;                                // ???? ????: ??
    double speed;                                   // ???? ????: km/h
    double courseAngle;                             // ??????
} ZCANGPSData;

// LIN????
typedef struct tagZCANLINData
{
    UINT64          timeStamp;                      // ????????????????(us)
    union {
        struct {
            BYTE    ID:6;                           // ??ID
            BYTE    Parity:2;                       // ??ID????
        }unionVal;
        BYTE    rawVal;                             // ????????ID??????
    }       PID;                                    // ????????ID
    BYTE    dataLen;                                // ????????
    union{
        struct{
            USHORT tx : 1;                          // ????????????????????????, ????????
            USHORT rx : 1;                          // ??????????????????????, ????????
            USHORT noData : 1;                      // ????????
            USHORT chkSumErr : 1;                   // ??????????
            USHORT parityErr : 1;                   // ?????????????? ???????????? chksum ????
            USHORT syncErr : 1;                     // ?????????? 
            USHORT bitErr : 1;                      // ???????????? 
            USHORT wakeUp : 1;                      // ???????????? ???????? ID??????????????????????????????
            USHORT reserved : 8;                    // ????
        }unionVal;                                  // LIN??????????(????????)
        USHORT rawVal;                              // LIN??????????
    }flag;                                          // ????????
    BYTE    chkSum;                                 // ????????, ????????????????????????????
    BYTE    reserved[3];                            // ????
    BYTE    data[8];                                // ????
}ZCANLINData;

// ??????????????????????????CAN/CANFD/LIN/GPS/??????????????????
typedef struct tagZCANDataObj
{
    BYTE        dataType;                           // ????????, ????eZCANDataDEF?? ???????? ????????
    BYTE        chnl;                               // ????????
    union{
        struct{
            USHORT reserved : 16;                   // ????
        }unionVal;
        USHORT rawVal;
    }flag;                                          // ????????, ????????
    BYTE        extraData[4];                       // ????????, ????????
    union
    {
        ZCANCANFDData           zcanCANFDData;      // CAN/CANFD????
        ZCANErrorData           zcanErrData;        // ????????
        ZCANGPSData             zcanGPSData;        // GPS????
        ZCANLINData             zcanLINData;        // LIN????
        BYTE                    raw[92];            // RAW????
    } data;                                         // ????????, ???????????????????? dataType ????????
}ZCANDataObj;

#pragma pack(pop)

#ifdef __cplusplus 
#define DEF(a) = a
#else 
#define DEF(a)
#endif 

#define FUNC_CALL __stdcall
#ifdef __cplusplus
extern "C"
{
#endif

#define INVALID_DEVICE_HANDLE 0
DEVICE_HANDLE FUNC_CALL ZCAN_OpenDevice(UINT device_type, UINT device_index, UINT reserved);
UINT FUNC_CALL ZCAN_CloseDevice(DEVICE_HANDLE device_handle);
UINT FUNC_CALL ZCAN_GetDeviceInf(DEVICE_HANDLE device_handle, ZCAN_DEVICE_INFO* pInfo);

UINT FUNC_CALL ZCAN_IsDeviceOnLine(DEVICE_HANDLE device_handle);

#define INVALID_CHANNEL_HANDLE 0
CHANNEL_HANDLE FUNC_CALL ZCAN_InitCAN(DEVICE_HANDLE device_handle, UINT can_index, ZCAN_CHANNEL_INIT_CONFIG* pInitConfig);
UINT FUNC_CALL ZCAN_StartCAN(CHANNEL_HANDLE channel_handle);
UINT FUNC_CALL ZCAN_ResetCAN(CHANNEL_HANDLE channel_handle);
UINT FUNC_CALL ZCAN_ClearBuffer(CHANNEL_HANDLE channel_handle);
UINT FUNC_CALL ZCAN_ReadChannelErrInfo(CHANNEL_HANDLE channel_handle, ZCAN_CHANNEL_ERR_INFO* pErrInfo);
UINT FUNC_CALL ZCAN_ReadChannelStatus(CHANNEL_HANDLE channel_handle, ZCAN_CHANNEL_STATUS* pCANStatus);
UINT FUNC_CALL ZCAN_GetReceiveNum(CHANNEL_HANDLE channel_handle, BYTE type);//type:TYPE_CAN TYPE_CANFD
UINT FUNC_CALL ZCAN_Transmit(CHANNEL_HANDLE channel_handle, ZCAN_Transmit_Data* pTransmit, UINT len);
UINT FUNC_CALL ZCAN_Receive(CHANNEL_HANDLE channel_handle, ZCAN_Receive_Data* pReceive, UINT len, int wait_time DEF(-1));
UINT FUNC_CALL ZCAN_TransmitFD(CHANNEL_HANDLE channel_handle, ZCAN_TransmitFD_Data* pTransmit, UINT len);
UINT FUNC_CALL ZCAN_ReceiveFD(CHANNEL_HANDLE channel_handle, ZCAN_ReceiveFD_Data* pReceive, UINT len, int wait_time DEF(-1));

UINT FUNC_CALL ZCAN_TransmitData(DEVICE_HANDLE device_handle, ZCANDataObj* pTransmit, UINT len);
UINT FUNC_CALL ZCAN_ReceiveData(DEVICE_HANDLE device_handle, ZCANDataObj* pReceive, UINT len, int wait_time DEF(-1));
UINT FUNC_CALL ZCAN_SetValue(DEVICE_HANDLE device_handle, const char* path, const void* value);
const void* FUNC_CALL ZCAN_GetValue(DEVICE_HANDLE device_handle, const char* path);

IProperty* FUNC_CALL GetIProperty(DEVICE_HANDLE device_handle);
UINT FUNC_CALL ReleaseIProperty(IProperty * pIProperty);

void FUNC_CALL ZCLOUD_SetServerInfo(const char* httpSvr, unsigned short httpPort, const char* authSvr, unsigned short authPort);
// return 0:success, 1:failure, 2:https error, 3:user login info error, 4:mqtt connection error, 5:no device
UINT FUNC_CALL ZCLOUD_ConnectServer(const char* username, const char* password);
bool FUNC_CALL ZCLOUD_IsConnected();
// return 0:success, 1:failure
UINT FUNC_CALL ZCLOUD_DisconnectServer();
const ZCLOUD_USER_DATA* FUNC_CALL ZCLOUD_GetUserData(int update DEF(0));
UINT FUNC_CALL ZCLOUD_ReceiveGPS(DEVICE_HANDLE device_handle, ZCLOUD_GPS_FRAME* pReceive, UINT len, int wait_time DEF(-1));

CHANNEL_HANDLE FUNC_CALL ZCAN_InitLIN(DEVICE_HANDLE device_handle, UINT can_index, PZCAN_LIN_INIT_CONFIG pLINInitConfig);
UINT FUNC_CALL ZCAN_StartLIN(CHANNEL_HANDLE channel_handle);
UINT FUNC_CALL ZCAN_ResetLIN(CHANNEL_HANDLE channel_handle);
ULONG FUNC_CALL ZCAN_TransmitLIN(CHANNEL_HANDLE channel_handle, PZCAN_LIN_MSG pSend, ULONG Len);
ULONG FUNC_CALL ZCAN_GetLINReceiveNum(CHANNEL_HANDLE channel_handle);
ULONG FUNC_CALL ZCAN_ReceiveLIN(CHANNEL_HANDLE channel_handle, PZCAN_LIN_MSG pReceive, ULONG Len,int WaitTime);
UINT FUNC_CALL ZCAN_SetLINSlaveMsg(CHANNEL_HANDLE channel_handle, PZCAN_LIN_MSG pSend, UINT nMsgCount);
UINT FUNC_CALL ZCAN_ClearLINSlaveMsg(CHANNEL_HANDLE channel_handle, BYTE* pLINID, UINT nIDCount);

#ifdef __cplusplus
}
#endif

#endif //ZLGCAN_H_
