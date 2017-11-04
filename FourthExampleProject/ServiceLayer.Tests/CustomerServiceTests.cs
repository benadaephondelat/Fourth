namespace ServiceLayer.Tests
{
    using System.Linq;
    using System.Collections.Generic;

    using Helpers;
    using Interfaces;
    using Interfaces.ModelsInterfaces;
    using ServiceLayer;
    using DataLayer.Interfaces;
    using Exceptions.Customer;
    using global::Models;

    using Moq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        #region GetCustomerDetailsById Tests

        [TestMethod]
        [ExpectedException(typeof(CustomerNotFoundException))]
        public void GetCustomerDetailsById_Should_Throw_CustomerNotFoundException_If_There_Is_No_User_With_Such_Id_In_The_Database()
        {
            this.customerService.GetCustomerDetailsById(MockConstants.InvalidCustomerId);
        }

        [TestMethod]
        public void GetCustomerDetailsById_Should_Return_An_Instance_Of_ICustomerDetailsModel()
        {
            ICustomerDetailsModel customerDetails = this.customerService.GetCustomerDetailsById(MockConstants.CustomerWithoutOrdersId);

            Assert.IsInstanceOfType(customerDetails, typeof(ICustomerDetailsModel));
        }

        [TestMethod]
        public void GetCustomerDetailsById_Should_Return_CustomerDetailsModel_That_Is_Not_Null()
        {
            ICustomerDetailsModel customerDetails = this.customerService.GetCustomerDetailsById(MockConstants.CustomerWithoutOrdersId);

            Assert.IsNotNull(customerDetails);
        }

        [TestMethod]
        public void GetCustomerDetailsById_Should_Return_CustomerDetailsModel_With_Valid_CustomerId()
        {
            ICustomerDetailsModel customerDetails = this.customerService.GetCustomerDetailsById(MockConstants.CustomerWithoutOrdersId);

            Assert.IsFalse(string.IsNullOrWhiteSpace(customerDetails.CustomerId));
        }

        [TestMethod]
        public void GetCustomerDetailsById_Should_Return_CustomerDetailsModel_With_Valid_CompanyName()
        {
            ICustomerDetailsModel customerDetails = this.customerService.GetCustomerDetailsById(MockConstants.CustomerWithoutOrdersId);

            Assert.IsFalse(string.IsNullOrWhiteSpace(customerDetails.CompanyName));
        }

        [TestMethod]
        public void GetCustomerDetailsById_Should_Return_CustomerDetailsModel_With_Valid_ContactName()
        {
            ICustomerDetailsModel customerDetails = this.customerService.GetCustomerDetailsById(MockConstants.CustomerWithoutOrdersId);

            Assert.IsFalse(string.IsNullOrWhiteSpace(customerDetails.ContactName));
        }

        [TestMethod]
        public void GetCustomerDetailsById_Should_Return_CustomerDetailsModel_With_Valid_ContactTitle()
        {
            ICustomerDetailsModel customerDetails = this.customerService.GetCustomerDetailsById(MockConstants.CustomerWithoutOrdersId);

            Assert.IsFalse(string.IsNullOrWhiteSpace(customerDetails.ContactTitle));
        }

        [TestMethod]
        public void GetCustomerDetailsById_Should_Return_CustomerDetailsModel_With_Valid_Address()
        {
            ICustomerDetailsModel customerDetails = this.customerService.GetCustomerDetailsById(MockConstants.CustomerWithoutOrdersId);

            Assert.IsFalse(string.IsNullOrWhiteSpace(customerDetails.Address));
        }

        [TestMethod]
        public void GetCustomerDetailsById_Should_Return_CustomerDetailsModel_With_Valid_City()
        {
            ICustomerDetailsModel customerDetails = this.customerService.GetCustomerDetailsById(MockConstants.CustomerWithoutOrdersId);

            Assert.IsFalse(string.IsNullOrWhiteSpace(customerDetails.City));
        }

        [TestMethod]
        public void GetCustomerDetailsById_Should_Return_CustomerDetailsModel_With_Valid_Country()
        {
            ICustomerDetailsModel customerDetails = this.customerService.GetCustomerDetailsById(MockConstants.CustomerWithoutOrdersId);

            Assert.IsFalse(string.IsNullOrWhiteSpace(customerDetails.Country));
        }

        [TestMethod]
        public void GetCustomerDetailsById_Should_Return_CustomerDetailsModel_With_Valid_Region()
        {
            ICustomerDetailsModel customerDetails = this.customerService.GetCustomerDetailsById(MockConstants.CustomerWithoutOrdersId);

            Assert.IsFalse(string.IsNullOrWhiteSpace(customerDetails.Region));
        }

        [TestMethod]
        public void GetCustomerDetailsById_Should_Return_CustomerDetailsModel_With_Valid_PostalCode()
        {
            ICustomerDetailsModel customerDetails = this.customerService.GetCustomerDetailsById(MockConstants.CustomerWithoutOrdersId);

            Assert.IsFalse(string.IsNullOrWhiteSpace(customerDetails.PostalCode));
        }

        [TestMethod]
        public void GetCustomerDetailsById_Should_Return_CustomerDetailsModel_With_Valid_Phone()
        {
            ICustomerDetailsModel customerDetails = this.customerService.GetCustomerDetailsById(MockConstants.CustomerWithoutOrdersId);

            Assert.IsFalse(string.IsNullOrWhiteSpace(customerDetails.Phone));
        }

        [TestMethod]
        public void GetCustomerDetailsById_Should_Return_CustomerDetailsModel_With_Valid_Fax()
        {
            ICustomerDetailsModel customerDetails = this.customerService.GetCustomerDetailsById(MockConstants.CustomerWithoutOrdersId);

            Assert.IsFalse(string.IsNullOrWhiteSpace(customerDetails.Fax));
        }

        #endregion

        #region GetCustomerOrdersDetailsByCustomerId Tests

        [TestMethod]
        [ExpectedException(typeof(CustomerNotFoundException))]
        public void GetCustomerOrdersDetailsByCustomerId_Should_Throw_CustomerNotFoundException_If_The_There_Is_No_Such_User_In_The_Database()
        {
            var customerOrdersDetails = this.customerService.GetCustomerOrdersDetailsByCustomerId(MockConstants.InvalidCustomerId);
        }

        [TestMethod]
        public void GetCustomerOrdersDetailsByCustomerId_Should_Return_IEnumerable_Of_ICustomerOrderDetails()
        {
            var customerOrdersDetails = this.customerService.GetCustomerOrdersDetailsByCustomerId(MockConstants.CustomerWithoutOrdersId);

            Assert.IsInstanceOfType(customerOrdersDetails, typeof(IEnumerable<ICustomerOrderDetails>));
        }

        [TestMethod]
        public void GetCustomerOrdersDetailsByCustomerId_Should_Return_IEnumerable_Of_ICustomerOrderDetails_That_Is_Not_Null()
        {
            var customerOrdersDetails = this.customerService.GetCustomerOrdersDetailsByCustomerId(MockConstants.CustomerWithoutOrdersId);

            Assert.IsNotNull(customerOrdersDetails);
        }

        [TestMethod]
        public void GetCustomerOrdersDetailsByCustomerId_Should_Return_List_With_Zero_Orders_If_The_Customer_Has_No_Orders()
        {
            var customerOrdersDetails = this.customerService.GetCustomerOrdersDetailsByCustomerId(MockConstants.CustomerWithoutOrdersId);

            Assert.AreEqual(0, customerOrdersDetails.Count());
        }

        [TestMethod]
        public void GetCustomerOrdersDetailsByCustomerId_Should_Return_A_None_Empty_List_Of_ICustomerOrderDetails_If_The_User_Has_Orders()
        {
            var customerOrdersDetails = this.customerService.GetCustomerOrdersDetailsByCustomerId(MockConstants.CustomerWithOrdersId);

            Assert.IsTrue(customerOrdersDetails.Count() > 0);
        }

        [TestMethod]
        public void GetCustomerOrdersDetailsByCustomerId_ICustomerOrderDetails_Should_Have_Valid_ProductsCount()
        {
            var customerOrdersDetails = this.customerService.GetCustomerOrdersDetailsByCustomerId(MockConstants.CustomerWithOrdersId);

            foreach (var orderDetail in customerOrdersDetails)
            {
                Assert.IsNotNull(orderDetail.ProductsCount);
                Assert.IsTrue(orderDetail.ProductsCount >= 0);
            }
        }

        [TestMethod]
        public void GetCustomerOrdersDetailsByCustomerId_First_Order_Should_Have_Products_Count_Of_10()
        {
            var customerOrdersDetails = this.customerService.GetCustomerOrdersDetailsByCustomerId(MockConstants.CustomerWithOrdersId);

            var orderDetails = customerOrdersDetails.FirstOrDefault();

            Assert.AreEqual(MockConstants.OrderQuantity, orderDetails.ProductsCount);
        }

        [TestMethod]
        public void GetCustomerOrdersDetailsByCustomerId_ICustomerOrderDetails_Should_Have_Valid_OrdersSum()
        {
            var customerOrdersDetails = this.customerService.GetCustomerOrdersDetailsByCustomerId(MockConstants.CustomerWithOrdersId);

            foreach (var orderDetail in customerOrdersDetails)
            {
                Assert.IsNotNull(orderDetail.OrderSum);
                Assert.IsTrue(orderDetail.OrderSum >= 0);
            }
        }

        [TestMethod]
        public void GetCustomerOrdersDetailsByCustomerId_OrdersSum_Should_Be_Quantity_Times_Unit_Price_If_The_Discount_Is_Zero()
        {
            var customerOrdersDetails = this.customerService.GetCustomerOrdersDetailsByCustomerId(MockConstants.CustomerWithOrdersId);

            var orderDetails = customerOrdersDetails.FirstOrDefault();

            decimal actualOrderSum = orderDetails.OrderSum;

            decimal expected = MockConstants.OrderQuantity * MockConstants.OrderUnitPrice;

            Assert.AreEqual(expected, actualOrderSum);
        }

        [TestMethod]
        public void GetCustomerOrdersDetailsByCustomerId_If_The_Discount_Is_Greater_Than_Zero_OrderSum_Should_Be_Quantity_Times_Unit_Price_Minus_The_Discount_Percentage()
        {
            var customerOrdersDetails = this.customerService.GetCustomerOrdersDetailsByCustomerId(MockConstants.CustomerWithOrdersId);

            var orderDetails = customerOrdersDetails.ElementAt(1);

            decimal actualOrderSum = orderDetails.OrderSum;

            decimal expected = 90M; // 100 - %10 = 90; - If I use the same formula used in the service layer there is no point of this test

            Assert.AreEqual(expected, actualOrderSum);
        }

        [TestMethod]
        public void GetCustomerOrdersDetailsByCustomerId_ICustomerOrderDetails_Should_Have_Valid_OrderSumWithFreight()
        {
            var customerOrdersDetails = this.customerService.GetCustomerOrdersDetailsByCustomerId(MockConstants.CustomerWithOrdersId);

            foreach (var orderDetail in customerOrdersDetails)
            {
                Assert.IsNotNull(orderDetail.OrderSumWithFreight);
                Assert.IsTrue(orderDetail.OrderSumWithFreight >= 0);
            }
        }

        [TestMethod]
        public void GetCustomerOrdersDetailsByCustomerId_OrderSumWithFreight_Should_Equal_OrderSum_If_There_Is_No_Discount_And_No_Freight_Cost()
        {
            var customerOrdersDetails = this.customerService.GetCustomerOrdersDetailsByCustomerId(MockConstants.CustomerWithOrdersId);

            var firstOrderDetails = customerOrdersDetails.FirstOrDefault();

            Assert.AreEqual(firstOrderDetails.OrderSum, firstOrderDetails.OrderSumWithFreight);
        }

        [TestMethod]
        public void GetCustomerOrdersDetailsByCustomerId_OrderSumWithFreight_Should_Be_Order_Sum_Plus_FreightCost()
        {
            var customerOrdersDetails = this.customerService.GetCustomerOrdersDetailsByCustomerId(MockConstants.CustomerWithOrdersId);

            var secondOrderDetails = customerOrdersDetails.ElementAt(1);

            decimal actualOrderSumWithFreight = secondOrderDetails.OrderSumWithFreight;

            decimal expected = 90M + (decimal)MockConstants.SecondOrderFreightCost;

            Assert.AreEqual(expected, actualOrderSumWithFreight);
        }

        [TestMethod]
        public void GetCustomerOrdersDetailsByCustomerId_First_Order_Should_Have_PossibleProblem()
        {
            var customerOrdersDetails = this.customerService.GetCustomerOrdersDetailsByCustomerId(MockConstants.CustomerWithOrdersId);

            var firstOrder = customerOrdersDetails.FirstOrDefault();

            Assert.IsTrue(firstOrder.PossibleProblem);
        }

        [TestMethod]
        public void GetCustomerOrdersDetailsByCustomerId_First_Order_Should_Not_Have_PossibleProblem()
        {
            var customerOrdersDetails = this.customerService.GetCustomerOrdersDetailsByCustomerId(MockConstants.CustomerWithOrdersId);

            var secondOrder = customerOrdersDetails.ElementAt(1);

            Assert.IsFalse(secondOrder.PossibleProblem);
        }

        #endregion
    }
}