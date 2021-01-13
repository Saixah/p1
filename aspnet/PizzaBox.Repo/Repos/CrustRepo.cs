using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storage;

namespace PizzaBox.Repo.Repos
{
  public class CrustRepo
  {
    private PizzaBoxContext _context;
    public CrustRepo(PizzaBoxContext _db)
    {
      _context = _db;
    }
    public IEnumerable<Crust> ReadCrust()
    {
        return _context.Crust;
    }

    public Crust ReadOneCrust(string Name)
    {
        return _context.Crust.FirstOrDefault(s => s.name.Equals(Name));
    }

    public Crust ReadOneCrust(int UserInput)
    {
        return _context.Crust.ToList().ElementAt(UserInput);
    }
  }
}
