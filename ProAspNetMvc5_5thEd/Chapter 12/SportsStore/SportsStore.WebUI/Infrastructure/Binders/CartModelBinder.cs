using System.Web.Mvc;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Infrastructure.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // get the cart from the session
            Cart cart = null;
            if (null != controllerContext.HttpContext.Session)
            {
                cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
            }

            // create a cart if there wasn't one in session data (or if there wasn't session data)
            if (null == cart)
            {
                cart = new Cart();
                if (null != controllerContext.HttpContext.Session)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }

            return cart;
        }
    }
}