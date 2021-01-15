using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Repo.Repos;

namespace PizzaBox.Client.Controllers
{
  [Route("[controller]")]
  public class CustomerController : Controller
  {
    private AllRepo Repo;
    private CustomerViewModel Customer;
    private OrderViewModel Order;
    private PizzaViewModel Pizza;

    public CustomerController(AllRepo _repo)
    {
      Repo = _repo;
    }

    [HttpGet("/Customer")]
    public IActionResult GetUser()
    {
      return View("Customer", new CustomerViewModel(Repo));
    }

    [HttpPost("/New")]
    [ValidateAntiForgeryToken]
    public IActionResult NewUser(CustomerViewModel Customer)
    {
      if(ModelState.IsValid)
      {
        Repo.UserRepo.AddUser(new User(Customer.Username));
        Repo.Save();
        return RedirectToAction("GetUser");
      }
      else { return View("Customer",Customer);  }
    }

    [HttpPost("/Details")]
    [ValidateAntiForgeryToken]
    public IActionResult ExistingUser(CustomerViewModel Customer)
    {
      Customer.User = Repo.UserRepo.ReadOneUser(Customer.Username);
      Customer.OrderHistory = Repo.OrderRepo.GetOrderByUser(Customer.User);
      return View("CustomerDetails",Customer);
    }

    [HttpGet("/CustomerStores/{id}")]
    public IActionResult DisplayStores(string id)
    {
      Order = new OrderViewModel(Repo);
      Order.Username = RouteData.Values["id"].ToString();
      return View("Order", Order);
    }

    [HttpPost("/SelectStore")]
    [ValidateAntiForgeryToken]
    public IActionResult SelectStore(string id,OrderViewModel Order)
    {
      User user = new User();
      user = Repo.UserRepo.ReadOneUser(id);
      user.ChosenStore = Repo.StoreRepo.ReadOneStore(Order.StoreName);
      Repo.Save();
      var Pizza = new PizzaViewModel(Repo);
      return View("AddPizza",Pizza);
    }

    [HttpPost("/MakeNewPizza")]
    [ValidateAntiForgeryToken]
    public IActionResult MakeNewPizza(PizzaViewModel Pizza)
    {
      var _order = new Order();
      APizzaModel _pizza = new APizzaModel();
      _pizza.Toppings = new List<Topping>();
      _pizza.Crust = Repo.CrustRepo.ReadOneCrust(Pizza.CrustName);
      _pizza.Size = Repo.SizeRepo.ReadOneSize(Pizza.SizeName);
      foreach(var topping in Pizza.ToppingsNames)
      {
        _pizza.Toppings.Add(Repo.ToppingRepo.ReadOneTopping(topping));
      }
      _order.Pizzas.Add(_pizza);
      Order = new OrderViewModel();
      Order.Pizzas = _order.Pizzas;
      return View("OrderList",Order);
    }
  }
}
