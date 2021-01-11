using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storage;

namespace PizzaBox.Repo.Repos
{
  public class UserRepo : AllRepo
  {
    private PizzaBoxContext _context;
    public UserRepo(PizzaBoxContext _db)
    {
      _context = _db;
    }
    public IEnumerable<User> ReadUser()
    {
        return _db.Users;
    }
    public User ReadOneUser(int UserInt)
    {
        return _db.Users.ToList().ElementAt(UserInt);
    }
    public void DisplayUser()
    {
        DisplayItem(ReadUser());
    }

    public void AddUser(User User)
    {
        _db.Add(User);
    }
  }
}
