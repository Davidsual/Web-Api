using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Davide.Experiments.Web.UI.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);

    }

    public class ProductRepository : IProductRepository
    {
        Product[] products = new Product[] 
        { 
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M } 
        };

        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        public Product GetById(int id)
        {
            return products.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Product product)
        {
            throw new NotImplementedException();
        }
    }
}