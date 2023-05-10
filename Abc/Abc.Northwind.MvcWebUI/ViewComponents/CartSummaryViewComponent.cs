using Abc.Northwind.MvcWebUI.Models;
using Abc.Northwind.MvcWebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Abc.Northwind.MvcWebUI.ViewComponents
{
    public class CartSummaryViewComponent: ViewComponent
    {
        private ICartSessionService _sessionService;

        public CartSummaryViewComponent(ICartSessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new CartSummaryViewModel
            {
                Cart = _sessionService.GetCart()
            };
         
        return View(model);
        }
    }
}
