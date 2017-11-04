namespace ServiceLayer.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Interfaces;
    using Moq;
    using DataLayer.Interfaces;
    using Helpers;
    using ServiceLayer;
    using System.Linq;
    using Interfaces.ModelsInterfaces;
    using System.Collections.Generic;
    using global::Models;

    [TestClass]
    public class CustomerServiceTests
    {
        private Mock<IData> dataLayerMock;
        private ICustomerService customerService;
        private DataLayerMockHelper mockHelper;

        [TestInitialize]
        public void SetUp()
        {
            this.mockHelper = new DataLayerMockHelper();

            this.dataLayerMock = this.mockHelper.SetupTicTacToeDataMock();

            this.customerService = new CustomerService(dataLayerMock.Object);
        }

        #region GetAllCustomers Tests

        [TestMethod]
        public void GetAllCustomers_Should_Return_Empty_List_If_CustomerGridModel_If_There_Are_No_Custmers()
        {
            this.SetupEmptyCustomersData();

            IEnumerable<ICustomerGridModel> cutomers = this.customerService.GetAllCustomers();

            Assert.IsNotNull(cutomers);

            Assert.IsInstanceOfType(cutomers, typeof(IEnumerable<ICustomerGridModel>));

            Assert.AreEqual(0, cutomers.Count());
        }

        [TestMethod]
        public void GetAllCustomers_Should_Return_IEnumerable_Of_CustomerGridModel_With_Count_Greater_Than_Zero_If_There_Are_Customers_In_The_Database()
        {
            IEnumerable<ICustomerGridModel> cutomers = this.customerService.GetAllCustomers();

            Assert.IsNotNull(cutomers);

            Assert.IsInstanceOfType(cutomers, typeof(IEnumerable<ICustomerGridModel>));

            Assert.IsTrue(cutomers.Count() > 0);
        }

        [TestMethod]
        public void GetAllCustomers_ICustomerGridModel_CustomerID_Should_Not_Be_Null_Empty_Or_Whitespace()
        {
            IEnumerable<ICustomerGridModel> customers = this.customerService.GetAllCustomers();

            foreach (var customer in customers)
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(customer.Id));
            }
        }

        [TestMethod]
        public void GetAllCustomers_ICustomerGridModel_CustomerName_Should_Not_Be_Null_Empty_Or_Whitespace()
        {
            IEnumerable<ICustomerGridModel> customers = this.customerService.GetAllCustomers();

            foreach (var customer in customers)
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(customer.Name));
            }
        }

        [TestMethod]
        public void GetAllCustomers_ICustomerGridModel_OrdersCount_Should_Not_Be_A_Negative_Number()
        {
            IEnumerable<ICustomerGridModel> customers = this.customerService.GetAllCustomers();

            foreach (var customer in customers)
            {
                Assert.IsFalse(customer.OrdersCount < 0);
            }
        }

        [TestMethod]
        public void GetAllCustomers_Should_Sort_The_List_By_Descending_By_Orders_Count()
        {
            IEnumerable<ICustomerGridModel> customers = this.customerService.GetAllCustomers();

            if (customers.Count() == 1)
            {
                Assert.IsTrue(true);
            }

            for (var i = 0; i < customers.Count(); i++)
            {
                int currentCustomerOrdersCount = customers.ElementAt(i).OrdersCount;

                for(var j = i + 1; j < customers.Count(); j++)
                {
                    var nextCustomerOrdersCount = customers.ElementAt(j).OrdersCount;

                    if (nextCustomerOrdersCount > currentCustomerOrdersCount)
                    {
                        Assert.Fail();
                    }
                }
            }

            Assert.IsTrue(true);
        }

        private void SetupEmptyCustomersData()
        {
            Mock<IData> dataMock = new Mock<IData>();

            Mock<IGenericRepository<Customer>> userRepoMock = new Mock<IGenericRepository<Customer>>();

            userRepoMock.Setup(prop => prop.All()).Returns(new List<Customer>().AsQueryable());

            IGenericRepository<Customer> customersRepoMock = userRepoMock.Object;

            dataMock.Setup(p => p.Customers).Returns(customersRepoMock);

            this.customerService = new CustomerService(dataMock.Object);
        }

        #endregion
    }
}