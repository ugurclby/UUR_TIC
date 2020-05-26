using System;
using System.Collections.Generic;
using System.Text;
using Uur.Core.Entities;

namespace Uur.Northwind.Entities.Concrete
{
    public class Category:IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
