using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class AdminTests
    {
        /// <summary>
        /// Returns a consistent array of Product to test against
        /// </summary>
        /// <returns></returns>
        public Product[] GetTestProducts()
        {
            return new Product[]
            {
                new Product{ProductID = 1, Name = "P1", Category = "Cat1", Price=100},
                new Product{ProductID = 2, Name = "P2", Category = "Cat2", Price=50},
                new Product{ProductID = 3, Name = "P3", Category = "Cat1", Price=5.6M},
                new Product{ProductID = 4, Name = "P4", Category = "Cat3", Price=3000},
                new Product{ProductID = 5, Name = "P5", Category = "Cat2", Price=2001}
            };
        }

        /// <summary>
        /// Returns a consistent IProductsRepository to test against
        /// </summary>
        /// <returns></returns>
        public IProductsRepository GetTestRepository()
        {
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns(GetTestProducts().AsQueryable());
            return mock.Object;
        }

        /// <summary>
        /// Returns a consistent IOrderProcessor to test against
        /// </summary>
        /// <returns></returns>
        public IOrderProcessor GetOrderProcessor()
        {
            Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();
            return mock.Object;
        }

        /// <summary>
        /// Assert that Admin controller Index action contains all products in the data domain
        /// </summary>
        [TestMethod]
        public void IndexContainsAllProducts()
        {
            // Arrange
            IProductsRepository mock = GetTestRepository();
            AdminController target = new AdminController(mock);

            // Act
            Product[] result = ((IEnumerable<Product>)target.Index().ViewData.Model).ToArray();

            // Assertion
            Assert.AreEqual("P1", result[0].Name);
            Assert.AreEqual("P2", result[1].Name);
            Assert.AreEqual("P3", result[2].Name);
            Assert.AreEqual(5, result.Count());
        }

        /// <summary>
        /// Assert that the Edit action opens the correct product for editting
        /// </summary>
        [TestMethod]
        public void CanEditProduct()
        {
            // Arrange
            IProductsRepository mock = GetTestRepository();
            AdminController target = new AdminController(mock);

            // Act
            Product p1 = target.Edit(1).ViewData.Model as Product;
            Product p2 = target.Edit(2).ViewData.Model as Product;
            Product p3 = target.Edit(3).ViewData.Model as Product;

            // Assertion
            Assert.AreEqual(1, p1.ProductID);
            Assert.AreEqual(2, p2.ProductID);
            Assert.AreEqual(3, p3.ProductID);
        }

        /// <summary>
        /// Assert that the Edit action does not open a product when an invalid ID is selected
        /// </summary>
        [TestMethod]
        public void CannotEditNonexistentProduct()
        {
            // Arrange
            IProductsRepository mock = GetTestRepository();
            AdminController target = new AdminController(mock);

            // Act
            Product result = (Product)target.Edit(6).ViewData.Model;

            // Assertion
            Assert.IsNull(result);
        }

        /// <summary>
        /// Assert that valid updates are saved to the repository
        /// </summary>
        [TestMethod]
        public void CanSaveValidChanges()
        {
            // Arrange
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            AdminController target = new AdminController(mock.Object);
            Product product = new Product { Name = "Test" };

            // Act
            ActionResult result = target.Edit(product);

            // Assertion
            // repository save method was called
            mock.Verify(m => m.SaveProduct(product));

            // result of method was correct type
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        }

        /// <summary>
        /// Assert that invalid updates are not saved to the repository
        /// </summary>
        [TestMethod]
        public void CannotSaveInvalidChanges()
        {
            // Arrange
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            AdminController target = new AdminController(mock.Object);
            Product product = new Product { Name = "Test" };
            // create an error state in the model
            target.ModelState.AddModelError("error", "error");

            // Act
            ActionResult result = target.Edit(product);

            // Assertion
            // repository.SaveProduct was not called
            mock.Verify(m => m.SaveProduct(It.IsAny<Product>()), Times.Never());

            // action result was correct type
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        /// <summary>
        /// Assert that AdminController can delete a product
        /// </summary>
        [TestMethod]
        public void CanDeleteValidProducts()
        {
            // Arrange
            Product prod = new Product { ProductID = 2, Name = "Test" };
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
                {
                    new Product{ProductID=1, Name="P1"},
                    prod,
                    new Product{ProductID=3, Name="P3"}
                });
            AdminController target = new AdminController(mock.Object);

            // Act
            target.Delete(prod.ProductID);

            // Assertion
            mock.Verify(m => m.DeleteProduct(prod.ProductID));
        }
    }
}
