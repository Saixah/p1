using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
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
    public Order FindByID(long id)
    {
      return _context.Orders.SingleOrDefault(s => s.EntityId == id);
    }
    public IEnumerable<Order> GetOrderByStore(Store Store)
    {
        return _context.Orders.Where(p => p.Store == Store).Include(p=>p.User);
    }
    public IEnumerable<Order> GetOrderByUser(User User)
    {
      return _context.Orders.Where(p => p.User == User).Include(p => p.Store);
    }
    public Order GetOrderById(long id)
    {
      return _context.Orders.SingleOrDefault(p=>p.EntityId ==id);
    }
     public IEnumerable<Order> GetOrderByUserEnityId(User User)
    {
      return _context.Orders.Where(p => p.User.EntityId == User.EntityId).Include(p => p.Store);
    }
    public void AddOrder(Order Order)
    {
        _context.Add(Order);
    }

    public Order GetOrdersByID(long id)
    {
      var list= _context.Orders.Where(p => p.EntityId == id).Include(p => p.Pizzas);
      return list.First();
    }

    public APizzaModel GetPizza(long orderid, long pizzaid)
    {
      Order order = _context.Orders.Where(p => p.EntityId == orderid).Include(p => p.Pizzas).First();
      var pizza = _context.Pizzas.Where(p => p.EntityId == pizzaid).Include(p=>p.Crust).Include(p=>p.Size).Include(p=>p.Toppings).First();
      return pizza;
    }
    public void DeletePizzaByID(APizzaModel pizza)
    {
      _context.Remove(pizza);
      _context.SaveChanges();
    }

    public void ChangeOrderPrice(Order Order)
    {
      _context.Attach(Order);

    }
  }
}
