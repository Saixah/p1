using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
  public class PizzaViewModel
  {
      public Crust Crust { get; set; }
      public string CrustName { get; set; }
      public IEnumerable<Crust> DisplayCrusts {get; set;}


      public Size Size{get;set;}
      public string SizeName{get;set;}
       public IEnumerable<Size> DisplaySizes {get; set;}


      public IEnumerable<Topping> DisplayToppings { get; set; }
      public List<string> ToppingsNames {get; set;}
      public string ToppingName{get; set;}
      public List<Topping> Toppings {get; set;}
      public bool IsChecked{get;set;}
      public decimal Price {get;set;}
  }
}
