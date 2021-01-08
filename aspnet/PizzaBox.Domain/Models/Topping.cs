using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Topping : AEntity
    {
        public string name { get; set; }
        public decimal price { get; set; }
        public Topping(){}
        public Topping(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }
        public override string ToString()
        {
            return $"{name}";
        }
    }
}
