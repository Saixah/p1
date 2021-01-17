using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
  public class StoreViewModel
  {
      public IEnumerable<Store> Stores {get;set;}
      public Store Store{get;set;}

      [Required]
      public string StoreName{get;set;}
      public decimal MonthlyRev{get;set;}
      public decimal WeeklyRev{get;set;}
      public decimal YearlyRev{get;set;}
      public IEnumerable<Order> OrderHistory{get;set;}
      public StoreViewModel()
      {
          this.Stores = Stores;
          this.Store = Store;
          this.StoreName = StoreName;
      }

  }
}
