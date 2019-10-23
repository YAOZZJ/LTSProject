using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using static SQLite.SQLiteConnection;

namespace Project.Unitities.Database
{
    public class SqliteDatabase : IDataBase
    {
        #region 'Variables'
        SQLiteConnection _db;
        //string _path;
        #endregion

        #region 'Public Method'

        public void Close()
        {
            if (_db != null) _db.Close();
        }

        public void Commit()
        {
            _db.Commit();
        }
        public bool Connect()
        {
            bool status = false;
            //_currentpath = System.Environment.CurrentDirectory;
            string path = Path.Combine(Path.GetTempPath(), "SQLite3");
            CheckAndCreatePath(path);
            try
            {
                _db = new SQLiteConnection(Path.Combine(path, "DBSQLite3.sqlite3"));
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
        public bool Connect(string path)
        {
            CheckAndCreatePath(path);
            bool status = false;
            try
            {
                _db = new SQLiteConnection(Path.Combine(path, "Database.sqlite3"));
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
        public bool Connect(string path, string dbname)
        {
            bool status = false;
            CheckAndCreatePath(path);
            try
            {
                _db = new SQLiteConnection(Path.Combine(path, dbname));
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
            if (_db != null)
                _db.CreateTable<T>();
        }
        public List<string> GetTableName()
        {
            List<GetName> _name = _db.Query<GetName>
                ("select name from sqlite_master where type='table' and name != 'sqlite_sequence' order by name");
            List<string> value = new List<string>();
            foreach (GetName str in _name)
            {
                value.Add(str.Name);
            }
            return value;
        }
        public List<string> GetColumnName(string tablename)
        {
            List<string> value = new List<string>();
            //List<GetName> _name = _db.Query<GetName>($"PRAGMA table_info('{tablename}')");

            //foreach (GetName str in _name)
            //{
            //    value.Add(str.Name);
            //}
            foreach (ColumnInfo info in _db.GetTableInfo(tablename))
            {
                value.Add(info.Name);
            }
            return value;
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
        public void Insert(object obj)
        {
            _db.Insert(obj);
        }
        public void InsertOrReplace(object obj)
        {
            _db.InsertOrReplace(obj);
        }

        public void InsertOrReplace(object obj, Type objType)
        {
            _db.InsertOrReplace(obj, objType);
        }
        public void Delete<T>(object primaryKey)
        {
            _db.Delete<T>(primaryKey);
        }
        public void DeleteAll<T>()
        {
            _db.DeleteAll<T>();
        }

        void Test<T>() where T : class, new()
        {
            _db.Table<T>().ToList();

        }
        #endregion
        #region 'private Method'
        void CheckAndCreatePath(string path)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        }
        public void Dispose()
        {
            if (_db != null) _db.Close();
        }


        class GetName
        {
            public string Name { get; set; }
        }
        #endregion
    }
}
