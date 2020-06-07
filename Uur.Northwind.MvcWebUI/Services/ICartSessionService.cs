using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uur.Northwind.Entities.Concrete;

namespace Uur.Northwind.MvcWebUI.Services
{
    public interface ICartSessionService
    {
        Cart GetCart();
        void SetCart(Cart cart);
    }
}
