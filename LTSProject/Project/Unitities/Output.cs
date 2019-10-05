using System.Text;

namespace Project.Unitities
{
    public class Output
    {
        public Output()
        {
            MessageDetail = new StringBuilder();
        }
        public void Message(string message)
        {
            _messageDetail.Insert(0, message);
        }
        private StringBuilder _messageDetail;

        public StringBuilder MessageDetail { get => _messageDetail; set => _messageDetail = value; }
    }
}
