using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storage;

namespace PizzaBox.Repo.Repos
{
  public class UserRepo
  {
    private PizzaBoxContext _context;
    public UserRepo(PizzaBoxContext _db)
    {
      _context = _db;
    }
    public IEnumerable<User> ReadUser()
    {
        return _context.Users;
    }
    public User ReadOneUser(int UserInt)
    {
        return _context.Users.ToList().ElementAt(UserInt);
    }

    public User FindByID(long id)
    {
      return _context.Users.SingleOrDefault(s => s.EntityId == id);
    }
    public User ReadOneUser(string Name)
    {
        return _context.Users.SingleOrDefault(s => s.Name == Name);
    }
    public void AddUser(User User)
    {
        _context.Add(User);
    }
  }
}
