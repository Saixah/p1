using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storage;

namespace PizzaBox.Repo.Repos
{
  public class PizzaRepo
  {
    private PizzaBoxContext _context;
    public PizzaRepo(PizzaBoxContext _db)
    {
      _context = _db;
    }

    public IEnumerable<APizzaModel> ReadPizzas()
    {
        return _context.Pizzas;
    }
     public APizzaModel FindByID(long id)
    {
      return _context.Pizzas.SingleOrDefault(s => s.EntityId == id);
    }
    public decimal GetPriceOfPizza(long pizzaid)
    {
      APizzaModel pizza = FindByID(pizzaid);
      decimal piePrice = 0;
      piePrice += pizza.Crust.price;
      piePrice += pizza.Size.price;
      foreach(var topping in pizza.Toppings)
      {
        piePrice+=topping.price;
      }
      return piePrice;
    }
  }
}
