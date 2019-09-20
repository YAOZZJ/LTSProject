using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class DebugModel
    {
    }
    public class Book
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public double Price { get; set; }
        public string Author { get; set; }
    }
    public class LineDebug
    {
        public double Value { get; set; }
        public double Time { get; set; }
    }
    public class ColumnGraphDebug
    {
        public string Label { get; set; }

        public double Value { get; set; }
    }
    public class Item
    {
        public string Label { get; set; }
        public double Value1 { get; set; }
        public double Value2 { get; set; }
        public double Value3 { get; set; }
    }
}
