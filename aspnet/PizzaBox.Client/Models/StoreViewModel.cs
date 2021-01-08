using System;
using System.Collections.Generic;

namespace PizzaBox.Client.Models
{
  public class StoreViewModel
  {
      public List<String> Stores {get;set;}

      public StoreViewModel()
      {
        Stores = new List<String>(){
          "Dallas","Houston","Jefferson"
        };
      }
  }
}
