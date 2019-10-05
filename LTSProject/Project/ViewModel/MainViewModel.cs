using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Diagnostics;
using System.Text;

namespace Project.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            MessageCurrrent = "Open";
        }
        private StringBuilder _message;
        private string _messageCurrrent;

        public StringBuilder Message { get => _message; set => Set(ref _message,value); }
        public string MessageCurrrent { get => _messageCurrrent; set => Set(ref _messageCurrrent, value); }
        public RelayCommand MainCommand1 { get => mainCommand1 ?? (mainCommand1 = new RelayCommand(Action1)); set => mainCommand1 = value; }
        public RelayCommand MainCommand2 { get => mainCommand2 ?? (mainCommand2 = new RelayCommand(Action2)); set => mainCommand2 = value; }
        public RelayCommand MainCommand3 { get => mainCommand3 ?? (mainCommand3 = new RelayCommand(Action3)); set => mainCommand3 = value; }
        public RelayCommand MainCommand4 { get => mainCommand4 ?? (mainCommand4 = new RelayCommand(Action4)); set => mainCommand4 = value; }
        public RelayCommand MainCommand5 { get => mainCommand5 ?? (mainCommand5 = new RelayCommand(Action5)); set => mainCommand5 = value; }
        public RelayCommand MainCommand6 { get => mainCommand6 ?? (mainCommand6 = new RelayCommand(Action6)); set => mainCommand6 = value; }

        private RelayCommand mainCommand1;
        private RelayCommand mainCommand2;
        private RelayCommand mainCommand3;
        private RelayCommand mainCommand4;
        private RelayCommand mainCommand5;
        private RelayCommand mainCommand6;
        private void Action1() 
        {
        }
        private void Action2() { }
        private void Action3() { }
        private void Action4() { }
        private void Action5() { }
        private void Action6() { }
    }
}