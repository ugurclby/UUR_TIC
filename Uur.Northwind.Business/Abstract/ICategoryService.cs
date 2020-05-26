using System;
using System.Collections.Generic;
using System.Text;
using Uur.Northwind.Entities.Concrete;

namespace Uur.Northwind.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll(); 
    }
}
