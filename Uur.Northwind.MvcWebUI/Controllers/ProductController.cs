using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uur.Northwind.Business.Abstract;
using Uur.Northwind.MvcWebUI.Models;

namespace Uur.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public ActionResult Index(int page=1,int categoryId = 0)
        {
            int pageSize = 10;
            var products = _productService.GetByCategory(categoryId);
            /*_productService.GetAll().Skip((page - 1) * pageSize).Take(pageSize).ToList();*/

             ProductListViewModel productListViewModel = new ProductListViewModel
            {
                products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList() ,
                PageCount = (int)Math.Ceiling(products.Count/(double)pageSize),
                PageSize = pageSize,
                CurrentCategory = categoryId,
                CurrentPage = page
             };
            return View(productListViewModel);
        } 
    }
}
