using MySocketServerTool.RequestInfo;
using SuperSocket.Facility.Protocol;
using System;
using System.Linq;

namespace MySocketServerTool.Filter
{
    public class FinsTcpReceiveFilter : FixedHeaderReceiveFilter<FinsTcpRequestInfo>
    {
        /// <summary>
        /// "FINS" + 4byte的长度数据
        /// </summary>
        public FinsTcpReceiveFilter() : base(8){}
        /// <summary>
        /// 解析消息中长度;
        /// 根据这个长度来帮助我们获取到打包的数据;
        /// 然后传给方法ResolveRequestInfo。
        /// </summary>
        /// <param name="header">header 缓存的数据</param>
        /// <param name="offset">获取数据长度偏移位置</param>
        /// <param name="length">base(8)</param>
        /// <returns></returns>
        protected override int GetBodyLengthFromHeader(byte[] header, int offset, int length)
        {
            //var bodyLength = (int)header[offset + 4] * 256 ^ 3 + (int)header[offset + 5] * 256 ^ 2 + (int)header[offset + 6] * 256 + (int)header[offset + 7];
            var bodyLength = (int)header[offset + 6] * 256 + (int)header[offset + 7];
            //var bodyLength = (int)header[offset + 4] << 24 + (int)header[offset + 5] << 16 + (int)header[offset + 6] << 8 + (int)header[offset + 7];
            return bodyLength;
        }
        /// <summary>
        /// 解析收到的数据
        /// </summary>
        /// <param name="header">协议头的数据</param>
        /// <param name="bodyBuffer">bodyBuffer 缓存的数据，这个并不是只单纯包含打包数据的</param>
        /// <param name="offset">offset 打包数据在bodyBuffer里面开始的位置</param>
        /// <param name="length">打包数据的长度</param>
        /// <returns></returns>
        protected override FinsTcpRequestInfo ResolveRequestInfo(ArraySegment<byte> header, byte[] bodyBuffer, int offset, int length)
        {
            if (bodyBuffer == null) return null;
            var body = bodyBuffer.Skip(offset).Take(length).ToArray();
            var info = new FinsTcpRequestInfo(header.ToArray(), body);
            return info;
        }
    }
}
