using Project.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Unitities
{
    public class SQLiteHelper
    {
        private SQLiteConnection _db;
        public SQLiteHelper()
        {
            _db = new SQLiteConnection("logs//log.db3");
            //_db.CreateTable<Message>();
        }
        public void Insert(object obj)
        {
            _db.Insert(obj);
        }
        public NLogItem Get()
        {
            var items = new NLogItem();
            items = _db.Get<NLogItem>(x =>x.MessageID ==16);
            return items;
        }
        public List<NLogItem> GetAll()
        {
            return _db.Table<NLogItem>().ToList();
        }
    }
}
