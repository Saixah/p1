using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class MeatPizza : APizzaModel
  {
    protected override void AddCrust()
    {
      Crust = new Crust();
    }

    protected override void AddSize()
    {
      Size = new Size();
    }

    protected override void AddToppings()
    {
      Toppings = new List<Topping>();
    }
  }
}
