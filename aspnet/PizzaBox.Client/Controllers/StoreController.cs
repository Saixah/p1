using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Repo.Repos;

namespace PizzaBox.Client.Controllers
{
    [Route("[controller]")]
    public class StoreController : Controller
    {
      private AllRepo Repo = new AllRepo();

      [HttpGet]
      [Route("/stores")]
      public IActionResult GetListOfStores()
      {
        //  var stores = new StoreViewModel();
        var stores = Repo.StoreRepo.ReadStores();
        //1 way-data binding, action to view
        ViewBag.Stores = stores; //dynamic object;
        // ViewData["Stores"] = stores.Stores; //dictionary Object
        // TempData["Stores"] = stores.Stores; //2 way
        return View("Store");
      }

      // [HttpGet("{store}")]
      // public IActionResult Get(string Store)
      // {
      //   return View("Store", Store);
      // }

    }
}
