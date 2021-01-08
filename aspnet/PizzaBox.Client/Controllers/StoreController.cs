using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
    [Route("[controller]")]
    public class StoreController : Controller
    {

      [HttpGet]
      public IActionResult Get()
      {
        var stores = new StoreViewModel();

        //1 way-data binding, action to view
        ViewBag.Stores = stores.Stores; //dynamic object;
        ViewData["Stores"] = stores.Stores; //dictionary Object
        TempData["Stores"] = stores.Stores; //2 way
        return View("Store", new StoreViewModel());
      }

      [HttpGet("{store}")]
      public IActionResult Get(string Store)
      {
        return View("Store", Store);
      }

    }
}
