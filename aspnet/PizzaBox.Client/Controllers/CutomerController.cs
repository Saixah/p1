using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Repo.Repos;
using PizzaBox.Storage;

namespace PizzaBox.Client.Controllers
{
    [Route("[controller]")]
    public class CustomerController : Controller
    {
      private AllRepo Repo;
      private CustomerViewModel Customer;
      public CustomerController(AllRepo _repo)
      {
        Repo = _repo;
        Customer = new CustomerViewModel();
      }

      [HttpGet]
      public IActionResult Get()
      {
        Customer.Users = Repo.UserRepo.ReadUser();
        return View("Customer", Customer);
      }

      [HttpGet("Details")]
      public IActionResult CustomerDetails()
      {
        if(ModelState.IsValid)
        {
          return View("CustomerDetails");
        }
        else
        {
           return View("Customer");
        }
      }

      [HttpPost("New")]
      public IActionResult NewUser(AllRepo _repo,string Name,CustomerViewModel customer)
      {
        if(ModelState.IsValid)
        {
          return RedirectToAction("Get");
        }
        return RedirectToAction("Get");
      }

      [HttpPost]
      public IActionResult SendUser(string Username)
      {
        Customer.User = Repo.UserRepo.ReadOneUser(Username);
        return View("CustomerDetails", Customer);
      }
    }
}
