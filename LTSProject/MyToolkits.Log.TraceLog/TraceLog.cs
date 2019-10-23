using MyToolkits.Log.Base;
using System;
using System.Collections.Generic;

namespace MyToolkits.Log.TraceLog
{
    public class TraceLog : ILog
    {
        #region "ILog"
        public void Debug(string msg, int msgid = 0, string detail = null)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Error(string msg, int msgid = 0, string detail = null)
        {
            throw new NotImplementedException();
        }

        public void Fatal(string msg, int msgid = 0, string detail = null)
        {
            throw new NotImplementedException();
        }

        public List<T> GetLog<T>()
        {
            throw new NotImplementedException();
        }

        public void Info(string msg, int msgid = 0, string detail = null)
        {
            throw new NotImplementedException();
        }

        public void Initial()
        {
            throw new NotImplementedException();
        }

        public void Initial(string source, string logger = null)
        {
            throw new NotImplementedException();
        }

        public void Restart()
        {
            throw new NotImplementedException();
        }

        public string Status()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void Trace(string msg, int msgid = 0, string detail = null)
        {
            throw new NotImplementedException();
        }

        public void Warn(string msg, int msgid = 0, string detail = null)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region "User"
        public static void OutputTrace(string msg, string level = "Info", string logger = "Default")
        {
            System.Diagnostics.Trace.WriteLine(LogFormat(msg, level, logger));
        }
        public static void OutputDebug(string msg, string level = "Info", string logger = "Default")
        {
            System.Diagnostics.Debug.WriteLine(LogFormat(msg, level, logger));
        }
        public static void Output(string msg, string level = "Info", string logger = "Default")
        {
            System.Diagnostics.Debug.WriteLine(LogFormat(msg, level, logger));
        }
        static string LogFormat(string msg, string level = "Info", string logger = "Default")
        {
            return $"{DateTime.Now.ToString(" HH:mm:ss:ms")} | {level} | {logger} | {msg}";
        }
        #endregion
    }
}
