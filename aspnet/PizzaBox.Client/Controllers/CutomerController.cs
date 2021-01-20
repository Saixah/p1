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
      else
      {
        Customer.Users = Repo.UserRepo.ReadUser();
        return View("Customer",Customer);
      }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ExistingUser(CustomerViewModel Customer)
    {
      if(ModelState.IsValid)
      {
        Customer.User = Repo.UserRepo.ReadOneUser(Customer.Username);
        Customer.OrderHistory = Repo.OrderRepo.GetOrderByUser(Customer.User);
        return View("CustomerDetails",Customer);
      }
      else
      {
        Customer.Users = Repo.UserRepo.ReadUser();
        return View("Customer",Customer);
      }
    }

    [HttpGet("/Stores/{id}")]
    public IActionResult DisplayStores(string id)
    {
      if(id != null)
      {
        var Stores = new StoreViewModel(Repo);
        Stores.Username = RouteData.Values["id"].ToString();
        return View("Order", Stores);
      }
      else
      {
        return RedirectToAction("GetUser");
      }
    }

    [HttpPost("/Stores/{id}")]
    [ValidateAntiForgeryToken]
    public IActionResult SelectStore(string id,StoreViewModel Store)
    {
      if(ModelState.IsValid)
      {
        User _user = new User();
        _user = Repo.UserRepo.ReadOneUser(id);
        _user.ChosenStore = Repo.StoreRepo.ReadOneStore(Store.StoreName);
        Repo.UserRepo.UpdateUser(_user);
        Repo.Save();
        var Pizza = new PizzaViewModel(Repo);
        ViewBag.Username = _user.Name;
        return View("AddPizza",Pizza);
      }
      else
      {
        Store.Stores = Repo.StoreRepo.ReadStores();
        return View("Order",Store);
      }
    }

    [HttpPost("/MakeNewPizza/{id}")]
    [ValidateAntiForgeryToken]
    public IActionResult MakeNewPizza(string id,string orderid,PizzaViewModel Pizza)
    {
      if(ModelState.IsValid)
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
      var Order = new OrderViewModel();

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
      else
      {
        Pizza.DisplayCrusts = Repo.CrustRepo.ReadCrust();
        Pizza.DisplaySizes = Repo.SizeRepo.ReadSize();
        Pizza.DisplayToppings = Repo.ToppingRepo.ReadToppings();
        return View("AddPizza",Pizza);
      }
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
