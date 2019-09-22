using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repositories
{
    public interface IRepository
    {
        Task Initalise();
        Task Save(Product product);
        Task<Product> GetProduct(int id);
        Task<List<Product>> GetProducts(string type);
        Task<List<Product>> GetAll();
    }
}
