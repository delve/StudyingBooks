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
    public class UnitTest1
    {
        public Mock<IProductsRepository> GetMockRepository()
        {
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
                {
                    new Product{ProductID=1,Name="P1"},
                    new Product{ProductID=2,Name="P2"},
                    new Product{ProductID=3,Name="P3"},
                    new Product{ProductID=4,Name="P4"},
                    new Product{ProductID=5,Name="P5"}
                });
            return mock;
        }

        [TestMethod]
        public void CanPaginate()
        {
            // Arrange
            Mock<IProductsRepository> mock = GetMockRepository();
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            // Act
            ProductsListViewModel result = (ProductsListViewModel)controller.List(2).Model;

            // Assertion
            Product[] prodArray = result.Products.ToArray();
            Assert.IsTrue(prodArray.Length == 2, string.Format("Wrong number of items on page 2. Should be 2, was {0}", prodArray.Length));
            Assert.AreEqual(prodArray[0].Name, "P4", "Product P4 name does not match");
            Assert.AreEqual(prodArray[1].Name, "P5", "Product P5 name does not match");
        }

        [TestMethod]
        public void CanPaginateProductListViewModel()
        {
            // Arrange
            Mock<IProductsRepository> mock = GetMockRepository();
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            // Act
            ProductsListViewModel result = (ProductsListViewModel)controller.List(2).Model;

            // Assertion
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2, "Current page incorrect");
            Assert.AreEqual(pageInfo.ItemsPerPage, 3, "Items per page incorrect");
            Assert.AreEqual(pageInfo.TotalItems, 5, "Total items incorrect");
            Assert.AreEqual(pageInfo.TotalPages, 2, "Total pages incorrect");
        }

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
    }
}