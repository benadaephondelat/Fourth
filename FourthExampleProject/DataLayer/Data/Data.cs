namespace DataLayer.Data
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Models;
    using Interfaces;
    using Repository;

    public class Data : IData
    {
        private readonly IApplicationDbContext context;
        private readonly IDictionary<Type, object> repositories;

        public Data(IApplicationDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<Category> Categories
        {
            get
            {
                return GetRepository<Category>();
            }
        }

        public IGenericRepository<CustomerDemographic> CustomerDemographics
        {
            get
            {
                return GetRepository<CustomerDemographic>();
            }
        }

        public IGenericRepository<Customer> Customers
        {
            get
            {
                return GetRepository<Customer>();
            }
        }

        public IGenericRepository<Employee> Employees
        {
            get
            {
                return GetRepository<Employee>();
            }
        }

        public IGenericRepository<Order_Detail> OrderDetails
        {
            get
            {
                return GetRepository<Order_Detail>();
            }
        }

        public IGenericRepository<Order> Orders
        {
            get
            {
                return GetRepository<Order>();
            }
        }

        public IGenericRepository<Product> Products
        {
            get
            {
                return GetRepository<Product>();
            }
        }

        public IGenericRepository<Region> Regions
        {
            get
            {
                return GetRepository<Region>();
            }
        }

        public IGenericRepository<Shipper> Shippers
        {
            get
            {
                return GetRepository<Shipper>();
            }
        }

        public IGenericRepository<Supplier> Suppliers
        {
            get
            {
                return GetRepository<Supplier>();
            }
        }

        public IGenericRepository<Territory> Teritories
        {
            get
            {
                return GetRepository<Territory>();
            }
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return context.SaveChangesAsync();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);

            if (repositories.ContainsKey(type))
            {
                return (IGenericRepository<T>)repositories[type];
            }

            Type typeOfRepository = typeof(GenericRepository<T>);

            object repository = Activator.CreateInstance(typeOfRepository, context);

            repositories.Add(type, repository);

            return (IGenericRepository<T>)repositories[type];
        }
    }
}