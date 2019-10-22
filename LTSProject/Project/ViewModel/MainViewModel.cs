using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Project.Unitities.File;
using Project.Unitities.Log;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;

namespace Project.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            //WeakEventManager.AddHandler(_trace, "PropertyChanged", traceOnPropertyChanged);
            _trace.PropertyChanged += traceOnPropertyChanged;
            Trace.Listeners.Add(_trace);
            TraceLog.Output("Initialized");
        }
        private string _message;
        private string _messageCurrrent;
        readonly MyTraceListener _trace = new MyTraceListener();

        public string OutputMessage { get => _message; set => Set(ref _message,value); }
        public string MessageCurrrent { get => _messageCurrrent; set => Set(ref _messageCurrrent, value); }
        public RelayCommand MainCommand1 { get => mainCommand1 ?? (mainCommand1 = new RelayCommand(Action1)); }
        public RelayCommand MainCommand2 { get => mainCommand2 ?? (mainCommand2 = new RelayCommand(Action2)); }
        public RelayCommand MainCommand3 { get => mainCommand3 ?? (mainCommand3 = new RelayCommand(Action3)); }
        public RelayCommand MainCommand4 { get => mainCommand4 ?? (mainCommand4 = new RelayCommand(Action4)); }
        public RelayCommand MainCommand5 { get => mainCommand5 ?? (mainCommand5 = new RelayCommand(Action5)); }
        public RelayCommand MainCommand6 { get => mainCommand6 ?? (mainCommand6 = new RelayCommand(Action6)); }
        public RelayCommand OutputCommand1 { get => outputCommand1 ?? (outputCommand1 = new RelayCommand(OutputAction1));}
        public RelayCommand OutputCommand2 { get => outputCommand2 ?? (outputCommand2 = new RelayCommand(OutputAction2));}

        private RelayCommand mainCommand1;
        private RelayCommand mainCommand2;
        private RelayCommand mainCommand3;
        private RelayCommand mainCommand4;
        private RelayCommand mainCommand5;
        private RelayCommand mainCommand6;

        private RelayCommand outputCommand1;
        private RelayCommand outputCommand2;
        private void Action1() 
        {
            TraceLog.Output("Action1");
        }
        private void Action2() 
        {
            TraceLog.Output("Action2");
        }
        private void Action3() { }
        private void Action4() { }
        private void Action5() { }
        private void Action6() { }
        private void OutputAction1() 
        {
            OutputMessage = string.Empty;
        }
        private void OutputAction2()
        {
            OutputMessage +=DateTime.Now.ToString() + "\r\n";
        }

        private void traceOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Trace")
                MessageCurrrent = _trace.Trace2.Split('|')[3];
            OutputMessage += _trace.Trace;
                //OutputMessage += $"{DateTime.Now.ToString(" hh:mm:ss fff")} ¡ô¡ô {_trace.Trace}";
        }
    }
}