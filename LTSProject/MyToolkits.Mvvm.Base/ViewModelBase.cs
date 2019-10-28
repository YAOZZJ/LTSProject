using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace MyToolkits.Mvvm.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
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

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    //    引用：
    //public class Person : ViewModelBase
    //    {
    //        private string _Name;
    //        /// <summary>
    //        /// 名字
    //        /// </summary>
    //        public string Name
    //        {
    //            get { return _Name; }
    //            set
    //            {
    //                _Name = value;
    //                RaisePropertyChanged(() => Name);
    //            }
    //        }
    //    }
}
