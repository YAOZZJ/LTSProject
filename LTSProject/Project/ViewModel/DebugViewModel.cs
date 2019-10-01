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
        }
        #region "Command"
        private RelayCommand btnDebug1Command;
        private RelayCommand btnDebug2Command;
        private RelayCommand btnDebug3Command;
        private RelayCommand btnDebug4Command;
        private RelayCommand btnDebug5Command;
        public RelayCommand BtnDebug1Command
        {
            get
            {
                if(btnDebug1Command == null)
                {
                    btnDebug1Command = new RelayCommand(BtnDebug1Action);
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
                    btnDebug2Command = new RelayCommand(BtnDebug2Action);
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
                    btnDebug3Command = new RelayCommand(BtnDebug3Action);
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


        private void BtnDebug1Action()
        {

            //NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
            //logger.Fatal("发生致命错误");
            //logger.Warn("警告信息");
            
            //MessageBox.Show(LogItems.ToList()[1].Time.ToString());
        }
        private void BtnDebug2Action() 
        {
        }
        private void BtnDebug3Action()
        {
        }
        private void BtnDebug4Action()
        {
        }
        private void BtnDebug5Action()
        { 
        
        }

    #endregion

    }
}
