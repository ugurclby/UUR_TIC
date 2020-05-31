using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uur.Northwind.Business.Abstract;
using Uur.Northwind.MvcWebUI.Models;

namespace Uur.Northwind.MvcWebUI.ViewComponents
{
    public class CategoryListViewComponent:ViewComponent
    {
        private ICategoryService _categoryService;

        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ViewViewComponentResult Invoke()
        {
            CategoryListViewModel categoryListViewModel = new CategoryListViewModel
            {
                Categories = _categoryService.GetAll(),
                CurrentCategoryId = Convert.ToInt32(HttpContext.Request.Query["CategoryId"])
            };
            return View(categoryListViewModel);
        }
    }
}
