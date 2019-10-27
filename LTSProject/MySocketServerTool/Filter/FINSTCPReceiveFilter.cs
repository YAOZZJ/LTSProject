using MySocketServerTool.RequestInfo;
using MyToolkits.Log.TraceLog;
using SuperSocket.Common;
using SuperSocket.Facility.Protocol;
using System;
using System.Linq;
using System.Text;

namespace MySocketServerTool.Filter
{
    public class FinsTcpReceiveFilter : FixedHeaderReceiveFilter<FinsTcpRequestInfo>
    {
        public FinsTcpReceiveFilter() : base(8)//"FINS"
        {

        }
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
            //var bodyLength = (int)header[offset + 4] * 256^3 + (int)header[offset + 5] * 256^2 + (int)header[offset + 6] * 256 + (int)header[offset + 7];
            var bodyLength = (int)header[offset + 6] * 256 + (int)header[offset + 7];
            //return bodyLength;
            var headerData = new byte[4];
            //Array.Copy(header, offset + 4, headerData, 0, 4);
            //var bodyLength = BitConverter.ToInt32(headerData, 0);
            //TraceLog.Output(bodyLength.ToString());
            //foreach (var a in headerData) TraceLog.WriteLine(a.ToString());
            //var bodyLength = (int)((header[offset + 4] & 0xFF)
            //        | ((header[offset + 5] & 0xFF) << 8)
            //        | ((header[offset + 6] & 0xFF) << 16)
            //        | ((header[offset + 7] & 0xFF) << 24));
            return bodyLength;
        }
        /// <summary>
        /// 
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
            TraceLog.WriteLine("offset " + offset.ToString());
            TraceLog.WriteLine("length " + length.ToString());
            return info;
        }
        /* FINS
//解析收到的数据
public override FinsTcpPackageInfo ResolvePackage(IBufferStream bufferStream)
{
   byte[] header = bufferStream.Buffers[0].ToArray();
   byte[] bodyBuffer = bufferStream.Buffers[1].ToArray();
   var package = new FinsTcpPackageInfo(header, bodyBuffer);
   return package;
}
//解析消息中长度
protected override int GetBodyLengthFromHeader(IBufferStream bufferStream, int length)
{
   throw new NotImplementedException();
}
*/
    }
}
