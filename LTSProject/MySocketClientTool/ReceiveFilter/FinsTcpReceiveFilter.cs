using MySocketClientTool.PackageInfo;
using SuperSocket.ProtoBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocketClientTool.ReceiveFilter
{
    public class FinsTcpReceiveFilter : FixedHeaderReceiveFilter<FinsTcpPackageInfo>
    {
        /// <summary>
        /// "FINS" + 4byte的长度数据
        /// </summary>
        public FinsTcpReceiveFilter() : base(8) { }
        /// <summary>
        /// 解析收到的数据
        /// </summary>
        /// <param name="bufferStream"></param>
        /// <returns></returns>
        public override FinsTcpPackageInfo ResolvePackage(IBufferStream bufferStream)
        {
            byte[] header = bufferStream.Buffers[0].ToArray();
            byte[] bodyBuffer = bufferStream.Buffers[1].ToArray();
            var package = new FinsTcpPackageInfo(header, bodyBuffer);
            return package;
        }
        /// <summary>
        /// 解析消息中长度
        /// </summary>
        /// <param name="bufferStream"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        protected override int GetBodyLengthFromHeader(IBufferStream bufferStream, int length)
        {
            ArraySegment<byte> buffers = bufferStream.Buffers[0];
            byte[] array = buffers.ToArray();
            int bodyLength = array[length - 2] * 256 + array[length - 1];
            return bodyLength;
        }
    }
}
