using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NLog.Fluent;
using Project.Control;
using Project.Model;
using Project.Unitities;
using Project.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Project.ViewModel
{
    public class DebugViewModel : ViewModelBase
    {
        public DebugViewModel()
        {
            //*******************************************************************************************************************************
            this.Books = new List<Book>
            {
                new Book { Author = "Peter", ISBN = "0001", Price = 39.9, Publisher = "Pearsong", Title = "Up in the air" },
                new Book { Author = "John", ISBN = "0002", Price = 29.9, Publisher = "Longmon", Title = "101 tips to write a letter" },
                new Book { Author = "Ross", ISBN = "0003", Price = 49.9, Publisher = "Tree", Title = "How to become a programmer" },
                new Book { Author = "Monica", ISBN = "0004", Price = 23.6, Publisher = "People's pub", Title = "c# for all" },
                new Book { Author = "Bill", ISBN = "0005", Price = 37.5, Publisher = "Computer House", Title = "VB dummy" },
                new Book { Author = "Jil", ISBN = "0005", Price = 18.3, Publisher = "Redist", Title = "Health care for children" }
            };
            //*******************************************************************************************************************************

            this.LineGraph = new Collection<LineDebug>();
            double y = 0;
            for (int i = 0; i < 1000; i++)
            {
                y = Convert.ToDouble(i) / 100;
                this.LineGraph.Add(new LineDebug
                {
                    Time = y,
                    Value = Math.Sin(y)
                });
            }
            //*******************************************************************************************************************************
            this.ColumnGraph = new Collection<ColumnGraphDebug>();
            for (int i = 0; i < 20; i++)
            {
                y = Convert.ToDouble(i) * 10;
                ColumnGraph.Add(new ColumnGraphDebug
                {
                    Label = y.ToString(),
                    Value = y
                });
            }
            //*******************************************************************************************************************************
            this.Items = new Collection<Item>();
            this.Items = new Collection<Item>
                            {
                                new Item {Label = "Apples", Value1 = 37, Value2 = 12, Value3 = 19},
                                new Item {Label = "Pears", Value1 = 7, Value2 = 21, Value3 = 9},
                                new Item {Label = "Bananas", Value1 = 23, Value2 = 2, Value3 = 29}
                            };
            //*******************************************************************************************************************************
            this.ColorSelector = new ObservableCollection<ColorSelect>();
            var properties = typeof(Colors).GetProperties();
            foreach (System.Reflection.PropertyInfo info in properties)
            {
                ColorSelector.Add(new ColorSelect { Color = info.Name, Name = info.Name});

            }
            //*******************************************************************************************************************************
            if (LogItems == null) LogItems = new ObservableCollection<NLogItem>();
            if (_sqliteHelper == null)
                _sqliteHelper = new SQLiteHelper();
            LogItems = new ObservableCollection<NLogItem>(_sqliteHelper.GetAll());
            //LogItems.Add(new NLogItem {Time = DateTime.Now,Level = "adasda" });
        }
        public List<Book> Books { get; set; }
        public Collection<LineDebug> LineGraph { get; set; }
        public Collection<ColumnGraphDebug> ColumnGraph { get; set; }
        public Collection<Item> Items { get; set; }
        public Collection<ColorSelect> ColorSelector { get; set; }
        private ObservableCollection<NLogItem> _logItems;
        public ObservableCollection<NLogItem> LogItems { get => _logItems; set => Set(ref _logItems, value); }
        private SQLiteHelper _sqliteHelper;
        #region "Command"
        private RelayCommand btnDebug1Command;
        private RelayCommand btnDebug2Command;
        private RelayCommand btnDebug3Command;
        private RelayCommand btnDebug4Command;
        private RelayCommand btnDebug5Command;
        public RelayCommand BtnDebug1Command
        {
            get
            {
                if(btnDebug1Command == null)
                {
                    btnDebug1Command = new RelayCommand(BtnDebug1Action);
                }
                return btnDebug1Command;
            } 
            set => btnDebug1Command = value;
        }
        public RelayCommand BtnDebug2Command
        {
            get
            {
                if (btnDebug2Command == null)
                {
                    btnDebug2Command = new RelayCommand(BtnDebug2Action);
                }
                return btnDebug2Command;
            }
            set => btnDebug2Command = value;
        }
        public RelayCommand BtnDebug3Command
        {
            get
            {
                if (btnDebug3Command == null)
                {
                    btnDebug3Command = new RelayCommand(BtnDebug3Action);
                }
                return btnDebug3Command;
            }
            set => btnDebug3Command = value;
        }
        public RelayCommand BtnDebug4Command
        {
            get
            {
                if (btnDebug4Command == null)
                {
                    btnDebug4Command = new RelayCommand(BtnDebug4Action);
                }
                return btnDebug4Command;
            }
            set => btnDebug4Command = value;
        }
        public RelayCommand BtnDebug5Command
        {
            get
            {
                if (btnDebug5Command == null)
                {
                    btnDebug5Command = new RelayCommand(BtnDebug5Action);
                }
                return btnDebug5Command;
            }
            set => btnDebug5Command = value;
        }


        private void BtnDebug1Action()
        {

            //NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
            //logger.Fatal("发生致命错误");
            //logger.Warn("警告信息");
            
            MessageBox.Show(LogItems.ToList()[1].Time.ToString());
        }
        private void BtnDebug2Action() 
        {
        }
        private void BtnDebug3Action()
        {
        }
        private void BtnDebug4Action()
        {
        }
        private void BtnDebug5Action()
        { 
        
        }

    #endregion

    }
}
