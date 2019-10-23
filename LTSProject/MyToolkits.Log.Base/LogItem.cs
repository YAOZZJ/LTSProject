using System;
using System.Collections.Generic;
using System.Text;

namespace MyToolkits.Log.Base
{
    public class LogItem
    {
        //public DateTime Time { get; set; }
        private string time;
        public string Time { get => time; set => time = value; }
        public string Level { get; set; }
        public string Threadname { get; set; }
        public string Source { get; set; }
        public string SourceDetails { get; set; }
        public string Message { get; set; }
        public uint MessageID { get; set; }
        public string Logger { get; set; }
        public string CallSite { get; set; }
        public string Exception { get; set; }
        public LogItem()
        {

        }

        public LogItem(LogItem item)
        {
            Time = item.Time;
            Level = item.Level;
            Threadname = item.Threadname;
            Source = item.Source;
            SourceDetails = item.SourceDetails;
            Message = item.Message;
            MessageID = item.MessageID;
            Logger = item.Logger;
            CallSite = item.CallSite;
            Exception = item.Exception;
        }
    }
}
