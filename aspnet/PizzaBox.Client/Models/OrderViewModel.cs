using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
  public class OrderViewModel
  {
      public IEnumerable<Store> Stores {get; set;}
      [Required]
      public string StoreName {get; set;}
      public Store Store {get;set;}
      public ICollection<APizzaModel> Pizzas {get; set;}
      public APizzaModel Pizza{get;set;}
      public string PizzaName {get;set;}
  }
}
