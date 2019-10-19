using Project.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAOZJ.Unitities.Database
{
    public class SqliteDatabase : IDataBase
    {
        SQLiteConnection _db;

        public void Close()
        {
            if(_db != null) _db.Close();
        }

        public void Commit()
        {
            _db.Commit();
        }

        public bool Connect(string path)
        {
            bool status = false;
            try
            {
                _db = new SQLiteConnection(path);
                status = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("db Connect error");
                Debug.WriteLine(ex.Message);
                //throw (ex);
            }
            finally
            {
            }
            return status;
        }

        public void CreateTable<T>()
        {
            if (_db != null) return;
            _db.CreateTable<T>();
        }

        public void Execute(string cmd)
        {
            _db.Execute(cmd);
        }

        public string GetCurrentPath()
        {
            return _db.DatabasePath;
        }

        public List<T> GetTable<T>() where T : class, new()
        {
            return _db.Table<T>().ToList();
        }

        void Test<T>()where T : class,new()
        {
            _db.Table<T>().ToList();
            
        }
    }
}
