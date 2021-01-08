using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storage;

namespace PizzaBox.Repo.Repos
{
    public class AllRepo
    {
        protected readonly PizzaBoxContext _db = new PizzaBoxContext();

        protected void DisplayItem<T>(IEnumerable<T> List)
        {
            foreach (T item in List)
            {
                Console.WriteLine(item);
            }
        }

        public IEnumerable<Crust> ReadCrust()
        {
            return _db.Crust;
        }

        public void DisplayCrust()
        {
            DisplayItem(ReadCrust());
        }

        public Crust ReadOneCrust(string Name)
        {
            return _db.Crust.FirstOrDefault(s => s.name.Equals(Name));
        }

        public Crust ReadOneCrust(int UserInput)
        {
            return _db.Crust.ToList().ElementAt(UserInput);
        }

         public IEnumerable<Size> ReadSize()
        {
            return _db.Size;
        }

        public void DisplaySize()
        {
            DisplayItem(ReadSize());
        }

        public Size ReadOneSize(string Name)
        {
            return _db.Size.FirstOrDefault(s => s.name.Equals(Name));
        }

        public Size ReadOneSize(int UserInput)
        {
            return _db.Size.ToList().ElementAt(UserInput);
        }
        public IEnumerable<Store> ReadStores()
        {
            return _db.Stores;
        }

        public void DisplayStores()
        {
            DisplayItem(ReadStores());
        }

        public Store ReadOneStore(string Name)
        {
            return _db.Stores.SingleOrDefault(s => s.Name == Name);
        }

        public Store ReadOneStore(int UserInt)
        {
            return _db.Stores.ToList().ElementAt(UserInt);
        }

        public List<APizzaModel> GetPizzasFromStore(string StoreName)
        {
            return ReadOneStore(StoreName).Pizzas;
        }

        public void SaveOrder(Order Order)
        {
            _db.Add(Order);
            _db.SaveChanges();
        }

        public IEnumerable<Topping> ReadToppings()
        {
            return _db.Topping;
        }

        public Topping ReadOneTopping(int UserInt)
        {
            return _db.Topping.ToList().ElementAt(UserInt);
        }

        public void DisplayToppings()
        {
            DisplayItem(ReadToppings());
        }

        public Topping ReadOneTopping(string Name)
        {
            return _db.Topping.FirstOrDefault(s => s.name.Equals(Name));
        }
         public void SaveUser(User User)
        {
            _db.Add(User);
            _db.SaveChanges();
        }
        public IEnumerable<User> ReadUser()
        {
            return _db.Users;
        }
        public User ReadOneUser(int UserInt)
        {
            return _db.Users.ToList().ElementAt(UserInt);
        }
        public void DisplayUser()
        {
            DisplayItem(ReadUser());
        }
        public IEnumerable<Order> ReadOrders()
        {
            return _db.Orders;
        }
        public void DisplayOrders()
        {
            DisplayItem(ReadOrders());
        }
        public void DisplayOrderByStore(Store Store)
        {
            var Orders = GetOrderByStore(Store);
            DisplayItem(Orders);
        }
        public IEnumerable<Order> GetOrderByStore(Store Store)
        {
           return _db.Orders.Where(p => p.Store == Store);
        }
         public IEnumerable<Order> GetOrderByUser(User User)
        {
          return _db.Orders.Where(p => p.User == User).Include(p => p.Store);
        }

        public void DisplayOrderByUser(User User)
        {
            var Orders = _db.Orders.Where(p => p.User == User);
            DisplayItem(Orders);
        }
    }
}
