using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lagersaldo.Models.DataModels
{
    public class Reservation
    {
        public string CustomerID { get; set; }
        public string ProductNr { get; set; }
        public string ShelfID { get; set; }
        public int OrderQuantity { get; set; }
        public int ProductsReady { get; set; }
    }
}