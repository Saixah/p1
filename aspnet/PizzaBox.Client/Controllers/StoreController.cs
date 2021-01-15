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
        Store.Store = Repo.StoreRepo.ReadOneStore(Store.StoreName);
        Store.OrderHistory = Repo.OrderRepo.GetOrderByStore(Store.Store);
        return View("StoreDetails",Store);
      }

    }
}
