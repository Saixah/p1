using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storage;

namespace PizzaBox.Repo.Repos
{
  public class StoreRepo
  {
    private PizzaBoxContext _context;
    public StoreRepo(PizzaBoxContext _db)
    {
      _context = _db;
    }
    public IEnumerable<Store> ReadStores()
    {
      return _context.Stores;
    }
    public Store ReadOneStore(string Name)
    {
      return _context.Stores.SingleOrDefault(s => s.Name == Name);
    }

    public Store ReadOneStore(int UserInt)
    {
      return _context.Stores.ToList().ElementAt(UserInt);
    }

    public List<APizzaModel> GetPizzasFromStore(string StoreName)
    {
      return ReadOneStore(StoreName).Pizzas;
    }

  }
}
