using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
  public class CustomerViewModel: IValidatableObject
  {
      [Required (AllowEmptyStrings = false)]
      public string Username{get;set;}
      public IEnumerable<User> Users { get; set; }
      public User User{get;set;}
      public IEnumerable<Order> OrderHistory{get;set;}

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      if(Username == null)
      {
        yield return new ValidationResult("cannot be null",new string[] {"Username"});
      }
    }
  }
}
