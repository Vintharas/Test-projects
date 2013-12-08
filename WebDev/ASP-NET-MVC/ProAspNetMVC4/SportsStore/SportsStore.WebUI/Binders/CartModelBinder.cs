using System.Web.Mvc;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Binders
{
    public class CartModelBinder :IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext,  // The ControllerContext provides all the information the Controller has (including the request)
                                ModelBindingContext bindingContext) // The binding context gives information about the model object you are being asked to build and tools for making the binding process easier
        {
            // Get the Cart from the session
            Cart cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
            // Create the Cart from the session
            if (cart == null)
            {
                cart = new Cart();
                controllerContext.HttpContext.Session[sessionKey] = cart;
            }

            return cart;
        }
    }
}