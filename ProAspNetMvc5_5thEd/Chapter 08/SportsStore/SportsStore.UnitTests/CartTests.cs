using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Domain.Entities;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class CartTests
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
        /// Assert that Cart correctly adds new CartLine items
        /// </summary>
        [TestMethod]
        public void CanAddNewLines()
        {
            // Arrange
            Product[] testProduct = GetTestProducts();
            Cart target = new Cart();

            // Act
            target.AddItem(testProduct[0], 1);
            target.AddItem(testProduct[1], 1);
            CartLine[] results = target.Lines.ToArray();

            // Assertion
            Assert.AreEqual(2, results.Length);
            Assert.AreEqual(testProduct[0], results[0].Product);
            Assert.AreEqual(testProduct[1], results[1].Product);
        }

        /// <summary>
        /// Assert that Cart properly increments quantity when an existing CartLine item is added
        /// </summary>
        [TestMethod]
        public void CanIncrementQuantity()
        {
            // Arrange
            Product[] testProduct = GetTestProducts();
            Cart target = new Cart();

            // Act
            target.AddItem(testProduct[0], 1);
            target.AddItem(testProduct[1], 1);
            target.AddItem(testProduct[0], 10);
            CartLine[] results = target.Lines.OrderBy(c=>c.Product.ProductID).ToArray();

            // Assertion
            Assert.AreEqual(2, results.Length);
            Assert.AreEqual(11, results[0].Quantity);
            Assert.AreEqual(1, results[1].Quantity);
        }

        /// <summary>
        /// Assert that Cart removes an item correctly
        /// </summary>
        [TestMethod]
        public void CanRemoveLine()
        {
            // Arrange
            Product[] testProduct = GetTestProducts();
            Cart target = new Cart();
            target.AddItem(testProduct[0], 1);
            target.AddItem(testProduct[1], 3);
            target.AddItem(testProduct[2], 5);
            target.AddItem(testProduct[1], 1);

            // Act
            target.RemoveLine(testProduct[1]);

            // Assertion
            Assert.AreEqual(0, target.Lines.Where(c => c.Product == testProduct[1]).Count());
            Assert.AreEqual(2, target.Lines.Count());
        }

        /// <summary>
        /// Assert that Cart calculates the correct total price
        /// </summary>
        [TestMethod]
        public void CalculateCartTotal()
        {
            // Arrange
            Product[] testProduct = GetTestProducts();
            Cart target = new Cart();

            // Act
            target.AddItem(testProduct[0], 1);
            target.AddItem(testProduct[1], 1);
            target.AddItem(testProduct[0], 3);
            decimal result = target.ComputeTotalValue();

            // Assertion
            Assert.AreEqual(450M, result);
        }

        /// <summary>
        /// Assert that the shopping cart empties correctly
        /// </summary>
        [TestMethod]
        public void CanClearCart()
        {
            // Arrange
            Product[] testProduct = GetTestProducts();
            Cart target = new Cart();
            target.AddItem(testProduct[0], 1);
            target.AddItem(testProduct[1], 1);

            // Act
            target.Clear();

            // Assertion
            Assert.AreEqual(0, target.Lines.Count());
        }
    }
}
