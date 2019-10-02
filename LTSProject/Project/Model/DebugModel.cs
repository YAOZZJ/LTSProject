using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class DebugModel 
    {
        public DebugModel()
        {

        }
        private string text1;
        private string text2;
        private string text3;

        public string Text1 { get => text1; set { text1 = value; RaisePropertyChanged(()=>Text1); } }
        public string Text2 { get => text2; set { text2 = value; RaisePropertyChanged(()=>Text2); } }
        public string Text3 { get => text3; set { text3 = value; RaisePropertyChanged(()=>Text3); } }

        public void Command1() 
        { 
            Debug.WriteLine("Command1");
            Text1 += "1";
        }
        public void Command2()
        {
            Debug.WriteLine("Command2");
            Text2 += "2";

        }
        public void Command3()
        {
            Debug.WriteLine("Command3");
            Text3 += "3";

        }
        public void Command4()
        {
            Debug.WriteLine("Command4");
        }
        public void Command5()
        {
            Debug.WriteLine("Command5");
        }
        public void Command6()
        {
            Debug.WriteLine("Command6");
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
        protected void RaisePropertyChanged<T>(Expression<Func<T>> action)
        {
            var propertyName = GetPropertyName(action);
            RaisePropertyChanged(propertyName);
        }
        private static string GetPropertyName<T>(Expression<Func<T>> action)
        {
            var expression = (MemberExpression)action.Body;
            var propertyName = expression.Member.Name;
            return propertyName;
        }
        #endregion
    }
}
