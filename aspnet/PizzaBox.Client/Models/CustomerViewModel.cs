using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain.Models;
using PizzaBox.Repo.Repos;

namespace PizzaBox.Client.Models
{
  public class CustomerViewModel: IValidatableObject
  {
    [Required]
    public string Username{get;set;}
    public IEnumerable<User> Users { get; set; }
    public User User{get;set;}
    public IEnumerable<Order> OrderHistory{get;set;}
    public Order Order{get;set;}
    public OrderViewModel OrderView { get; set; }

    public CustomerViewModel()
    {
      OrderView = new OrderViewModel();
    }

    public CustomerViewModel(AllRepo Repo)
    {
      Users = Repo.UserRepo.ReadUser();
      OrderView = new OrderViewModel();
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      if(Username == null)
      {
        yield return new ValidationResult("cannot be null",new string[] {"Username"});
      }
    }
  }
}
