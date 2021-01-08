using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Factories;

namespace PizzaBox.Domain.Models
{
   public class Order : AEntity
  {
    private GenericPizzaFactory _pizzaFactory = new GenericPizzaFactory();
    public List<APizzaModel> Pizzas { get; set; }
    public Store Store {get;set;}
    public User User {get;set;}
    public decimal Price {get;set;}
    public DateTime OrderTime {get;set;}
    public Order()
    {
      Pizzas = new List<APizzaModel>();
      this.OrderTime = DateTime.Now;
    }

    public Order(List<APizzaModel> pizzaModels)
    {
      this.Pizzas = pizzaModels;
      this.OrderTime = DateTime.Now;
    }

    public void MakeMeatPizza()
    {
      Pizzas.Add(_pizzaFactory.Make<MeatPizza>());
    }

    public void MakeCheesePizza()
    {
      Pizzas.Add(_pizzaFactory.Make<CheesePizza>());
    }

    public void MakeCustomPizza(Crust Crust, Size Size, List<Topping> Toppings)
    {
      Pizzas.Add(new CustomPizza(Crust, Size, Toppings));
    }

  }
}
