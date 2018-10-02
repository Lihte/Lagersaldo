using System.Collections.Generic;
using System.Web.Mvc;

using Lagersaldo.Models.DataModels;
using Lagersaldo.Models.ViewModels;
using Lagersaldo.Repositories;

///  Syftet med den här programmeringsuppgiften är att du ska visa oss hur du tänker kring problemlösning och kod.
///  Vi förväntar oss att du lägger 2-3 timmar på uppgiften.
///  Din lösning kommer att vara underlag för samtal med utvecklare. Det viktiga är hur du resonerar, inte att du har en fullständig applikation.

///  Tabellerna nedan visar aktuell lagerstatus och reservationer.
///  Kundtjänst behöver veta hur många artiklar av ett givet artikelnummer som finns för försäljning.  Gör en översiktlig design samt skriv kod för att ta fram en lista med tillgängligt lagersaldo per artikel. 

///  tblLager 
///  artikel hylla antal       
///  A       h1    5       
///  B       h1    6       
///  B       h2    3       
///  C       h2    2       
///  C       h3    3      
///
///  tblReservationer
///  kund artikel hylla beställt-antal plockatantal    
///  k1   a       h1    3              1     
///  k1   b       h1    2              1    
///  k2   c       h2    2              2     
///  k2   a       h1    1              0     
///  k3   b       h1    2              1

namespace Lagersaldo.Controllers
{
    public class StockController : Controller
    {
        // I skarpt läge skulle repositoriet användas genom ett interface och dependency injection
        private Repository _repo;

        public StockController() : base()
        {
            _repo = new Repository();
        }

        public ActionResult Index(string productNr)
        {
            var availableProducts = _repo.GetAvailableStock();

            var viewModel = new ProductsInStockViewModel() { availableProducts = new List<ProductStockDBO>() };

            // Om productNr är tom, hämta alla, annars hämta artiklar med samma nr
            foreach (var p in availableProducts)
            {
                if (string.IsNullOrEmpty(productNr) || p.ProductNr == productNr)
                {
                    viewModel.availableProducts.Add(new ProductStockDBO()
                    {
                        ProductNr = p.ProductNr,
                        ShelfID = p.ShelfID,
                        Quantity = p.Quantity
                    });
                }
            }
            return View(viewModel);
        }
    }
}