using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LTSProject.ViewModels
{
    public class MainViewModel : PropertyChangedBase
    {
        public MainViewModel()
        {
            this.Books = new List<Book>
            {
                new Book { Author = "Peter", ISBN = "0001", Price = 39.9, Publisher = "Pearsong", Title = "Up in the air" },
                new Book { Author = "John", ISBN = "0002", Price = 29.9, Publisher = "Longmon", Title = "101 tips to write a letter" },
                new Book { Author = "Ross", ISBN = "0003", Price = 49.9, Publisher = "Tree", Title = "How to become a programmer" },
                new Book { Author = "Monica", ISBN = "0004", Price = 23.6, Publisher = "People's pub", Title = "c# for all" },
                new Book { Author = "Bill", ISBN = "0005", Price = 37.5, Publisher = "Computer House", Title = "VB dummy" },
                new Book { Author = "Jil", ISBN = "0005", Price = 18.3, Publisher = "Redist", Title = "Health care for children" }
            };
        }
        public void BtnDebug1()
        {
            MessageBox.Show("sdfsdf");
        }
        public void BtnDebug2()
        {
        }
        public void BtnDebug3()
        {
        }
        public void BtnDebug4()
        {
        }
        public void BtnDebug5()
        {
        }
        public void BtnDebug6()
        {
        }
        public List<Book> Books { get; set; }

    }
    public class Book
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public double Price { get; set; }
        public string Author { get; set; }
    }
}
