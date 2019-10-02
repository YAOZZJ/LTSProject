using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Project.Model;
using Project.Unitities;

namespace Project.Service
{
    public class NLogGridViewService : INLogGridViewService
    {
        private ObservableCollection<NLogItem> _logItems;
        private SQLiteHelper _sqliteHelper;
        private uint countWarn;
        public uint CountWarn { get => countWarn; set => countWarn = value; }
        public NLogGridViewService()
        {
            if (_sqliteHelper == null)
                _sqliteHelper = new SQLiteHelper();
            _logItems = new ObservableCollection<NLogItem>(_sqliteHelper.GetAll());
        }


        public void Add()
        {
            //_logItems.Add(new NLogItem {Message = "lalala" });
        }

        public void GetLogItems(Action<ObservableCollection<NLogItem>, Exception> callback)
        {
            callback(_logItems, null);
        }
        
    }
}
