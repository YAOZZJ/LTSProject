using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocketServerTool.RequestInfo
{
    public class FinsTcpRequestInfo : IRequestInfo
    {
        #region "Fins"
        /*
             名称       大小     data                           备注
         1+ Header    +    4+ 46494E53+ 46494E53 + 46494E53 + FINS
         2|  Length   |    4|         | 0000001C | 0000001A | 20~2020
         3|  Command  |    4| 00000002| 00000002 |         2|
         4|  ErrorCode|    4| 00000000| 00000000 |         0| 不使用
         5|  ICF      |    1| 80      | 80       |        80|
         6|  RSV      |    1| 00      | 00       |         0|
         7|  GCT      |    1| 02      | 02       |         2|
         8|  DNA      |    1| 00      | 00       |         0| 00 为本地网络，1～127 为远程网络
         9|  DA1      |    1|         | 01       |         1| 目标地址（目标PLC 以太网IP 最后一位）
        10|  DA2      |    1|         | 00       |         0| 目标单元号 00 为CPU，如果是其他单元=HEX（10+Unit）
        11|  SNA      |    1|         | 00       |         0| 源网络
        12|  SA1      |    1|         | 0A       | 0A       | 源网络PLC 地址（本地PLC 以太网IP 最后一位）
        13|  SA2      |    1|         | 00       |         0| 源PLC 单元号
        14|  SID      |    1| 00      | 00       |         0|
        15+  MRC      +    1+         + 01       +         1+
        16+  SRC      +    1+         + 02       +         1+ 读:01 01 写01 02
        17|  Area     |    1|         | 82       |        82| DM(word)： 82,W(bit)： 31,W（word）： B1,CIO 区（bit）：
        18|  Address  |    3|         | 000000   |         0|
        19|  Number   |    2|         | 0001     |         2|
        20|  Data     |     |         | 000A     |          |
         
        public FinsTcpRequestInfo(byte[] header, byte[] body)
        {
            Header = header;
            Length[0] = body[00];
            Length[1] = body[01];
            Length[2] = body[02];
            Length[3] = body[03];
            Command[0] = body[04];
            Command[1] = body[05];
            Command[2] = body[06];
            Command[3] = body[07];
            ErrorCode[0] = body[08];
            ErrorCode[1] = body[09];
            ErrorCode[2] = body[10];
            ErrorCode[3] = body[11];
            ICF = body[12];
            RSV = body[13];
            GCT = body[14];
            DNA = body[15];
            DA1 = body[16];
            DA2 = body[17];
            SNA = body[18];
            SA1 = body[19];
            SA2 = body[20];
            SID = body[21];
            MRC = body[22];
            SRC = body[23];
            Area = body[24];
            Address[0] = body[25];
            Address[1] = body[26];
            Address[2] = body[27];
            Number[0] = body[28];
            Number[1] = body[29];

            for (int i = 29; i < body.Length; i++) Data[i - 29] = body[i];

        }
        */
        #region "Data"
        /*
    public byte[] Header { get; set; }
    public byte[] Length { get; set; }
    public byte[] Command { get; set; }
    public byte[] ErrorCode { get; set; }
    public byte ICF { get; set; }
    public byte RSV { get; set; }
    public byte GCT { get; set; }
    public byte DNA { get; set; }
    public byte DA1 { get; set; }
    public byte DA2 { get; set; }
    public byte SNA { get; set; }
    public byte SA1 { get; set; }
    public byte SA2 { get; set; }
    public byte SID { get; set; }
    public byte MRC { get; set; }
    public byte SRC { get; set; }
    public byte Area { get; set; }
    public byte[] Address { get; set; }
    public byte[] Number { get; set; }
    public byte[] Data { get; set; }

    public string Key => throw new NotImplementedException();
    */
        #endregion "Data"
        #endregion "Fins"
        public string Key => throw new NotImplementedException();
    }
}
