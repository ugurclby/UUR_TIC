using System;
using System.Collections.Generic;
using System.Text;
using Uur.Northwind.Entities.Concrete;

namespace Uur.Northwind.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetByCategory(int CategoryId);
        void Add(Product product);
        void Update (Product product);
        void Delete(int ProductId);
    }
}

