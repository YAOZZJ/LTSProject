using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NLog.Fluent;
using Project.Control;
using Project.Model;
using Project.Unitities;
using Project.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Project.ViewModel
{
    public class DebugViewModel : ViewModelBase
    {
        public DebugViewModel()
        {
            debugModel = new DebugModel();
            debugModel.PropertyChanged += DebugModel_PropertyChanged;
        }

        private void DebugModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "Text2")
            {
                RaisePropertyChanged(nameof(TxtDebug2));
            }
        }

        public DebugModel debugModel;
        private string txtDebug1;
        private string txtDebug2;
        private string txtDebug3;
        public string TxtDebug1 { get => txtDebug1; set => Set(ref txtDebug1, value); }
        //public string TxtDebug2 { get => txtDebug2; set => txtDebug2 = value; }
        public string TxtDebug2 
        { 
            get => debugModel.Text2;
            set { debugModel.Text2 = value;RaisePropertyChanged(nameof(TxtDebug2)); } 
        }
        public string TxtDebug3 { get => txtDebug3; set => txtDebug3 = value; }
        

        #region "Command"
        private RelayCommand btnDebug1Command;
        private RelayCommand btnDebug2Command;
        private RelayCommand btnDebug3Command;
        private RelayCommand btnDebug4Command;
        private RelayCommand btnDebug5Command;
        private RelayCommand btnDebug6Command;
        public RelayCommand BtnDebug1Command
        {
            get
            {
                if(btnDebug1Command == null)
                {
                    btnDebug1Command = new RelayCommand(debugModel.Command1);
                }
                return btnDebug1Command;
            } 
            set => btnDebug1Command = value;
        }
        public RelayCommand BtnDebug2Command
        {
            get
            {
                if (btnDebug2Command == null)
                {
                    btnDebug2Command = new RelayCommand(debugModel.Command2);
                }
                return btnDebug2Command;
            }
            set => btnDebug2Command = value;
        }
        public RelayCommand BtnDebug3Command
        {
            get
            {
                if (btnDebug3Command == null)
                {
                    btnDebug3Command = new RelayCommand(debugModel.Command3);
                }
                return btnDebug3Command;
            }
            set => btnDebug3Command = value;
        }
        public RelayCommand BtnDebug4Command
        {
            get
            {
                if (btnDebug4Command == null)
                {
                    btnDebug4Command = new RelayCommand(BtnDebug4Action);
                }
                return btnDebug4Command;
            }
            set => btnDebug4Command = value;
        }
        public RelayCommand BtnDebug5Command
        {
            get
            {
                if (btnDebug5Command == null)
                {
                    btnDebug5Command = new RelayCommand(BtnDebug5Action);
                }
                return btnDebug5Command;
            }
            set => btnDebug5Command = value;
        }
        public RelayCommand BtnDebug6Command
        {
            get => btnDebug6Command ?? (btnDebug6Command = new RelayCommand(BtnDebug6Action)); 
            set => btnDebug6Command = value;
        }
        

        private void BtnDebug1Action()
        {
            Debug.WriteLine("Btn1");
        }
        private void BtnDebug2Action() 
        {
            Debug.WriteLine("Btn2");

        }
        private void BtnDebug3Action()
        {
            Debug.WriteLine("Btn3");

        }
        private void BtnDebug4Action()
        {
            Debug.WriteLine("Btn4");
            Debug.WriteLine(TxtDebug2);
        }
        private void BtnDebug5Action()
        { 
            Debug.WriteLine("Btn5");
            TxtDebug1 += "233";
        }
        private void BtnDebug6Action()
        {
            Debug.WriteLine("Btn6");
            Debug.WriteLine(TxtDebug1);

        }

        #endregion

    }
}
