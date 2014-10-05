using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EssentialTools.Models;

namespace EssentialTools.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private IDiscountHelper getTestObject()
        {
            return new MinimumDiscountHelper();
        }

        [TestMethod]
        public void Build_Successful()
        {
            // Arrange
            // no arrangement

            // Act
            // no action

            // Assertion
            // Congratulations. The project built. This test also sucks up the erroneous 'build time' in the test timer output
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Discount_Above_100()
        {
            // arrange
            IDiscountHelper target = getTestObject();
            decimal total = 200;

            // act
            var discountedTotal = target.ApplyDiscount(total);

            // assert
            Assert.AreEqual(total * 0.9M, discountedTotal, ">$100 discount is wrong");
        }

        [TestMethod]
        public void Discount_Between_10_And_100()
        {
            // Arrange
            IDiscountHelper target = getTestObject();
            
            // Act
            decimal TenDollarDiscount = target.ApplyDiscount(10);
            decimal HundredDollarDiscount = target.ApplyDiscount(100);
            decimal FiftyDollarDiscount = target.ApplyDiscount(50);
            
            // Assertion
            Assert.AreEqual(5, TenDollarDiscount, "$10 discount is wrong");
            Assert.AreEqual(95, HundredDollarDiscount, "$100 discount is wrong");
            Assert.AreEqual(45, FiftyDollarDiscount, "$50 discount is wrong");
        }

        [TestMethod]
        public void Discount_Less_Than_10()
        {
            // Arrange
            IDiscountHelper target = getTestObject();
            
            // Act
            decimal discount5 = target.ApplyDiscount(5);
            decimal discount0 = target.ApplyDiscount(0);
            
            // Assertion
            Assert.AreEqual(5, discount5);
            Assert.AreEqual(0, discount0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Discount_Negative_Total()
        {
            // Arrange
            IDiscountHelper target = getTestObject();

            // Act
            target.ApplyDiscount(-1);
        }
    }
}
