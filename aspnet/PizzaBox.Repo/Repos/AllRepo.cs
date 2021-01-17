using System;
using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storage;

namespace PizzaBox.Repo.Repos
{
    public class AllRepo
    {
        protected readonly PizzaBoxContext _db;
        private StoreRepo _StoreRepo;
        private UserRepo _UserRepo;
        private OrderRepo _OrderRepo;
        private ToppingRepo _ToppingRepo;
        private SizeRepo _SizeRepo;
        private CrustRepo _CrustRepo;
        private PizzaRepo _PizzaRepo;

        public AllRepo(PizzaBoxContext context)
        {
          _db = context;
        }
        public StoreRepo StoreRepo
        {
          get
          {
              if(_StoreRepo == null)
              {
                _StoreRepo = new StoreRepo(_db);
              }
              return _StoreRepo;
          }
        }
        public UserRepo UserRepo
        {
          get
          {
              if(_UserRepo == null)
              {
                _UserRepo = new UserRepo(_db);
              }
              return _UserRepo;
          }
        }

        public OrderRepo OrderRepo
        {
          get
          {
              if(_OrderRepo == null)
              {
                _OrderRepo = new OrderRepo(_db);
              }
              return _OrderRepo;
          }
        }

        public ToppingRepo ToppingRepo
        {
          get
          {
              if(_ToppingRepo == null)
              {
                _ToppingRepo = new ToppingRepo(_db);
              }
              return _ToppingRepo;
          }
        }

        public SizeRepo SizeRepo
        {
          get
          {
              if(_SizeRepo == null)
              {
                _SizeRepo = new SizeRepo(_db);
              }
              return _SizeRepo;
          }
        }
        public CrustRepo CrustRepo
        {
          get
          {
              if(_CrustRepo == null)
              {
                _CrustRepo = new CrustRepo(_db);
              }
              return _CrustRepo;
          }
        }
        public PizzaRepo PizzaRepo
        {
          get
          {
              if(_PizzaRepo == null)
              {
                _PizzaRepo = new PizzaRepo(_db);
              }
              return _PizzaRepo;
          }
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

        public decimal GetStoreRevenue(DateTime Time,Store Store)
        {
            var Orders = OrderRepo.GetOrderByStore(Store);
            decimal Revenue = 0;
            foreach (var order in Orders)
            {
                int result = DateTime.Compare(order.OrderTime,Time);
                if (result > 0)
                {
                    Revenue += order.Price;
                }
            }
            return Revenue;
        }
    }
}
