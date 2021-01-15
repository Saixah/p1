using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Repo.Repos;

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
      public User User{get;set;}
      public string Username{get;set;}
      public PizzaViewModel PizzaViewModel{get;set;}
      public OrderViewModel()
      {
        PizzaViewModel = new PizzaViewModel();
      }
      public OrderViewModel(AllRepo Repo)
      {
        Pizzas = new List<APizzaModel>();
        PizzaViewModel = new PizzaViewModel();
        Stores = Repo.StoreRepo.ReadStores();
      }
  }
}
