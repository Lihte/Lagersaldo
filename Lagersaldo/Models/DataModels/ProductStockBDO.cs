using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lagersaldo.Models.DataModels
{
    public class ProductStockDBO
    {
        public string ProductNr { get; set; }
        public string ShelfID { get; set; }
        public int Quantity { get; set; }
    }
}