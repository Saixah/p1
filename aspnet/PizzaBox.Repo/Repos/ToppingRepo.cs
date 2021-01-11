using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storage;

namespace PizzaBox.Repo.Repos
{
  public class ToppingRepo : AllRepo
  {

      private PizzaBoxContext _context;
      public ToppingRepo(PizzaBoxContext _db)
      {
        _context = _db;
      }
      public IEnumerable<Topping> ReadToppings()
      {
          return _db.Topping;
      }

      public Topping ReadOneTopping(int UserInt)
      {
          return _db.Topping.ToList().ElementAt(UserInt);
      }

      public void DisplayToppings()
      {
          DisplayItem(ReadToppings());
      }

      public Topping ReadOneTopping(string Name)
      {
          return _db.Topping.FirstOrDefault(s => s.name.Equals(Name));
      }
  }
}
