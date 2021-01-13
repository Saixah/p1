using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Models;
using PizzaBox.Repo.Repos;

namespace PizzaBox.Client.Models
{
  public class OrderViewModel
  {
      public IEnumerable<Store> Stores {get; set;}

      [Required]
      public string Store {get; set;}

      public OrderViewModel()
      {

        // Stores = Repo.StoreRepo.ReadStores();
      }

  }
}
