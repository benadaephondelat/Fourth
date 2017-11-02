namespace DataLayer.Interfaces
{
    using Models;
    using System.Threading.Tasks;

    public interface IData
    {
        IGenericRepository<ApplicationUser> Users { get; }

        IGenericRepository<Category> Categories { get; }

        IGenericRepository<Customer> Customers { get; }

        IGenericRepository<CustomerDemographic> CustomerDemographics { get; }

        IGenericRepository<Employee> Employees { get; }

        IGenericRepository<Order> Orders { get; }

        IGenericRepository<Order_Detail> OrderDetails { get; }

        IGenericRepository<Product> Products { get; }

        IGenericRepository<Region> Regions { get; }

        IGenericRepository<Shipper> Shippers { get; }

        IGenericRepository<Supplier> Suppliers { get; }

        IGenericRepository<Territory> Teritories { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}