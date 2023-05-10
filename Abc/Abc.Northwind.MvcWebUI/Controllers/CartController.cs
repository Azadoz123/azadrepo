using Abc.Northwind.Business.Abstract;
using Abc.Northwind.Entities.Concrete;
using Abc.Northwind.MvcWebUI.Models;
using Abc.Northwind.MvcWebUI.Services;
using Abc.Northwind.MvcWebUI.ViewComponents;
using Microsoft.AspNetCore.Mvc;

namespace Abc.Northwind.MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private ICartSessionService _cartSessionService;
        private ICartService _cartService;
        private IProductService _productService;

        public CartController(IProductService productService, ICartService cartService, ICartSessionService cartSessionService)
        {
            _productService = productService;
            _cartService = cartService;
            _cartSessionService = cartSessionService;
        }

        public IActionResult AddToCart(int productId)
        {
            var productToBeAdded = _productService.GetById(productId);

            var cart = _cartSessionService.GetCart();

            _cartService.AddToCart(cart, productToBeAdded);

            _cartSessionService.SetCart(cart);

            TempData.Add("message", string.Format("Your product, {0}, was successfully added to the cart!", productToBeAdded.ProductName));

            return RedirectToAction("Index", "Product");
        }

        public IActionResult List()
        {
            var cart = _cartSessionService.GetCart();

            CartSummaryViewModel cartSummaryViewModel= new CartSummaryViewModel
            {
                Cart = cart
            };
            return View(cartSummaryViewModel);
        }

        public IActionResult Remove(int productId)
        {
            var cart = _cartSessionService.GetCart();

            //var cartLine = cart.CartLines.FirstOrDefault(p=>p.Product.ProductId== productId);

            //cart.CartLines.Remove(cartLine);

            _cartService.RemoveFromCart(cart, productId);

            _cartSessionService.SetCart(cart);

            TempData.Add("message", string.Format("Your product was successfully deleted from the cart!"));

            return RedirectToAction("List");
            //return View();
        }

        public IActionResult Complete()
        {
            //Category category = new Category();
            var shippingDetailsViewModel = new ShippingDetailsViewModel
            {
                ShippingDetails = new ShippingDetails()
            };

            //return View(shippingDetailsViewModel);
            return View(shippingDetailsViewModel);
            //return View(category);
        }
        [HttpPost]
        public IActionResult Complete(ShippingDetails shippingDetails)
        //public IActionResult Complete(Category category)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            TempData.Add("message", string.Format("Thank you {0}, your order is processing", shippingDetails.FirstName));
            return View();
        }
     }
}
