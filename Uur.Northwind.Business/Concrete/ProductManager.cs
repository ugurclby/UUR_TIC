using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uur.Northwind.Business.Abstract;
using Uur.Northwind.DataAccess.Abstract;
using Uur.Northwind.Entities.Concrete;

namespace Uur.Northwind.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public List<Product> GetByCategory(int CategoryId)
        {
            return _productDal.GetList().Where(cat => cat.CategoryID == CategoryId).ToList();
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
