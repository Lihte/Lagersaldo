using System.Collections.Generic;
using System.Linq;

using Lagersaldo.Models.DataModels;

namespace Lagersaldo.Repositories
{
    // I ett större projekt skulle jag göra fler enskilda repositorier för olika typer eller context implementerade med kontrakt
    public class Repository
    {
        // Fake-databaser
        private List<Reservation> _reservations;
        private List<ProductStockDBO> _stock;

        public Repository()
        {
            // Testdata
            _stock = new List<ProductStockDBO>()
            {
                new ProductStockDBO { ProductNr = "A", ShelfID = "h1", Quantity = 5 },
                new ProductStockDBO { ProductNr = "B", ShelfID = "h1", Quantity = 6 },
                new ProductStockDBO { ProductNr = "B", ShelfID = "h2", Quantity = 3 },
                new ProductStockDBO { ProductNr = "C", ShelfID = "h2", Quantity = 2 },
                new ProductStockDBO { ProductNr = "C", ShelfID = "h3", Quantity = 3 }
            };
            _reservations = new List<Reservation>()
            {
                new Reservation { CustomerID = "k1", ProductNr = "a", ShelfID = "h1", OrderQuantity = 3, ProductsReady = 1 },
                new Reservation { CustomerID = "k1", ProductNr = "b", ShelfID = "h1", OrderQuantity = 2, ProductsReady = 1 },
                new Reservation { CustomerID = "k2", ProductNr = "c", ShelfID = "h2", OrderQuantity = 2, ProductsReady = 2 },
                new Reservation { CustomerID = "k2", ProductNr = "a", ShelfID = "h1", OrderQuantity = 1, ProductsReady = 0 },
                new Reservation { CustomerID = "k3", ProductNr = "b", ShelfID = "h1", OrderQuantity = 2, ProductsReady = 1 }
            };
        }

        public IEnumerable<Reservation> GetReservations()
        {
            return _reservations;
        }

        public IEnumerable<ProductStockDBO> GetStock()
        {
            return _stock;
        }

        // Kan ev. flyttas ut till controllern
        public IEnumerable<ProductStockDBO> GetAvailableStock()
        {
            List<ProductStockDBO> list = _stock;

            // Olika case på ProductNr i DB för reservationer och lagerstatus - formaterar till uppercase vid antagandet att de syftar till samma produkter.
            foreach (var res in _reservations)
            {
                var hit = list.SingleOrDefault(p => p.ProductNr.ToUpperInvariant() == res.ProductNr.ToUpperInvariant() && p.ShelfID == res.ShelfID);
                if (hit != null)
                    hit.Quantity = hit.Quantity - res.OrderQuantity > 0 ? hit.Quantity - res.OrderQuantity : 0;
            }

            return list;
        }
    }
}