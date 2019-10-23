using SuperSocket.SocketBase.Protocol;

namespace MyToolkits.Socket.SuperSocketServer
{
    public class MyRequestInfo : IRequestInfo
    {
        public MyRequestInfo(byte[] header, byte[] body)
        {
            Key = ((header[0] * 256) + header[1]).ToString();
            Body = System.Text.Encoding.UTF8.GetString(body, 0, body.Length);
            IsHeart = string.Equals("2", Key);
        }
        public string Key { get; set; }

        public bool IsHeart { get; set; }

        public string Body { get; set; }
    }
}
