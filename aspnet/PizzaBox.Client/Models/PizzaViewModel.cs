using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Repo.Repos;

namespace PizzaBox.Client.Models
{
  public class PizzaViewModel
  {
      public List<APizzaModel> PizzaList {get;set;}
      public Crust Crust { get; set; }
      public string CrustName { get; set; }
      public IEnumerable<Crust> DisplayCrusts {get; set;}

      public Size Size{get;set;}
      public string SizeName{get;set;}
       public IEnumerable<Size> DisplaySizes {get; set;}

      public IEnumerable<Topping> DisplayToppings { get; set; }
      public string[] ToppingsNames {get; set;}
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

  }
}
