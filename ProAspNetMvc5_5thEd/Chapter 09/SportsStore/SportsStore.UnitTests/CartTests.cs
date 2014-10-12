using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Models;
using System.Linq;
using System.Web.Mvc;

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

        /// <summary>
        /// Assert that CartController can add an item to the cart
        /// </summary>
        [TestMethod]
        public void CanAddToCart()
        {
            // Arrange
            IProductsRepository mock = GetTestRepository();
            Cart cart = new Cart();
            CartController target = new CartController(mock, null);

            // Act
            target.AddToCart(cart, 1, null);

            // Assertion
            Assert.AreEqual(1, cart.Lines.Count());
            Assert.AreEqual(1, cart.Lines.ToArray()[0].Product.ProductID);
        }

        /// <summary>
        /// Assert that adding a product to cart redirects to the cart index action
        /// </summary>
        [TestMethod]
        public void AddProductToCartGoesToCartIndex()
        {
            // Arrange
            IProductsRepository mock = GetTestRepository();
            Cart cart = new Cart();
            CartController target = new CartController(mock, null);

            // Act
            RedirectToRouteResult result = target.AddToCart(cart, 2, "myUrl");

            // Assertion
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("myUrl", result.RouteValues["returnUrl"]);
        }

        /// <summary>
        /// Assert that CartController index action displays correct cart contents
        /// </summary>
        [TestMethod]
        public void CanViewCartContents()
        {
            // Arrange
            Cart cart = new Cart();
            CartController target = new CartController(null, null);

            // Act
            CartIndexViewModel result = (CartIndexViewModel)target.Index(cart, "myUrl").ViewData.Model;

            // Assertion
            Assert.AreSame(cart, result.Cart);
            Assert.AreEqual("myUrl", result.ReturnUrl);
        }

        /// <summary>
        /// Assert that that the http post checkout action doesn't process empty carts
        /// </summary>
        [TestMethod]
        public void CannotCheckoutEmptyCart()
        {
            // Arrange
            Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();
            Cart cart = new Cart();
            ShippingDetails shippingDetails = new ShippingDetails();
            CartController target = new CartController(null, mock.Object);

            // Act
            ViewResult result = target.Checkout(cart, shippingDetails);

            // Assertion
            // verify with Moq that ProcessOrder(Cart, ShippingDetails) is never called
            mock.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Never());
            // and the method is returning the correct view
            Assert.AreEqual("", result.ViewName);
            // and the the model is invalidated
            Assert.AreEqual(false, result.ViewData.ModelState.IsValid);
        }

        /// <summary>
        /// Assert that invalid shipping details are sent back to the user for correction
        /// </summary>
        [TestMethod]
        public void CannotCheckoutInvalidShippingDetails()
        {
            // Arrange
            Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();
            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);
            CartController target = new CartController(null, mock.Object);
            // add an error to the model
            target.ModelState.AddModelError("error", "error");

            // Act
            ViewResult result = target.Checkout(cart, new ShippingDetails());

            // Assertion
            // verify with Moq that ProcessOrder(Cart, ShippingDetails) is never called
            mock.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Never());
            // and the method is returning the correct view
            Assert.AreEqual("", result.ViewName);
            // and the the model is invalidated
            Assert.AreEqual(false, result.ViewData.ModelState.IsValid);
        }

        /// <summary>
        /// Assert that checkout can process an order correctly
        /// </summary>
        [TestMethod]
        public void CanCheckoutAndSubmitOrder()
        {
            // Arrange
            Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();
            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);
            CartController target = new CartController(null, mock.Object);

            // Act
            ViewResult result = target.Checkout(cart, new ShippingDetails());

            // Assertion
            // verify ProcessOrder got called exactly once
            mock.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Once());
            // verify the returned view
            Assert.AreEqual("Completed", result.ViewName);
            // and the model is valid
            Assert.AreEqual(true, result.ViewData.ModelState.IsValid);
        }
    }
}
