using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storage;

namespace PizzaBox.Repo.Repos
{
  public class ToppingRepo
  {

      private PizzaBoxContext _context;
      public ToppingRepo(PizzaBoxContext _db)
      {
        _context = _db;
      }
      public IEnumerable<Topping> ReadToppings()
      {
          return _context.Topping;
      }

      public Topping ReadOneTopping(int UserInt)
      {
          return _context.Topping.ToList().ElementAt(UserInt);
      }

      public Topping ReadOneTopping(string Name)
      {
          return _context.Topping.FirstOrDefault(s => s.name.Equals(Name));
      }
  }
}
