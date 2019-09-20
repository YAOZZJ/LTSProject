using GalaSoft.MvvmLight;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                ColumnGraph.Add(new ColumnGraphDebug {
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
        }
        public List<Book> Books { get; set; }
        public Collection<LineDebug> LineGraph { get; set; }
        public Collection<ColumnGraphDebug> ColumnGraph { get; set; }
        public Collection<Item> Items { get; set; }

    }
}
