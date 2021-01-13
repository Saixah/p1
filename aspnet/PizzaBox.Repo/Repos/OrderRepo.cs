using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storage;

namespace PizzaBox.Repo.Repos
{
  public class OrderRepo
  {

    private PizzaBoxContext _context;
    public OrderRepo(PizzaBoxContext _db)
    {
      _context = _db;
    }

    public IEnumerable<Order> ReadOrders()
    {
        return _context.Orders;
    }
    public IEnumerable<Order> GetOrderByStore(Store Store)
    {
        return _context.Orders.Where(p => p.Store == Store);
    }
      public IEnumerable<Order> GetOrderByUser(User User)
    {
      return _context.Orders.Where(p => p.User == User).Include(p => p.Store);
    }

    public void AddOrder(Order Order)
    {
        _context.Add(Order);
    }
  }
}
