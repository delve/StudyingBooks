using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.HtmlHelpers;
using SportsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class ProductControllerTests
    {
        /// <summary>
        /// Helper function, returns a mock repository for testing with
        /// </summary>
        /// <returns>Mock IProductsRepository to test with</returns>
        public IProductsRepository GetMockRepository()
        {
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
                {
                    new Product{ProductID = 1, Name = "P1", Category = "Cat1"},
                    new Product{ProductID = 2, Name = "P2", Category = "Cat2"},
                    new Product{ProductID = 3, Name = "P3", Category = "Cat1"},
                    new Product{ProductID = 4, Name = "P4", Category = "Cat3"},
                    new Product{ProductID = 5, Name = "P5", Category = "Cat2"}
                });
            return mock.Object;
        }

        /// <summary>
        /// Assert that ProductListViewModel pagination gets correct products from the model
        /// </summary>
        [TestMethod]
        public void CanPaginate()
        {
            // Arrange
            IProductsRepository mock = GetMockRepository();
            ProductController controller = new ProductController(mock);
            controller.PageSize = 3;

            // Act
            ProductsListViewModel result = (ProductsListViewModel)controller.List(null, 2).Model;

            // Assertion
            Product[] prodArray = result.Products.ToArray();
            Assert.IsTrue(prodArray.Length == 2, string.Format("Wrong number of items on page 2. Should be 2, was {0}", prodArray.Length));
            Assert.AreEqual(prodArray[0].Name, "P4", "Product P4 name does not match");
            Assert.AreEqual(prodArray[1].Name, "P5", "Product P5 name does not match");
        }

        /// <summary>
        /// Assert that ProductController sets up PageInfo correctly for ProductsListViewModel 
        /// </summary>
        [TestMethod]
        public void CanPaginateProductListViewModel()
        {
            // Arrange
            IProductsRepository mock = GetMockRepository();
            ProductController controller = new ProductController(mock);
            controller.PageSize = 3;

            // Act
            ProductsListViewModel result = (ProductsListViewModel)controller.List(null, 2).Model;

            // Assertion
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(2, pageInfo.CurrentPage, "Current page incorrect");
            Assert.AreEqual(3, pageInfo.ItemsPerPage, "Items per page incorrect");
            Assert.AreEqual(5, pageInfo.TotalItems, "Total items incorrect");
            Assert.AreEqual(2, pageInfo.TotalPages, "Total pages incorrect");
        }

        /// <summary>
        /// Assert that page links are generated correctly (brittle, dependant on HTML output)
        /// </summary>
        [TestMethod]
        public void CanGeneratePageLinks()
        {
            // Arrange
            // have to define an HTML helper object in order to access the extension function in PagingHelper
            HtmlHelper myHelper = null;
            // create PagingInfo data
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };

            // set up the delegate via lambda
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            // Act
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            // Assertion
            Assert.AreEqual(
                @"<a class=""btn btn-default"" href=""Page1"">1</a>" + 
                    @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>" + 
                    @"<a class=""btn btn-default"" href=""Page3"">3</a>",
                result.ToString());
        }

        /// <summary>
        /// Assert that product filtering occurs correctly in ProductController
        /// </summary>
        [TestMethod]
        public void CanFilterProducts()
        {
            // Arrange
            IProductsRepository mock = GetMockRepository();
            ProductController controller = new ProductController(mock);
            controller.PageSize = 3;

            // Act
            Product[] result = ((ProductsListViewModel)controller.List("Cat2", 1).Model).Products.ToArray();

            // Assertion
            Assert.AreEqual(result.Length, 2);
            Assert.IsTrue("P2" == result[0].Name && "Cat2" == result[0].Category, "P2 != result[0]");
            Assert.IsTrue("P5" == result[1].Name && "Cat2" == result[1].Category, "P5 != result[1]");
        }

        /// <summary>
        /// Assert that NavController.Menu can create an alphabetized list of distinct categories
        /// </summary>
        [TestMethod]
        public void CanCreateCategoryList()
        {
            // Arrange
            IProductsRepository mock = GetMockRepository();
            NavController target = new NavController(mock);

            // Act
            string[] results = ((IEnumerable<string>)target.Menu().Model).ToArray();

            // Assertion
            Assert.AreEqual(3, results.Length, "Incorrect number of categories returned");
            Assert.AreEqual("Cat1", results[0], "First category incorrect, categories out of order?");
            Assert.AreEqual("Cat2", results[1], "Second category incorrect, categories out of order?");
            Assert.AreEqual("Cat3", results[2], "Third category incorrect, categories out of order?");
        }

        /// <summary>
        /// Assert that NavController.Menu adds the correct seleted category to ViewBag
        /// </summary>
        [TestMethod]
        public void IndicatesSelectedCategory()
        {
            // Arrange
            IProductsRepository mock = GetMockRepository();
            NavController target = new NavController(mock);
            string categoryToSelect = "Cat3";

            // Act
            string result = target.Menu(categoryToSelect).ViewBag.SelectedCategory;

            // Assertion
            Assert.AreEqual(categoryToSelect, result, "Selected category incorrect");
        }

        /// <summary>
        /// Assert that ProductController can send the count of products in a specific category to PageInfo
        /// </summary>
        [TestMethod]
        public void CanGenerateCorrectProductCountForPaging()
        {
            // Arrange
            IProductsRepository mock = GetMockRepository();
            ProductController target = new ProductController(mock);
            target.PageSize = 3;

            // Act
            int res1 = ((ProductsListViewModel)target.List("Cat1").Model).PagingInfo.TotalItems;
            int res2 = ((ProductsListViewModel)target.List("Cat2").Model).PagingInfo.TotalItems;
            int res3 = ((ProductsListViewModel)target.List("Cat3").Model).PagingInfo.TotalItems;
            int resAll = ((ProductsListViewModel)target.List(null).Model).PagingInfo.TotalItems;

            // Assertion
            Assert.AreEqual(2, res1, "Incorrect number of Cat1 products");
            Assert.AreEqual(2, res2, "Incorrect number of Cat2 products");
            Assert.AreEqual(1, res3, "Incorrect number of Cat3 products");
            Assert.AreEqual(5, resAll, "Incorrect number of 'all' products");
        }
    }
}