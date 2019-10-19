using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Control.Monitor
{
    //public class IOItems08
    //{
    //    public IOItems08()
    //    {
    //        ioItems = new ObservableCollection<IOItem>();
    //        ioItems.Add(new IOItem());
    //        ioItems.Add(new IOItem());
    //        ioItems.Add(new IOItem());
    //        ioItems.Add(new IOItem());
    //        ioItems.Add(new IOItem());
    //        ioItems.Add(new IOItem());
    //        ioItems.Add(new IOItem());
    //        ioItems.Add(new IOItem());
    //    }
    //    ObservableCollection<IOItem> ioItems;
    //    public ObservableCollection<IOItem> IoItems { get => ioItems; set => ioItems = value; }
    //}
    //public class IOItem
    //{
    //    public IOItem(bool value = false,bool changable = true,string comment = "")
    //    {
    //        _value = value;
    //        _changable = changable;
    //        _comment = comment;
    //    }
    //    bool _value;
    //    bool _changable;
    //    string _comment;
    //    public bool Value { get => _value; set { _value = value; RaisePropertyChanged("Value"); } }
    //    public bool Changable { get => _changable; set { _changable = value; RaisePropertyChanged("Changable"); } }
    //    public string Comment { get => _comment; set { _comment = value; RaisePropertyChanged("Comment"); } }

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
}
