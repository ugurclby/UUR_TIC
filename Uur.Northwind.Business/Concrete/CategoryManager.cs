using System;
using System.Collections.Generic;
using System.Text;
using Uur.Northwind.Business.Abstract;
using Uur.Northwind.DataAccess.Abstract;
using Uur.Northwind.Entities.Concrete;

namespace Uur.Northwind.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public List<Category> GetAll()
        {
            return _categoryDal.GetList();
        }
    }
}
