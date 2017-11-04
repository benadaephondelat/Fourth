namespace DataLayer.Tests
{
    using System.Data.Entity;

    using DataLayer;
    using Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ApplicationDbContextTests
    {
        [TestMethod]
        public void ApplicationDbContext_Should_Exist()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            Assert.IsNotNull(context);
        }

        [TestMethod]
        public void ApplicationDbContext_Create_Method_Should_Return_An_Instance_Of_ApplicationDbContext()
        {
            bool isValidCast = ApplicationDbContext.Create() is ApplicationDbContext;

            Assert.IsNotNull(isValidCast);
        }

        [TestMethod]
        public void ApplicationDbContext_Should_Have_IDbSet_Of_Categories()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            Assert.IsTrue(context.Categories is IDbSet<Category>);
        }

        [TestMethod]
        public void ApplicationDbContext_Should_Have_IDbSet_Of_CustomerDemographics()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            Assert.IsTrue(context.CustomerDemographics is IDbSet<CustomerDemographic>);
        }

        [TestMethod]
        public void ApplicationDbContext_Should_Have_IDbSet_Of_Customers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            Assert.IsTrue(context.Customers is IDbSet<Customer>);
        }

        [TestMethod]
        public void ApplicationDbContext_Should_Have_IDbSet_Of_Employees()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            Assert.IsTrue(context.Employees is IDbSet<Employee>);
        }

        [TestMethod]
        public void ApplicationDbContext_Should_Have_IDbSet_Of_OrderDetails()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            Assert.IsTrue(context.OrderDetails is IDbSet<Order_Detail>);
        }

        [TestMethod]
        public void ApplicationDbContext_Should_Have_IDbSet_Of_Orders()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            Assert.IsTrue(context.Orders is IDbSet<Order>);
        }

        [TestMethod]
        public void ApplicationDbContext_Should_Have_IDbSet_Of_Products()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            Assert.IsTrue(context.Products is IDbSet<Product>);
        }

        [TestMethod]
        public void ApplicationDbContext_Should_Have_IDbSet_Of_Regions()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            Assert.IsTrue(context.Regions is IDbSet<Region>);
        }

        [TestMethod]
        public void ApplicationDbContext_Should_Have_IDbSet_Of_Shippers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            Assert.IsTrue(context.Shippers is IDbSet<Shipper>);
        }

        [TestMethod]
        public void ApplicationDbContext_Should_Have_IDbSet_Of_Suppliers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            Assert.IsTrue(context.Suppliers is IDbSet<Supplier>);
        }

        [TestMethod]
        public void ApplicationDbContext_Should_Have_IDbSet_Of_Territories()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            Assert.IsTrue(context.Territories is IDbSet<Territory>);
        }
    }
}
