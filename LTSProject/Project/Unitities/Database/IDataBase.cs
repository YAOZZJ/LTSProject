using System.Collections.Generic;

namespace YAOZJ.Unitities.Database
{
    public interface IDataBase
    {
        string GetCurrentPath();
        bool Connect(string path);
        void Close();
        void Execute(string cmd);
        void Commit();
        void CreateTable<T>();
        List<T> GetTable<T>() where T : class, new();
    }
}
