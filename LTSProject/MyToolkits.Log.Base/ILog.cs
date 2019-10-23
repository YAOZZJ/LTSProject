using System;
using System.Collections.Generic;
using System.Text;

namespace MyToolkits.Log.Base
{
    public interface ILog : IDisposable
    {
        /// <summary>
        /// 初始化
        /// </summary>
        void Initial();
        void Initial(string source, string logger = null);
        List<T> GetLog<T>();
        void Stop();
        void Restart();
        string Status();
        void Trace(string msg, int msgid = 0, string detail = null);
        void Debug(string msg, int msgid = 0, string detail = null);
        void Info(string msg, int msgid = 0, string detail = null);
        void Warn(string msg, int msgid = 0, string detail = null);
        void Error(string msg, int msgid = 0, string detail = null);
        void Fatal(string msg, int msgid = 0, string detail = null);
    }
}
