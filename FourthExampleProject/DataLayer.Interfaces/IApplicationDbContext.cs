namespace DataLayer.Interfaces
{
    using Models;
    using System.Data.Entity;
    using System.Threading.Tasks;

    public interface IApplicationDbContext
    {
        IDbSet<Category> Categories { get; set; }

        IDbSet<Customer> Customers { get; set; }

        IDbSet<CustomerDemographic> CustomerDemographics { get; set; }

        IDbSet<Employee> Employees { get; set; }

        IDbSet<Order> Orders { get; set; }

        IDbSet<Order_Detail> OrderDetails { get; set; }

        IDbSet<Product> Products { get; set; }

        IDbSet<Region> Regions { get; set; }

        IDbSet<Shipper> Shippers { get; set; }

        IDbSet<Supplier> Suppliers { get; set; }

        IDbSet<Territory> Territories { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}