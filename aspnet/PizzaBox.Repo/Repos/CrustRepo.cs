using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storage;

namespace PizzaBox.Repo.Repos
{
  public class CrustRepo : AllRepo
  {
    private PizzaBoxContext _context;
    public CrustRepo(PizzaBoxContext _db)
    {
      _context = _db;
    }
    public IEnumerable<Crust> ReadCrust()
    {
        return _db.Crust;
    }
    public void DisplayCrust()
    {
        DisplayItem(ReadCrust());
    }

    public Crust ReadOneCrust(string Name)
    {
        return _db.Crust.FirstOrDefault(s => s.name.Equals(Name));
    }

    public Crust ReadOneCrust(int UserInput)
    {
        return _db.Crust.ToList().ElementAt(UserInput);
    }
  }
}
