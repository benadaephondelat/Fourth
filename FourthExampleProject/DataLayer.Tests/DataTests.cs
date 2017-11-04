namespace DataLayer.Tests
{
    using Data;
    using Interfaces;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class DataTests
    {
        private IData data;

        [TestInitialize]
        public void SetUp()
        {
            this.data = new Data(ApplicationDbContext.Create());
        }

        [TestMethod]
        public void Data_Should_Have_ApplicationUsers_Repository()
        {
            bool isValidCast = data.Users is IGenericRepository<ApplicationUser>;

            Assert.IsTrue(isValidCast);
        }

        [TestMethod]
        public void Data_Should_Have_Categories_Repository()
        {
            bool isValidCast = data.Categories is IGenericRepository<Category>;

            Assert.IsTrue(isValidCast);
        }

        [TestMethod]
        public void Data_Should_Have_CustomerDemographics_Repository()
        {
            bool isValidCast = data.CustomerDemographics is IGenericRepository<CustomerDemographic>;

            Assert.IsTrue(isValidCast);
        }

        [TestMethod]
        public void Data_Should_Have_Customers_Repository()
        {
            bool isValidCast = data.Customers is IGenericRepository<Customer>;

            Assert.IsTrue(isValidCast);
        }

        [TestMethod]
        public void Data_Should_Have_Employees_Repository()
        {
            bool isValidCast = data.Employees is IGenericRepository<Employee>;

            Assert.IsTrue(isValidCast);
        }

        [TestMethod]
        public void Data_Should_Have_Employees_OrderDetails()
        {
            bool isValidCast = data.OrderDetails is IGenericRepository<Order_Detail>;

            Assert.IsTrue(isValidCast);
        }

        [TestMethod]
        public void Data_Should_Have_Employees_Orders()
        {
            bool isValidCast = data.Orders is IGenericRepository<Order>;

            Assert.IsTrue(isValidCast);
        }

        [TestMethod]
        public void Data_Should_Have_Employees_Products()
        {
            bool isValidCast = data.Products is IGenericRepository<Product>;

            Assert.IsTrue(isValidCast);
        }

        [TestMethod]
        public void Data_Should_Have_Employees_Regions()
        {
            bool isValidCast = data.Regions is IGenericRepository<Region>;

            Assert.IsTrue(isValidCast);
        }

        [TestMethod]
        public void Data_Should_Have_Employees_Shippers()
        {
            bool isValidCast = data.Shippers is IGenericRepository<Shipper>;

            Assert.IsTrue(isValidCast);
        }

        [TestMethod]
        public void Data_Should_Have_Employees_Suppliers()
        {
            bool isValidCast = data.Suppliers is IGenericRepository<Supplier>;

            Assert.IsTrue(isValidCast);
        }

        [TestMethod]
        public void Data_Should_Have_Employees_Teritories()
        {
            bool isValidCast = data.Teritories is IGenericRepository<Territory>;

            Assert.IsTrue(isValidCast);
        }

        [TestMethod]
        public void Data_Should_Have_SaveChanges_Method()
        {
            data.SaveChanges();
        }

        [TestMethod]
        public void Data_Should_Have_SaveChangesAsync()
        {
            data.SaveChangesAsync();
        }
    }
}