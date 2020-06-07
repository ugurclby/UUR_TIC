﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uur.Northwind.Entities.Concrete;
using Uur.Northwind.MvcWebUI.ExtensionMethods;

namespace Uur.Northwind.MvcWebUI.Services
{
    public class CartSessionService : ICartSessionService
    {
        private IHttpContextAccessor _httpContextAccessor;

        public CartSessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Cart GetCart()
        {
            Cart cart = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");

            if (cart == null)
            {
                _httpContextAccessor.HttpContext.Session.SetObject("cart", new Cart());
                cart = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            }
            return cart;
        }

        public void SetCart(Cart cart)
        {
            _httpContextAccessor.HttpContext.Session.SetObject("cart", cart);
        }
    }
}
