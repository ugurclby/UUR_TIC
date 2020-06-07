using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Uur.Northwind.Business.Abstract;
using Uur.Northwind.MvcWebUI.Services;

namespace Uur.Northwind.MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private ICartSessionService _cartSessionService;
        private ICartService _cartService;
        private IProductService _productService;

        public CartController(ICartSessionService cartSessionService,ICartService cartService,IProductService productService)
        {
            _cartSessionService = cartSessionService;
            _cartService = cartService;
            _productService = productService;
        }

        public ActionResult AddToCart(int productId)
        {
            var productToBeAdded = _productService.GetById(productId);

            var cart = _cartSessionService.GetCart();

            _cartService.AddToCart(cart, productToBeAdded);
            
            _cartSessionService.SetCart(cart);

            TempData.Add("message", string.Format("Your product {0},was successfully added to cart !", productToBeAdded.ProductName));

            return RedirectToAction("Index","Product");
        }
    }
}