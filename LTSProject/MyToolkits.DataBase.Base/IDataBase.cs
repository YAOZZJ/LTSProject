using System;
using System.Collections.Generic;

namespace MyToolkits.DataBase.Base
{
    public interface IDataBase : IDisposable
    {
        string GetCurrentPath();
        bool Connect();
        bool Connect(string path);
        bool Connect(string path, string name);
        void Close();
        void Execute(string cmd);
        void Commit();
        void CreateTable<T>();
        List<string> GetTableName();
        List<string> GetColumnName(string tablename);
        void Insert(object obj);
        void InsertOrReplace(object obj);
        void InsertOrReplace(object obj, Type objTypetype);
        void Delete<T>(object primaryKey);
        void DeleteAll<T>();
        List<T> GetTable<T>() where T : class, new();
        //void Dispose();
    }
}
