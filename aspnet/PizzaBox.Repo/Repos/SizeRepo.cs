using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storage;

namespace PizzaBox.Repo.Repos
{
  public class SizeRepo : AllRepo
  {

      private PizzaBoxContext _context;
      public SizeRepo(PizzaBoxContext _db)
      {
        _context = _db;
      }
      public IEnumerable<Size> ReadSize()
        {
            return _db.Size;
        }

        public void DisplaySize()
        {
            DisplayItem(ReadSize());
        }

        public Size ReadOneSize(string Name)
        {
            return _db.Size.FirstOrDefault(s => s.name.Equals(Name));
        }

        public Size ReadOneSize(int UserInput)
        {
            return _db.Size.ToList().ElementAt(UserInput);
        }
  }
}
