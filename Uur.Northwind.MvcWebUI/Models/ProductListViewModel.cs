using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uur.Northwind.Entities.Concrete;

namespace Uur.Northwind.MvcWebUI.Models
{
    public class ProductListViewModel
    {
        public List<Product> products { get; set; }
        public int PageCount { get; internal set; }
        public int PageSize { get; internal set; }
        public int CurrentCategory { get; internal set; }
        public int CurrentPage { get; internal set; }
    }
}
