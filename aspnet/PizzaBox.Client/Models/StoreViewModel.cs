using System;
using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
  public class StoreViewModel
  {
      public IEnumerable<Store> Stores {get;set;}


      public StoreViewModel()
      {
          this.Stores = Stores;
      }
  }
}
