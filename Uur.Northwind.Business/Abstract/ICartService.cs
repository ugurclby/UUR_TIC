using System;
using System.Collections.Generic;
using System.Text;
using Uur.Northwind.Entities.Concrete;

namespace Uur.Northwind.Business.Abstract
{
    public interface ICartService
    {
        void AddToCart(Cart cart, Product product);
        void RemoveCart(Cart cart, int productId);
        List<CartLine> List(Cart cart);
    }
}
