using Abc.Northwind.Entities.Concrete;
using Abc.Northwind.MvcWebUI.ExtentionMethods;

namespace Abc.Northwind.MvcWebUI.Services
{
    public class CartSessionService : ICartSessionService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public CartSessionService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public Cart GetCart()
        {
           Cart cartToCheck = _contextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            if (cartToCheck == null) 
            {
                _contextAccessor.HttpContext.Session.SetObject("cart", new Cart());
                cartToCheck = _contextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            }
            return cartToCheck;
        }

        public void SetCart(Cart cart)
        {
            _contextAccessor.HttpContext.Session.SetObject("cart", cart);
        }
    }
}
