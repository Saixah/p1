using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Repo.Repos;

namespace PizzaBox.Client.Models
{
  public class PizzaViewModel : ValidationAttribute
  {
      public List<APizzaModel> PizzaList {get;set;}
      public Crust Crust { get; set; }
      [Required]
      public string CrustName { get; set; }
      public IEnumerable<Crust> DisplayCrusts {get; set;}

      public Size Size{get;set;}
      [Required]
      public string SizeName{get;set;}
       public IEnumerable<Size> DisplaySizes {get; set;}

      public IEnumerable<Topping> DisplayToppings { get; set; }

      [PizzaViewModel,Required,Display(Name = "Toppings must be Between 2 - 5")]
      public List<string> ToppingsNames {get; set;}
      public List<Topping> Toppings {get; set;}
      public Topping Topping{get;set;}
      public decimal Price {get;set;}

      public PizzaViewModel(){}
      public PizzaViewModel(AllRepo Repo)
      {
        DisplayCrusts = Repo.CrustRepo.ReadCrust();
        DisplaySizes = Repo.SizeRepo.ReadSize();
        DisplayToppings = Repo.ToppingRepo.ReadToppings();
      }

    public override bool IsValid(object value)
    {
        var list = value as IList;
        if (list == null)
            return false;

        if (list.Count < 2 || list.Count > 5)
            return false;

        return true;
    }
  }
}
