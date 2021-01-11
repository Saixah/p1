using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Repo.Repos;

namespace PizzaBox.Client.Controllers
{
    [Route("/")]
    public class StoreController : Controller
    {
      private AllRepo Repo = new AllRepo();

      [HttpGet]
      public IActionResult GetListOfStores()
      {
        var stores = Repo.StoreRepo.ReadStores();
        ViewBag.Stores = stores;
        return View("Store");
      }

      [Route("/Store/{name}")]
      public IActionResult GetStoreByName(string name)
      {
        var stores = Repo.StoreRepo.ReadOneStore(name);
        ViewBag.Stores = stores;
        return View("Store");
      }
    }
}
