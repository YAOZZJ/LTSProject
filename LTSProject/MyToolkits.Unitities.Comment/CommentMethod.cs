using MyToolkits.DataBase.Base;
using MyToolkits.Log.NLogService;
using System;
using System.IO;

namespace MyToolkits.Unitities.Comment
{
    public class CommentMethod
    {
        public static void CheckDatabasePath(IDataBase database, string path, string name)
        {
            CheckAndCreatePath(path);
            if (!System.IO.File.Exists(Path.Combine(path, name)))
            {
                database.Connect(path);
                database.Execute(@"CREATE TABLE NLogX (
                                Id          INTEGER        PRIMARY KEY AUTOINCREMENT,
                                Time        DATETIME,
                                Level       NVARCHAR,
                                Threadname    NVARCHAR,
                                Source      NVARCHAR,
                                SourceDetails      NVARCHAR,
                                Message     NVARCHAR,
                                MessageId   INTEGER,
                                Logger      NVARCHAR,
                                Callsite    NVARCHAR,
                                Exception   NVARCHAR
                                )");
                using (NLogService nLog = new NLogService())
                {
                    nLog.Initial();
                    nLog.Info("Created database");
                }
            }
        }
        public static void CheckAndCreatePath(string path)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        }
        public static string GetCurrentPath()
        {
            return System.Environment.CurrentDirectory;
        }
    }

}
