using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LanguageFeatures.Models;
using System.Linq;
using System.Text;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Navigate to a Url for an example";
        }

        public ViewResult Autoproperty()
        {
            // create a new product object
            Product myProduct = new Product();

            // set the prop value
            myProduct.Name = "Kayak";

            // get the prop
            string prodName = myProduct.Name;

            // create the view
            return View("Result", (object)String.Format("Product name: {0}", prodName));
        }

        public ViewResult CreateProduct()
        {
            // create a product with object initializtion syntx
            Product myProduct = new Product
            {
                ProductID = 100,
                Name = "Kayak",
                Description = "A boat for one person",
                Price = 275M,
                Category = "Watersports"
            };

            return View("Result", (object)String.Format("Category: {0}", myProduct.Category));
        }

        public  ViewResult UseExtension()
        {
            ShoppingCart cart = new ShoppingCart
            {
                Products = new List<Product>{
                    new Product{
                        Name="Kayak",
                        Price=275M},
                    new Product{
                        Name="Lifejacket",
                        Price=48.95M},
                    new Product{
                        Name="Soccer ball",
                        Price=19.5M},
                    new Product{
                        Name="Corner flag",
                        Price=34.95M}
                }
            };

            // get the total
            decimal cartTotal = cart.TotalPrices();

            return View("Result", (object)String.Format("Total: {0:c}", cartTotal));
        }

        public  ViewResult UseFilterExtensionMethod()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products=new List<Product>
                {
                    new Product
                    {
                        Name="Kayak",
                        Category="Watersports",
                        Price=275M
                    },
                    new Product
                    {
                        Name="Lifejacket",
                        Category="Watersports",
                        Price=48.95M
                    },
                    new Product
                    {
                        Name="Soccer ball",
                        Category="Soccer",
                        Price=19.50M
                    },
                    new Product
                    {
                        Name="Corner flag",
                        Category="Soccer",
                        Price=34.95M
                    }
                }
            };


            decimal total = 0;
            foreach (Product prod in products.Filter(prod => prod.Category == "Soccer" || prod.Price > 20))
            {
                total += prod.Price;
            }

            return View("Result", (object)String.Format("Total: {0}", total));
        }

        public ViewResult FindProducts()
        {
            Product[] products =
                {
                    new Product
                    {
                        Name="Kayak",
                        Category="Watersports",
                        Price=275M
                    },
                    new Product
                    {
                        Name="Lifejacket",
                        Category="Watersports",
                        Price=48.95M
                    },
                    new Product
                    {
                        Name="Soccer ball",
                        Category="Soccer",
                        Price=19.50M
                    },
                    new Product
                    {
                        Name="Corner flag",
                        Category="Soccer",
                        Price=34.95M
                    }
                };

            var foundProducts = products.OrderByDescending(e => e.Price).Take(3).Select(e => new { e.Name, e.Price });
            int count = 0;
            StringBuilder result = new StringBuilder();
            foreach (var p in foundProducts)
            {
                result.Append(String.Format("Price: {0} ", p.Price));
            }

            return View("Result", (object)result.ToString());
        }
    }
}