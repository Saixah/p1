using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Repo.Repos;

namespace PizzaBox.Client.Controllers
{
    [Route("[controller]")]
    public class OrderController : Controller
    {
      private AllRepo Repo;
      private OrderViewModel Order;
      private CustomerViewModel Customer;
      public OrderController(AllRepo _repo)
      {
        Repo = _repo;
        Order = new OrderViewModel();
      }

      [HttpGet]
      public IActionResult GetStore(CustomerViewModel _customer)
      {
        if (ModelState.IsValid)
        {
          Customer = _customer;
          Order.Stores = Repo.StoreRepo.ReadStores();
          return View("Order",Order);
        }
        return RedirectToAction("Customer","Get");
      }

      [HttpPost]
      public IActionResult SelectStore(string Storename)
      {
        Order.Store = Repo.StoreRepo.ReadOneStore(Storename);
        Customer.User.ChosenStore = Order.Store;
        return View("Order",Order);
      }

      // public IActionResult MakeNewPizza(PizzaViewModel Pizza)
      // {
      //   if(ModelState.IsValid)
      //   {
      //     Order.Pizza.Crust = Pizza.Crust;
      //     Order.Pizza.Size = Pizza.Size;
      //     Order.Pizza.Toppings = Pizza.Toppings;
      //     Order.Pizzas.Add(Order.Pizza);
      //     return View("Order",Order);
      //   }
      //   return View("Order",Order);
      // }
    }
}
