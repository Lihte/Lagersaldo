using Lagersaldo.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lagersaldo.Models.ViewModels
{
    public class ProductsInStockViewModel
    {
        public List<ProductStockDBO> availableProducts;

        public string ProductNr { get; set; }
    }
}