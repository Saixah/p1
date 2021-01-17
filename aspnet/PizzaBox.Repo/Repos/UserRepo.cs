using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

    public void UpdateUser(User _user)
    {
      _context.Update(_user);
      _context.SaveChanges();
    }

    public User GetFullUserByName(string name)
    {
      return  _context.Users.Where(p => p.Name == name).Include(p => p.ChosenStore).First();
    }
  }
}
