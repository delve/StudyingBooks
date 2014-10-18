using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using System.Linq;
using System.Web.Mvc;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class ImageTests
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
                new Product{ProductID = 2, Name = "P2", Category = "Cat2", Price=50, ImageData=new byte[]{}, ImageMimeType="image/png"},
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
        /// Assert that image data can be retrieved for a valid product id
        /// </summary>
        [TestMethod]
        public void CanRetrieveImageData()
        {
            // Arrange
            IProductsRepository mock = GetTestRepository();
            ProductController target = new ProductController(mock);

            // Act
            ActionResult result = target.GetImage(2);

            // Assertion
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(FileResult));
            Assert.AreEqual(mock.Products.ToArray()[1].ImageMimeType, ((FileResult)result).ContentType);
        }

        /// <summary>
        /// Assert that image data can not be retrieved for an invalid ID
        /// </summary>  
        [TestMethod]
        public void CanNotRetrieveImageDataForInvalidID()
        {
            // Arrange
            IProductsRepository mock = GetTestRepository();
            ProductController target = new ProductController(mock);

            // Act
            ActionResult result = target.GetImage(100);

            // Assertion
            Assert.IsNull(result);
        }
    }
}
