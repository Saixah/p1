using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Size : AEntity
    {
        public APizzaModel Pizza = new APizzaModel();
        public string name { get; set; }
        public decimal price { get; set; }
        public Size(){}
        public Size(string name, decimal price)
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
