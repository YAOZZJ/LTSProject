using MyToolkits.Log.Base;
using NLog;
using System;
using System.Collections.Generic;

namespace MyToolkits.Log.NLogService
{
    public class NLogService : ILog
    {
        NLog.Logger _logger;
        LogEventInfo _Info;
        string _source;
        string _loggername;
        public void Initial()
        {
            _source = "Default source";
            _loggername = "Default logger";
            _logger = NLog.LogManager.GetCurrentClassLogger();
            _Info = new LogEventInfo();
            _Info.Level = LogLevel.Trace;
            _Info.LoggerName = _loggername;
        }
        public void Initial(string source, string logger = null)
        {
            _source = source;
            _loggername = logger;
        }
        public List<T> GetLog<T>() { throw new NotImplementedException(); }
        public void Stop() { }
        public void Restart() { }
        public string Status() { throw new NotImplementedException(); }
        public void Trace(string msg, int msgid = 0, string detail = null)
        {
            _Info.Level = LogLevel.Trace;
            _Info.Message = msg;
            _Info.Properties["MessageID"] = msgid;
            _Info.Properties["SourceDetails"] = detail;
            _logger.Info(_Info);
        }
        public void Debug(string msg, int msgid = 0, string detail = null)
        {
            _Info.Level = LogLevel.Debug;
            _Info.Message = msg;
            _Info.Properties["MessageID"] = msgid;
            _Info.Properties["SourceDetails"] = detail;
            _logger.Info(_Info);
        }
        public void Info(string msg, int msgid = 0, string detail = null)
        {
            _Info.Level = LogLevel.Info;
            _Info.Message = msg;
            _Info.Properties["MessageID"] = msgid;
            _Info.Properties["SourceDetails"] = detail;
            _logger.Info(_Info);
        }
        public void Warn(string msg, int msgid = 0, string detail = null)
        {
            _Info.Level = LogLevel.Warn;
            _Info.Message = msg;
            _Info.Properties["MessageID"] = msgid;
            _Info.Properties["SourceDetails"] = detail;
            _logger.Info(_Info);
        }
        public void Error(string msg, int msgid = 0, string detail = null)
        {
            _Info.Level = LogLevel.Error;
            _Info.Message = msg;
            _Info.Properties["MessageID"] = msgid;
            _Info.Properties["SourceDetails"] = detail;
            _logger.Info(_Info);
        }
        public void Fatal(string msg, int msgid = 0, string detail = null)
        {
            _Info.Level = LogLevel.Fatal;
            _Info.Message = msg;
            _Info.Properties["MessageID"] = msgid;
            _Info.Properties["SourceDetails"] = detail;
            _logger.Info(_Info);
        }

        public void Dispose()
        {

        }
    }

}
