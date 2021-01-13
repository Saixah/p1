using System;
using System.Collections.Generic;
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
