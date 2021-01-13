using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storage
{
    public class PizzaBoxContext : DbContext
    {
        public PizzaBoxContext(DbContextOptions<PizzaBoxContext> options) : base(options){}
        public DbSet<Store> Stores { get; set; }
        public DbSet<Topping> Topping {get; set;}
        public DbSet<Order> Orders{get;set;}
        public DbSet<Crust> Crust {get; set;}
        public DbSet<Size> Size {get; set;}
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Store>().HasKey(s => s.EntityId);
            builder.Entity<User>().HasKey(u => u.EntityId);
            builder.Entity<APizzaModel>().HasKey(p => p.EntityId);
            builder.Entity<Order>().HasKey(o => o.EntityId);
            builder.Entity<Topping>().HasKey(t => t.EntityId);
            builder.Entity<Size>().HasKey(v => v.EntityId);
            builder.Entity<Crust>().HasKey(c => c.EntityId);

            builder.Entity<User>().Property(c=> c.EntityId).ValueGeneratedNever();
            builder.Entity<Order>().Property(c=> c.EntityId).ValueGeneratedNever();
            builder.Entity<Crust>().Property(c=> c.EntityId).ValueGeneratedNever();
            builder.Entity<Size>().Property(c=> c.EntityId).ValueGeneratedNever();
            builder.Entity<Topping>().Property(c=> c.EntityId).ValueGeneratedNever();
            builder.Entity<Store>().Property(c=> c.EntityId).ValueGeneratedNever();
            builder.Entity<APizzaModel>().Property(c=> c.EntityId).ValueGeneratedNever();

            SeedData(builder);
        }

        protected void SeedData(ModelBuilder builder)
        {
            builder.Entity<Store>(b =>
            {
                b.HasData(new List<Store>{
                    new Store() {Name = "One"},
                    new Store() {Name = "Two"},
                    new Store() {Name = "Three"}
                });

            });

            builder.Entity<User>().HasData(new List<User>
            {
                    new User() {Name = "Isaiah"},
                    new User() {Name = "Fred"},
                    new User() {Name = "Other"}
            });

            builder.Entity<Topping>().HasData(new List<Topping>
            {
               new Topping(){name ="Pepperoni", price = 2},
               new Topping(){name ="Pineapple",price = 6},
               new Topping(){name ="Bacon",price = 3},
               new Topping(){name ="Gold",price = 100},
               new Topping(){name ="Jalapenos",price = 60},
               new Topping(){name = "Cheese",price = 1}
            });

            builder.Entity<Size>().HasData(new List<Size>
            {
                new Size{name ="Small",price = 12},
                new Size{name ="Medium",price =16},
                new Size{name ="Large",price = 22},
                new Size{name ="X-Large",price = 28}
            });

            builder.Entity<Crust>().HasData(new List<Crust>
            {
                new Crust{name ="Thin",price = 2},
                new Crust{name ="Thick",price = 3},
                new Crust{name ="Stuffed",price =5}
            });
        }


    }
}
