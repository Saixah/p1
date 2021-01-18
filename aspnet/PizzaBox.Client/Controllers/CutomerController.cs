using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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
    private OrderViewModel Order;

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
        Repo.UserRepo.AddUser(new User(Customer.Username));
        Repo.Save();
        return RedirectToAction("GetUser");
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
      if(id != null)
      {
        Order = new OrderViewModel(Repo);
        Order.Username = RouteData.Values["id"].ToString();
        return View("Order", Order);
      }
      else
      {
        return RedirectToAction("GetUser");
      }
    }

    [HttpPost("/SelectStore")]
    [ValidateAntiForgeryToken]
    public IActionResult SelectStore(string id,OrderViewModel Order)
    {
      User _user = new User();
      _user = Repo.UserRepo.ReadOneUser(id);
      _user.ChosenStore = Repo.StoreRepo.ReadOneStore(Order.StoreName);
      Repo.UserRepo.UpdateUser(_user);
      Repo.Save();
      var Pizza = new PizzaViewModel(Repo);
      ViewBag.Username = _user.Name;
      return View("AddPizza",Pizza);
    }

    [HttpPost("/MakeNewPizza")]
    [ValidateAntiForgeryToken]
    public IActionResult MakeNewPizza(string id,string orderid,PizzaViewModel Pizza)
    {
      User _user;
      Order _order;
      decimal Price = 0;

      _user = Repo.UserRepo.GetFullUserByName(id);

      if (orderid == null)
      {
         _order = new Order();
      }
      else
      {
        _order = Repo.OrderRepo.GetOrderById(long.Parse(orderid));
        Price = _order.Price;
      }

      ViewBag.OrderId = _order.EntityId;
      ViewBag.Username = _user.Name;

      APizzaModel _pizza = new APizzaModel();

      _pizza.Toppings = new List<Topping>();
      _pizza.Crust = Repo.CrustRepo.ReadOneCrust(Pizza.CrustName);
      _pizza.Size = Repo.SizeRepo.ReadOneSize(Pizza.SizeName);

      Price += _pizza.Crust.price;
      Price += _pizza.Size.price;
      foreach(var topping in Pizza.ToppingsNames)
      {
        var _topping = Repo.ToppingRepo.ReadOneTopping(topping);
        _pizza.Toppings.Add(_topping);
      //   Price+=_topping.price;
      }

      _order.Price = Price;
      _order.Store = _user.ChosenStore;
      _order.Pizzas.Add(_pizza);
      _user.Orders.Add(_order);
      ViewBag.OrderPrice = Price;

      Repo.Save();
      Order = new OrderViewModel();
      Order.PizzaViewModel = new PizzaViewModel();
      if(orderid ==null)
      {
        Order.Pizzas = _order.Pizzas;
      }
      else
      {
        var zaList = Repo.OrderRepo.GetOrdersByID(long.Parse(orderid)).Pizzas;
        var tempOrder = new List<APizzaModel>();
        var toppinglist = new List<Topping>();
        foreach(var za in zaList)
        {
          tempOrder.Add(Repo.OrderRepo.GetPizza(long.Parse(orderid),za.EntityId));
        }
        Order.Pizzas = tempOrder;
      }
      return View("OrderList",Order);
    }

    [HttpPost("/MakeAnother")]
    public IActionResult MakeAnother(string id, string orderid,OrderViewModel Order)
    {
      ViewBag.Username = id;
      ViewBag.OrderId = orderid;
      var Pizza = new PizzaViewModel(Repo);
      return View("AddPizza",Pizza);
    }

    [HttpPost("/Delete")]
    public IActionResult Delete(string pizzaid,string orderid,string id)
    {
      decimal NewPrice = new decimal();
      Order _order = Repo.OrderRepo.GetOrderById(long.Parse(orderid));
      APizzaModel _pizza = Repo.OrderRepo.GetPizza(long.Parse(orderid),long.Parse(pizzaid));

      NewPrice = _order.Price;
      NewPrice -= _pizza.Crust.price;
      NewPrice -= _pizza.Size.price;
      // foreach(var topping in _pizza.Toppings)
      // {
      //   NewPrice -= topping.price;
      // }

      Repo.OrderRepo.DeletePizzaByID(_pizza);
       _order.Price = NewPrice;
       ViewBag.OrderPrice = NewPrice;
      Repo.Save();

      var Order = new OrderViewModel();
      var zaList = Repo.OrderRepo.GetOrdersByID(long.Parse(orderid)).Pizzas;
        var tempOrder = new List<APizzaModel>();
        foreach(var za in zaList)
        {
          tempOrder.Add(Repo.OrderRepo.GetPizza(long.Parse(orderid),za.EntityId));
        }
      Order.Pizzas = tempOrder;
      ViewBag.Username = id;
      ViewBag.OrderId = orderid;
      return View("OrderList",Order);
    }
  }
}
