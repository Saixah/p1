using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storage;

namespace PizzaBox.Repo.Repos
{
  public class SizeRepo
  {

      private PizzaBoxContext _context;
      public SizeRepo(PizzaBoxContext _db)
      {
        _context = _db;
      }
      public IEnumerable<Size> ReadSize()
        {
            return _context.Size;
        }

        public Size ReadOneSize(string Name)
        {
            return _context.Size.FirstOrDefault(s => s.name.Equals(Name));
        }

        public Size ReadOneSize(int UserInput)
        {
            return _context.Size.ToList().ElementAt(UserInput);
        }
  }
}
