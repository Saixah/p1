using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storage;

namespace PizzaBox.Repo.Repos
{
  public class OrderRepo : AllRepo
  {

    private PizzaBoxContext _context;
    public OrderRepo(PizzaBoxContext _db)
    {
      _context = _db;
    }

    public IEnumerable<Order> ReadOrders()
    {
        return _db.Orders;
    }
    public void DisplayOrders()
    {
        DisplayItem(ReadOrders());
    }
    public void DisplayOrderByStore(Store Store)
    {
        var Orders = GetOrderByStore(Store);
        DisplayItem(Orders);
    }
    public IEnumerable<Order> GetOrderByStore(Store Store)
    {
        return _db.Orders.Where(p => p.Store == Store);
    }
      public IEnumerable<Order> GetOrderByUser(User User)
    {
      return _db.Orders.Where(p => p.User == User).Include(p => p.Store);
    }

    public void DisplayOrderByUser(User User)
    {
        var Orders = _db.Orders.Where(p => p.User == User);
        DisplayItem(Orders);
    }

    public void AddOrder(Order Order)
    {
        _db.Add(Order);
    }
  }
}
