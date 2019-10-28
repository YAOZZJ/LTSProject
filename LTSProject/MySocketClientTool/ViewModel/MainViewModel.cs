using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MySocketClientTool.Client;
using MyToolkits.Log.TraceLog;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows;

namespace MySocketClientTool.ViewModel
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

            //client = new MyClient();
            client = new FinsTcpClient();

        }
        #region "Action"
        void Action1()
        {
            client.Connect();
        }
        void Action2()
        {
            client.Close();
        }
        void Action3()
        {
            Message(MethodBase.GetCurrentMethod().Name);
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
            TraceLog.Output(msg);
        }
        void traceOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Trace")
                MessageAll += _trace.Trace;
            MessageCurrent = _trace.Trace2.Split('|')[3];
        }
        #endregion
        #region "Variable"
        string _message;
        string _messageAll;
        string _inputText;
        MyTraceListener _trace;
        //MyClient client;
        FinsTcpClient client;
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