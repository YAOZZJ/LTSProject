using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Controls;
using YAOZJ.Unitities.Database;

namespace Project.Control.Manager
{
    /// <summary>
    /// DBBrowser.xaml 的交互逻辑
    /// </summary>
    public partial class DBBrowser : UserControl
    {
        public DBBrowser()
        {
            InitializeComponent();
            SqliteDatabase sqlite = new SqliteDatabase();
            this.DataContext = new DBBrowserViewModel(sqlite);
        }
        class DBBrowserViewModel:ViewModelBase
        {
            public DBBrowserViewModel(IDataBase db)
            {
                _db = db;

                dataBases = new ObservableCollection<DataBase>();
                Path = @"D:\YAOZJ\Documents\Visual Studio 2019\LTSProject\LTSProject\Project\bin\Debug\logs\log.db3";
                _db.Connect(Path);
                Table1 = new ObservableCollection<NLogItem>(_db.GetTable<NLogItem>());
                //foreach(var item in _db.GetTable())
                //{
                //    Table1.Add((NLogItem)item);
                //}

                
            }
            ObservableCollection<DataBase> dataBases;
            DataBase dataBase;
            TableList tableList;
            ViewList viewList;
            Table table;
            ColumnList columnList;
            string _txtStatus;
            string _path;
            IDataBase _db;
            ObservableCollection<NLogItem> _table;
            #region "Command"
            void Message(string msg)
            {
                TxtStatus = msg;
            }
            void Open()
            {
                Debug.WriteLine(nameof(Open));
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
                openFileDialog.Multiselect = false;
                openFileDialog.Filter = "SQLite3 File|*.sqlite3;*.db3|Database File|*.db" +
                 "|All Files|*.*";
                openFileDialog.InitialDirectory = @"D:\YAOZJ\Documents\Visual Studio 2019\LTSProject\LTSProject\Project\bin\Debug\logs";
                if ((bool)openFileDialog.ShowDialog())
                {
                    Message(openFileDialog.FileName);
                    Path = openFileDialog.FileName;
                }
            }
            void Execute()
            {
                Debug.WriteLine(nameof(Execute));
                dataBases.Add(dataBase = new DataBase("DataBase1", 1, false, true));
                dataBase.Items.Add(tableList = new TableList("Tables", 2, true, true));
                dataBase.Items.Add(viewList = new ViewList("Views", 2, true, true));
                tableList.Tables.Add(table = new Table("Table1", 3, false, false));
                table.Items.Add(columnList = new ColumnList("Columns", 4, false, true));

                viewList.Views.Add(new View("View1", 3, false));
                viewList.Views.Add(new View("View2", 3, true));
                viewList.Views.Add(new View("View3", 3, true));
                viewList.Views.Add(new View("View4", 3, true));
                viewList.Views.Add(new View("View5", 3, false));

                columnList.Columns.Add(new Column("Column1", 4, true));
                columnList.Columns.Add(new Column("Column2", 4, false));
                columnList.Columns.Add(new Column("Column3", 4, true));
                columnList.Columns.Add(new Column("Column4", 4, false));
                columnList.Columns.Add(new Column("Column5", 4, true));
            }
            void Clear()
            {
                Debug.WriteLine(nameof(Clear));
            }
            RelayCommand command1;
            RelayCommand command2;
            RelayCommand command3;
            public RelayCommand Command1 { get { return command1 ?? (command1 = new RelayCommand(Open)); } set => command1 = value; }
            public RelayCommand Command2 { get { return command2 ?? (command2 = new RelayCommand(Execute)); } set => command2 = value; }
            public RelayCommand Command3 { get { return command3 ?? (command3 = new RelayCommand(Clear)); } set => command3 = value; }

            public ObservableCollection<DataBase> DataBases { get => dataBases; set => dataBases = value; }
            public string Path { get => _path; set => _path = value; }
            public string TxtStatus { get => _txtStatus; set => Set(ref _txtStatus,value); }
            public ObservableCollection<NLogItem> Table1 { get => _table; set => _table = value; }

            //public RelayCommand SelectedItemChangedCommand { get { return _selectedItemChangedCommand ?? (_selectedItemChangedCommand = new RelayCommand(args => SelectedItemChanged(args))); } }


            private void SelectedItemChanged(object args)
            {
                //Cast your object
            }
            #endregion
        }
    }
    #region "DataBase"
    public class DataBaseList : ObservableCollection<DataBase>
    {
        public DataBaseList()
        {
            DataBase dataBase;
            TableList tableList;
            ViewList viewList;
            Table table;
            ColumnList columnList;

            Add(dataBase = new DataBase("DataBase1", 1, false, true));
            dataBase.Items.Add(tableList = new TableList("Tables", 2, true, true));
            dataBase.Items.Add(viewList = new ViewList("Views", 2, true, true));
            tableList.Tables.Add(table = new Table("Table1", 3, false, false));
            table.Items.Add(columnList = new ColumnList("Columns", 4, false, true));

            viewList.Views.Add(new View("View1", 3, false));
            viewList.Views.Add(new View("View2", 3, true));
            viewList.Views.Add(new View("View3", 3, true));
            viewList.Views.Add(new View("View4", 3, true));
            viewList.Views.Add(new View("View5", 3, false));

            columnList.Columns.Add(new Column("Column1", 4, true));
            columnList.Columns.Add(new Column("Column2", 4, false));
            columnList.Columns.Add(new Column("Column3", 4, true));
            columnList.Columns.Add(new Column("Column4", 4, false));
            columnList.Columns.Add(new Column("Column5", 4, true));
        }
    }
    public class DataBase : DataBaseNull
    {
        public DataBase(string name, int id = 0, bool select = false, bool expand = false) : base(name, id, select, expand)
        {
            items = new ObservableCollection<object>();
        }
        ObservableCollection<Object> items;

        public ObservableCollection<object> Items { get => items; set => items = value; }
    }
    public class TableList : DataBaseNull
    {
        public TableList(string name, int id = 0, bool select = false, bool expand = false) : base(name, id, select, expand)
        {
            tables = new ObservableCollection<Table>();
        }
        ObservableCollection<Table> tables;

        public ObservableCollection<Table> Tables { get => tables; set => tables = value; }
    }
    public class ViewList : DataBaseNull
    {
        public ViewList(string name, int id = 0, bool select = false, bool expand = false) : base(name, id, select, expand)
        {
            views = new ObservableCollection<View>();
        }
        ObservableCollection<View> views;

        public ObservableCollection<View> Views { get => views; set => views = value; }
    }
    public class Table : DataBaseNull
    {
        public Table(string name, int id = 0, bool select = false, bool expand = false) : base(name, id, select, expand)
        {
            items = new ObservableCollection<object>();
        }
        ObservableCollection<Object> items;

        public ObservableCollection<object> Items { get => items; set => items = value; }
    }
    public class ColumnList : DataBaseNull
    {
        public ColumnList(string name, int id = 0, bool select = false, bool expand = false) : base(name, id, select, expand)
        {
            columns = new ObservableCollection<Column>();
        }
        ObservableCollection<Column> columns;

        public ObservableCollection<Column> Columns { get => columns; set => columns = value; }
    }
    public class View : DataBaseNull
    {
        public View(string name, int id = 0, bool select = false, bool expand = false) : base(name, id, select, expand) { }
    }
    public class Column : DataBaseNull
    {
        public Column(string name, int id = 0, bool select = false, bool expand = false) : base(name, id, select, expand) { }
    }
    /// <summary>
    /// 数据库基类
    /// </summary>
    public class DataBaseNull
    {
        public DataBaseNull(string name, int id = 0, bool select = true, bool expand = true)
        {
            _name = name;
            _id = id;
            _isSelected = select;
            _isExpanded = expand;
        }
        int _id;
        string _name;
        bool? _isSelected;
        bool? _isExpanded;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        //public bool? IsSelected { get => _isSelected; set => _isSelected = value; }
        public bool? IsSelected { get => _isSelected; set { _isSelected = value; if ((bool)_isSelected) Debug.WriteLine(Name); } }
        public bool? IsExpanded { get => _isExpanded; set => _isExpanded = value; }
    }
    #endregion
}
