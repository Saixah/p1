using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
  public class CustomerViewModel
  {
      public IEnumerable<User> Users { get; set; }
      public User User{get;set;}
      public IEnumerable<Order> OrderHistory{get;set;}
      public OrderViewModel Order{get; set;}
      public string Username{get;set;}

  }
}
