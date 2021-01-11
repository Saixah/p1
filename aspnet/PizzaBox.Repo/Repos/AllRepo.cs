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

        public AllRepo()
        {
          new StoreRepo(_db);
          new UserRepo(_db);
          new OrderRepo(_db);
          new ToppingRepo(_db);
          new SizeRepo(_db);
          new CrustRepo(_db);
        }

        protected void DisplayItem<T>(IEnumerable<T> List)
        {
            foreach (T item in List)
            {
                Console.WriteLine(item);
            }
        }

        public void Save()
        {
          _db.SaveChanges();
        }
    }
}
