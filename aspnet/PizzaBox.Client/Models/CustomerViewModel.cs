using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;
using PizzaBox.Repo.Repos;

namespace PizzaBox.Client.Models
{
  public class CustomerViewModel
  // : IValidatableObject
  {
    [Required(AllowEmptyStrings=false)]
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

    // public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    // {
    //   if(Username == null)
    //   {
    //     yield return new ValidationResult("cannot be null",new string[] {"Username"});
    //   }
    // }
    // public ValidationResult isValid(ValidationContext validationContext)
    // {
    //   if(Username.Equals("Choose User"))
    //   {
    //     return new ValidationResult("Username Cannot Be Null");
    //   }
    //   return ValidationResult.Success;
    // }
  }
}
