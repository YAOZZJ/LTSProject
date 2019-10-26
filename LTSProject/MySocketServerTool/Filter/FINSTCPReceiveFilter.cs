using MySocketServerTool.PackageInfo;
using SuperSocket.ProtoBase;
using System;
using System.Linq;

namespace MySocketServerTool.Filter
{
    public class FinsTcpReceiveFilter : FixedHeaderReceiveFilter<FinsTcpPackageInfo>
    {
        public FinsTcpReceiveFilter() : base(4)//"FINS"
        {

        }
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
    }
}
