using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Control.Monitor.Base
{
    
    //public class IOGroupList
    //{
    //    public IOGroupList()
    //    {
    //        iOGroups = new ObservableCollection<IOGroup>();
    //        _name = "IOGroupList";
    //    }
    //    ObservableCollection<IOGroup> iOGroups;
    //    string _name;
    //    public ObservableCollection<IOGroup> IOGroups { get => iOGroups; set => iOGroups = value; }
    //    public string Name { get => _name; set { _name = value; RaisePropertyChanged("Name"); } }
    //    #region INotifyProperty

    //    public event PropertyChangedEventHandler PropertyChanged;

    //    public void RaisePropertyChanged(string propertyName)
    //    {
    //        if (PropertyChanged != null)
    //        {
    //            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    //        }
    //    }
    //    protected void RaisePropertyChanged<T>(Expression<Func<T>> action)
    //    {
    //        var propertyName = GetPropertyName(action);
    //        RaisePropertyChanged(propertyName);
    //    }
    //    private static string GetPropertyName<T>(Expression<Func<T>> action)
    //    {
    //        var expression = (MemberExpression)action.Body;
    //        var propertyName = expression.Member.Name;
    //        return propertyName;
    //    }
    //    #endregion

    //}
    public class IOGroup
    {
        
        public IOGroup(string name = "")
        {
            _iOCells = new ObservableCollection<IOCell>();
            _name = name;
        }
        ObservableCollection<IOCell> _iOCells;
        string _name;
        public ObservableCollection<IOCell> IOCells { get => _iOCells; set => _iOCells = value; }
        public string Name { get => _name; set { _name = value; RaisePropertyChanged("Name"); } }

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
    public class IOCell
    {
        public IOCell(string name = "", bool value = false, bool changable = true,bool isselected = false, bool isenabled = true,int id = 0)
        {
            _value = value;
            _changable = changable;
            _isSelected = isselected;
            _isEnabled = isenabled;
            _name = name;
            _id = id;
        }
        bool _value;
        bool _changable;
        bool _isSelected;
        bool _isEnabled;
        string _name;
        int _id;
        public bool Value { get => _value; set { _value = value;RaisePropertyChanged("Value"); } }
        public bool Changable { get => _changable; set { _changable = value; RaisePropertyChanged("Changable"); } }
        public bool IsSelected { get => _isSelected; set { _isSelected = value;RaisePropertyChanged("IsSelected"); } }
        public bool IsEnabled { get => _isEnabled; set { _isEnabled = value; RaisePropertyChanged("IsEnabled"); } }
        public string Name { get => _name; set { _name = value; RaisePropertyChanged("Name"); } }
        public int Id { get => _id; set { _id = value; RaisePropertyChanged("Id"); } }
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
