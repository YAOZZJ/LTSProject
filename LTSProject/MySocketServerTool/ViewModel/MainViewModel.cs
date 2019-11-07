using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MySocketServerTool.Services;
using MyToolkits.Log.TraceLog;
using MyToolkits.Unitities.Conversion;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace MySocketServerTool.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            _message = "";
            _messageAll = "";
            _inputText = "";
            _trace = new MyTraceListener();
            Trace.Listeners.Add(_trace);
            _trace.PropertyChanged += traceOnPropertyChanged;

            //_server = new SimpleServer();
            _bootstrap = new MyBootstrap();

        }

        #region "Action"
        void Action1()
        {
            //_server.Start();
            Task.Run
                (()=> 
                {
                    while(true)
                    {
                        _valuex[0] += 1.00;
                        Thread.Sleep(100);
                        TraceLog.WriteLine(_valuex[0].ToString());
                    }
                });
        }
        void Action2()
        {
            //_server.Stop();
        }
        void Action3()
        {
            byte[] a = { 1, 2, 3, 4, 15, 26, 37, 48 };
            byte[] b = { 1, 2, 3, 4 };

            TraceLog.WriteLine(Conversion.AryByteTo<int>(a,0,4).ToString());
        }
        void Action4()
        {
            Message(MethodBase.GetCurrentMethod().Name);
        }
        void Action5()
        {
            Message(MethodBase.GetCurrentMethod().Name);
        }
        void Action6()
        {
            Message(MethodBase.GetCurrentMethod().Name);
        }
        void Action7()
        {
            Message(MethodBase.GetCurrentMethod().Name);
        }
        void Message(string msg)
        {
            TraceLog.WriteLine(msg);
        }
        void traceOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Trace")
                MessageAll += _trace.Trace;
            try
            {
                MessageCurrent = _trace.Trace2.Split('|')[3];
            }
            catch (Exception) { }
        }
        #endregion

        #region "Variable"
        string _message;
        string _messageAll;
        string _inputText;
        MyTraceListener _trace;
        MyBootstrap _bootstrap;
        double[] _valuex = new double[16];
        double[] _valuey = new double[16];
        public string MessageCurrent { get => _message; set => Set(ref _message, value); }
        public string MessageAll { get => _messageAll; set => Set(ref _messageAll, value); }
        public string InputText { get => _inputText; set => Set(ref _inputText, value); }
        #endregion

        #region "Command"
        RelayCommand command1;
        RelayCommand command2;
        RelayCommand command3;
        RelayCommand command4;
        RelayCommand command5;
        RelayCommand command6;
        RelayCommand command7;
        public RelayCommand Command1 { get => command1 ?? (command1 = new RelayCommand(Action1)); set => command1 = value; }
        public RelayCommand Command2 { get => command2 ?? (command2 = new RelayCommand(Action2)); set => command2 = value; }
        public RelayCommand Command3 { get => command3 ?? (command3 = new RelayCommand(Action3)); set => command3 = value; }
        public RelayCommand Command4 { get => command4 ?? (command4 = new RelayCommand(Action4)); set => command4 = value; }
        public RelayCommand Command5 { get => command5 ?? (command5 = new RelayCommand(Action5)); set => command5 = value; }
        public RelayCommand Command6 { get => command6 ?? (command6 = new RelayCommand(Action6)); set => command6 = value; }
        public RelayCommand Command7 { get => command7 ?? (command7 = new RelayCommand(Action7)); set => command7 = value; }

        #endregion
    }
}