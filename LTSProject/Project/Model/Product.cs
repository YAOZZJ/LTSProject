using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public abstract class Product
    {
        private IRepository _repository;
        public int ID { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double CostTime { get; set; }
        public int CountOK { get; set; }
        public int CountNG { get; set; }
        public Product(IRepository repository,string type)
        {
            _repository = repository;
            Type = type;
        }
        public async Task Save()
        {
            await _repository.Save(this);
        }
        internal void SetRepository(IRepository repository)
        {
            //如果此运算符的左操作数不为 null，则此运算符将返回左操作数；否则返回右操作数。
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
    }
}
