using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace MyToolkits.Log.TraceLog
{
    /// <summary>
    /// https://www.e-learn.cn/content/wangluowenzhang/48958
    /// </summary>
    public class MyTraceListener : TraceListener, INotifyPropertyChanged
    {
        //private readonly StringBuilder _builder;
        string _builder;
        string _builder2;

        public MyTraceListener()
        {
            //_builder = new StringBuilder();
            _builder = "";
            _builder2 = "";
        }

        //public string Trace => _builder.ToString();
        public string Trace => _builder;
        public string Trace2 => _builder2;

        public override void Write(string message)
        {
            //_builder.Append(message);
            _builder = message;
            _builder2 = message;
            OnPropertyChanged(new PropertyChangedEventArgs("Trace"));
        }

        public override void WriteLine(string message)
        {
            //_builder.AppendLine(message);
            _builder = message + "\r\n";
            _builder2 = message;
            OnPropertyChanged(new PropertyChangedEventArgs("Trace"));
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
        /*
         * 使用:
         MyTraceListener _trace;
         MyTraceListener _trace = new MyTraceListener();
         Trace.Listeners.Add(_trace);
         _trace.PropertyChanged += traceOnPropertyChanged;
         WeakEventManager.AddHandler(_trace, "PropertyChanged", traceOnPropertyChanged);
            private void traceOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Trace")
                MessageCurrrent = _trace.Trace2;
                OutputMessage += $"{DateTime.Now.ToString(" hh:mm:ss fff")} ◆◆ {_trace.Trace}";
        }
         */
    }
    #region 未使用
    //public class TextBoxTraceListener : TraceListener
    //{
    //    private TextBoxBase _control;
    //    private StringSendDelegate _invokeWrite;
    //    private delegate void StringSendDelegate(string msg);
    //    public TextBoxTraceListener(TextBoxBase target)
    //    {
    //        _control = target;

    //        _invokeWrite = new StringSendDelegate(SendString);
    //    }
    //    public override void Write(string message)
    //    {

    //        _control.Invoke(_invokeWrite, new object[] { message });

    //    }
    //    public override void WriteLine(string message)
    //    {

    //        _control.Invoke(_invokeWrite, new object[] { message + Environment.NewLine });
    //    }
    //    private void SendString(string msg)
    //    {
    //        // No need to lock control as this function will only 
    //        // ever be executed from the UI thread
    //        _control.Text += msg;

    //    }
    //}
    //public class MyTraceListener : TraceListener
    //{
    //    private TextBoxBase output;

    //    public MyTraceListener(TextBoxBase output)
    //    {
    //        this.Name = "Trace";
    //        this.output = output;
    //    }


    //    public override void Write(string message)
    //    {

    //        Action append = delegate () {
    //            output.AppendText(string.Format("[{0}] ", DateTime.Now.ToString()));
    //            output.AppendText(message);
    //        };
    //        if (output.InvokeRequired)
    //        {
    //            output.BeginInvoke(append);
    //        }
    //        else
    //        {
    //            append();
    //        }

    //    }

    //    public override void WriteLine(string message)
    //    {
    //        Write(message + Environment.NewLine);
    //    }
    //}
    #endregion
}
