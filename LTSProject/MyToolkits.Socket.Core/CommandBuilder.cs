using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyToolkits.Socket.Core
{
    //数据格式：
    //  -------+----------+------------------------------------------------------+
    //  0001   | 0010     |  4C36 3150 2D43 4D2B 4C30 3643 5055 2D43 4D2B 4C 4A  |
    //  固定头 | 数据长度 |  数据                                                |
    //         |          |                                                      |
    //  -------+----------+------------------------------------------------------+

    public class CommandBuilder
    {
        //消息包头部为01
        const ushort HeartMsg = 1;
        //心跳包头部为02
        const ushort HeaderHeart = 2;

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static byte[] BuildMsgCmd(string msg)
        {
            var arr = new List<byte> { };
            //转为byte数组并进行大小端转换
            var byteHeader = BitConverter.GetBytes(HeartMsg).Reverse().ToList();
            var byteMsg = Encoding.UTF8.GetBytes(msg);
            var byteLength = BitConverter.GetBytes((ushort)byteMsg.Length).Reverse().ToList();

            arr.AddRange(byteHeader);
            arr.AddRange(byteLength);
            arr.AddRange(byteMsg);
            return arr.ToArray();
        }
        /// <summary>
        /// 发送心跳
        /// </summary>
        /// <returns></returns>
        public static byte[] BuildHeartCmd()
        {
            var arr = new List<byte> { };
            //心跳内容部分传输当前时间
            var byteMsg = Encoding.UTF8.GetBytes(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            //转为byte数组并进行大小端转换
            var byteHeader = BitConverter.GetBytes(HeaderHeart).Reverse().ToList();
            var byteLength = BitConverter.GetBytes((ushort)byteMsg.Length).Reverse().ToList();

            arr.AddRange(byteHeader);
            arr.AddRange(byteLength);
            arr.AddRange(byteMsg);
            return arr.ToArray();
        }
    }
}
