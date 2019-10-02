using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class DebugModel : INotifyPropertyChanged
    {
        public DebugModel()
        {

        }
        private string text1;
        private string text2;
        private string text3;

        public string Text1 { get => text1; set => text1 = value; }
        //public string Text2 { get => text2; set => text2 = value; }
        public string Text2 { get => text2; set { text2 = value; RaisePropertyChanged("Text2"); } }
        public string Text3 { get => text3; set => text3 = value; }

        public void Command1() 
        { 
            Debug.WriteLine("Command1");
        }
        public void Command2()
        {
            Debug.WriteLine("Command2");
            Debug.WriteLine("--Text2:"+ Text2);
        }
        public void Command3()
        {
            Debug.WriteLine("Command3");
            Text2 += "**";
        }
        #region INotifyProperty

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
