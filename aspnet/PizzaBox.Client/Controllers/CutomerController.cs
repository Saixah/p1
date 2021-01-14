using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PizzaBox.Client.Models;
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
      Order = new OrderViewModel();
      Customer = new CustomerViewModel();
    }

    [HttpGet("/Customer")]
    public IActionResult GetUser()
    {
      Customer.Users = Repo.UserRepo.ReadUser();
      return View("Customer", Customer);
    }

    [HttpPost("/New")]
    public IActionResult NewUser(string Username)
    {
        Customer.Username = Username;
        Repo.UserRepo.AddUser(new User(Customer.Username));
        Repo.Save();
        return RedirectToAction("GetUser");
    }

    [HttpPost("/Details")]
    public IActionResult ExistingUser(CustomerViewModel Customer, string Username)
    {
      Customer.Username = Username;
      Customer.User = Repo.UserRepo.ReadOneUser(Customer.Username);
      Customer.OrderHistory = Repo.OrderRepo.GetOrderByUser(Customer.User);
      return View("CustomerDetails",Customer);
    }

    [HttpGet("/GetStore")]
    public IActionResult GoToOrder()
    {
      Order.Stores = Repo.StoreRepo.ReadStores();
      return View("Order", Order);
    }

    [HttpPost]
    public IActionResult RedirectToPizza(string StoreName)
    {
      Order.Store = Repo.StoreRepo.ReadOneStore(StoreName);
      return RedirectToAction("GetPizzaOptions");
    }

    [HttpGet("/AddPizza")]
    public IActionResult GetPizzaOptions()
    {
      Pizza = new PizzaViewModel();
      Pizza.DisplayCrusts = Repo.CrustRepo.ReadCrust();
      Pizza.DisplaySizes = Repo.SizeRepo.ReadSize();
      Pizza.DisplayToppings = Repo.ToppingRepo.ReadToppings();
      return View("AddPizza",Pizza);
    }

    [HttpPost("/MakeNewPizza")]
    public IActionResult MakeNewPizza(PizzaViewModel Pizza)
    {
      return RedirectToAction("AddPizzaToOrder",Pizza);
    }

    [HttpGet("/AddPizzaToOrder")]
    public ActionResult AddPizzaToOrder(PizzaViewModel Pizza)
    {
        Order.Pizza.Crust = Pizza.Crust;
        Order.Pizza.Size = Pizza.Size;
        Order.Pizza.Toppings = Pizza.Toppings;
        Order.Pizzas.Add(Order.Pizza);
        return View("AddPizza");
    }
  }
}
