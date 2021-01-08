using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class CustomPizza : APizzaModel
  {
      public CustomPizza(){}
      public CustomPizza(Crust Crust, Size Size, List<Topping> Toppings)
        {
            this.Crust = Crust;
            this.Size = Size;
            this.Toppings = Toppings;
        }
  }
}
