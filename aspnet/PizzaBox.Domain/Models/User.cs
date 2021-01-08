using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class User : AEntity
    {
        public string Name {get;set;}
        public Store ChosenStore { get; set; }
        public List<Order> Orders { get; set; }

        public User()
        {
            Orders = new List<Order>();
        }
        public User(string Name)
        {
            this.Name = Name;
            Orders = new List<Order>();
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
