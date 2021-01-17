using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Repo.Repos;

namespace PizzaBox.Client.Controllers
{
    [Route("{controller}")]
    public class StoreController : Controller
    {
      private StoreViewModel StoreViewModel;
      private AllRepo Repo;
      public StoreController(AllRepo _repo)
      {
        Repo = _repo;
        StoreViewModel = new StoreViewModel();
      }

      [HttpGet("Select")]
      public IActionResult DisplayStores()
      {
        StoreViewModel.Stores = Repo.StoreRepo.ReadStores();
        return View("Store",StoreViewModel);
      }

      [HttpPost("StoreDetails")]
      public IActionResult StoreDetails(StoreViewModel Store)
      {
        int diff = (7 + (DateTime.Now.DayOfWeek - DayOfWeek.Sunday)) % 7;
        DateTime StartOfWeek = DateTime.Now.AddDays(-1 * diff).Date;
        DateTime StartOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        DateTime StartOfYear = new DateTime(DateTime.Now.Year,1,1);

        Store.Store = Repo.StoreRepo.ReadOneStore(Store.StoreName);
        Store.OrderHistory = Repo.OrderRepo.GetOrderByStore(Store.Store);
        Store.WeeklyRev = Repo.GetStoreRevenue(StartOfWeek,Store.Store);
        Store.MonthlyRev = Repo.GetStoreRevenue(StartOfMonth,Store.Store);
        Store.YearlyRev = Repo.GetStoreRevenue(StartOfYear,Store.Store);
        return View("StoreDetails",Store);
      }

    }
}
