using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Repo.Repos;

namespace PizzaBox.Client.Controllers
{
    [Route("/")]
    public class StoreController : Controller
    {

      // [HttpGet]
      // public IActionResult GetListOfStores()
      // {
      //   ViewBag.Stores  = Repo.StoreRepo.ReadStores();
      //   return View("Store");
      // }

      // [Route("/Store/{name}")]
      // public IActionResult GetStoreByName(string name)
      // {
      //   var stores = Repo.StoreRepo.ReadOneStore(name);
      //   ViewBag.Stores = stores;
      //   return View("Store");
      // }
    }
}
