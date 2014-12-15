using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Davide.Experiments.Web.UI.Controllers;
using Davide.Experiments.Web.UI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Davide.Experiments.Web.Test
{
    [TestFixture]
    public class ProductControllerTest
    {
        [TestCase]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            var mockRepository = GetMockIProductRepository();
            var controller = new ProductsController(mockRepository.Object);
           
            var result = controller.GetAllProducts() as Product[];
            Assert.AreEqual(GetTestProducts().Count, result.Length);
        }

        [TestCase]
        public async Task GetAllProductsAsync_ShouldReturnAllProducts()
        {
            var mockRepository = GetMockIProductRepository();
            var controller = new ProductsController(mockRepository.Object);

            var result = await controller.GetAllProductsAsync() as Product[];
            Assert.AreEqual(GetTestProducts().Count, result.Length);
        }

        [TestCase]
        public void GetProduct_ShouldReturnCorrectProduct()
        {
            var mockRepository = GetMockIProductRepository();
            var controller = new ProductsController(mockRepository.Object);

            var result = controller.GetProduct(2) as OkNegotiatedContentResult<Product>;
            Assert.IsNotNull(result);
            Assert.AreEqual(GetTestProducts()[1].Name, result.Content.Name);
        }


        [TestCase]
        public async Task GetProductAsync_ShouldReturnCorrectProduct()
        {
            var mockRepository = GetMockIProductRepository();
            var controller = new ProductsController(mockRepository.Object);

            var result = await controller.GetProductAsync(2) as OkNegotiatedContentResult<Product>;
            Assert.IsNotNull(result);
            Assert.AreEqual(GetTestProducts()[1].Name, result.Content.Name);
        }


        [TestCase]
        public void GetProduct_ShouldNotFindProduct()
        {
            var mockRepository = GetMockIProductRepository();
            var controller = new ProductsController(mockRepository.Object);

            //var result = controller.GetProduct(999);
            //Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }


        private List<Product> GetTestProducts()
        {
            return new List<Product>()
            {
                new Product {Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1},
                new Product {Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M},
                new Product {Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M}
            };
        }


        private Mock<IProductRepository> GetMockIProductRepository()
        {
            Product[] products = new Product[]
            {
                new Product {Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1},
                new Product {Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M},
                new Product {Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M}
            };


            Mock<IProductRepository> mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(mr => mr.GetAll()).Returns(products);
            mockProductRepository.Setup(mr => mr.GetById(It.IsAny<int>()))
                .Returns((int i) => products.Single(x => x.Id == i));
            mockProductRepository.Setup(mr => mr.Add(It.IsAny<Product>()));
            return mockProductRepository;

        }
    }
}
