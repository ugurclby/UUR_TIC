using System;
using System.Collections.Generic;
using System.Text;
using Uur.Core.Entities;

namespace Uur.Northwind.Entities.Concrete
{
   public class Product:IEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }

    }
}
