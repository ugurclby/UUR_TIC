using System;
using System.Collections.Generic;
using System.Text;
using Uur.Core.DataAccess.EntityFramework;
using Uur.Northwind.DataAccess.Abstract;
using Uur.Northwind.Entities.Concrete;

namespace Uur.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal:EfEntityRepositoryBase<Product, NorthWindContext>,IProductDal
    {

    }

}
