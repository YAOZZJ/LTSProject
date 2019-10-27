//using MyToolkits.Unitities.Conversion;
using SuperSocket.SocketBase.Protocol;
using System.Text;

namespace MySocketServerTool.RequestInfo
{
    /// <summary>
    /// 把ReceiveFilter解析的数据拆分,解析
    /// </summary>
    public class FinsTcpRequestInfo : IRequestInfo
    {
        /*
             名称       大小     data                           备注
         1+ Header    +    4+ 46494E53+ 46494E53 + 46494E53 + FINS
         2|  Length   |    4|         | 0000001C | 0000001A | 20~2020
         3|  Command  |    4| 00000002| 00000002 |  00000002|
         4|  ErrorCode|    4| 00000000| 00000000 |  00000000| 不使用
         5|  ICF      |    1| 80      | 80       |        80|
         6|  RSV      |    1| 00      | 00       |        00|
         7|  GCT      |    1| 02      | 02       |        02|
         8|  DNA      |    1| 00      | 00       |        00| 00 为本地网络，1～127 为远程网络
         9|  DA1      |    1|         | 01       |        01| 目标地址（目标PLC 以太网IP 最后一位）
        10|  DA2      |    1|         | 00       |        00| 目标单元号 00 为CPU，如果是其他单元=HEX（10+Unit）
        11|  SNA      |    1|         | 00       |        00| 源网络
        12|  SA1      |    1|         | 0A       |        0A| 源网络PLC 地址（本地PLC 以太网IP 最后一位）
        13|  SA2      |    1|         | 00       |        00| 源PLC 单元号
        14|  SID      |    1| 00      | 00       |        00|
        15+  MRC      +    1+         + 01       +        01+
        16+  SRC      +    1+         + 02       +        01+ 读:01 01 写01 02
        17|  Area     |    1|         | 82       |        82| DM(word)： 82,W(bit)： 31,W（word）： B1,CIO 区（bit）：
        18|  Address  |    3|         | 000000   |    000000|
        19|  Number   |    2|         | 0001     |      0002|
        20|  Data     |     |         | 000A     |          |
        */
        public FinsTcpRequestInfo(byte[] header, byte[] body)
        {
            Header       = new byte[4];
            Length       = new byte[4];
            Command      = new byte[4];
            ErrorCode    = new byte[4];
            Address      = new byte[3];
            Number       = new byte[2];

            Header[0]    =  header[00];
            Header[1]    =  header[01];
            Header[2]    =  header[02];
            Header[3]    =  header[03];

            if (Encoding.Default.GetString(Header) != "FINS") { Key = "UnRegisteredCMD"; return; }

            Length[0]    =  header[04];
            Length[1]    =  header[05];
            Length[2]    =  header[06];
            Length[3]    =  header[07];
            Command[0]   =  body[00];
            Command[1]   =  body[01];
            Command[2]   =  body[02];
            Command[3]   =  body[03];
            ErrorCode[0] =  body[04];
            ErrorCode[1] =  body[05];
            ErrorCode[2] =  body[06];
            ErrorCode[3] =  body[07];

            switch(Command[3])//准确来说应该是Conversion.AryByteTo<int>(Command)
            {
                case 0: Key = "FinsHandShaking";return;
                case 2: Key = "FinsRWData";break;
                default: Key = "UnRegisteredCMD";return;
            }

            if (body.Length < 26) { Key = "UnRegisteredCMD"; return; }

            ICF =  body[08];
            RSV          =  body[09];
            GCT          =  body[10];
            DNA          =  body[11];
            DA1          =  body[12];
            DA2          =  body[13];
            SNA          =  body[14];
            SA1          =  body[15];
            SA2          =  body[16];
            SID          =  body[17];
            MRC          =  body[18];
            SRC          =  body[19];
            Area         =  body[20];
            Address[0]   =  body[21];
            Address[1]   =  body[22];
            Address[2]   =  body[23];
            Number[0]    =  body[24];
            Number[1]    =  body[25];

            Data = new byte[body.Length - 26];
            for (int i = 26;i < body.Length; i++) Data[i - 26] = body[i];

            //Key = "FINS";
            //Body = body;
        }
        public string  Key       {get;set;}
        public byte[]  Body      {get;set;}
        public byte[]  Header    {get;set;}
        public byte[]  Length    {get;set;}
        public byte[]  Command   {get;set;}
        public byte[]  ErrorCode {get;set;}
        public byte    ICF       {get;set;}
        public byte    RSV       {get;set;}
        public byte    GCT       {get;set;}
        public byte    DNA       {get;set;}
        public byte    DA1       {get;set;}
        public byte    DA2       {get;set;}
        public byte    SNA       {get;set;}
        public byte    SA1       {get;set;}
        public byte    SA2       {get;set;}
        public byte    SID       {get;set;}
        public byte    MRC       {get;set;}
        public byte    SRC       {get;set;}
        public byte    Area      {get;set;}
        public byte[]  Address   {get;set;}
        public byte[]  Number    {get;set;}
        public byte[]  Data      {get;set;}

    }
    public enum MemoryArea
    {
        CIOBit                       = 0x30,
        WRBit                        = 0x31,
        HRBit                        = 0x32,
        ARBit                        = 0x33,
        CIOWord                      = 0xb0,
        WRWord                       = 0xb1,
        HRWord                       = 0xb2,
        ARWord                       = 0xb3,
        TimerCounterCompletionFlag   = 0x09,
        TimerCounterPV               = 0x89,
        DMBit                        = 0x02,
        DMWord                       = 0x82,
        TaskBit                      = 0x06,
        TaskStatus                   = 0x46,
        IndexRegisterPV              = 0xdc,
        DataRegisterPV               = 0xbc,
        ClockPulsesConditionFlagsBit = 0x07
    }
}
