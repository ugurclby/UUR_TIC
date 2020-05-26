using System;
using System.Collections.Generic;
using System.Text;
using Uur.Core.DataAccess;
using Uur.Northwind.Entities.Concrete;

namespace Uur.Northwind.DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
        //Category ile ilgili Özel operasyonlar yapılabileceği için oluşturuldu.
    }
}
