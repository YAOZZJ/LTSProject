using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public abstract class Product
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double CostTime { get; set; }
        public int CountOK { get; set; }
        public int CountNG { get; set; }
    }
}
