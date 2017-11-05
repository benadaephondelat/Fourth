namespace WebAPI.Tests.Helpers
{
    using System.Collections.Generic;

    using ServiceLayer.Interfaces;
    using ServiceLayer.Interfaces.Models;
    using ServiceLayer.Interfaces.ModelsInterfaces;
    using Controllers;
    using Constants;

    using Moq;

    public class CustomersControllerMockHelper
    {
        private IEnumerable<ICustomerGridModel> customers { get; }
        private ICustomerDetailsModel customerDetails { get; }
        private IEnumerable<ICustomerOrderDetails> customerOrdersDetails { get; }

        public CustomersControllerMockHelper()
        {
            this.customers = this.GetAllCustomers();
            this.customerDetails = this.GetCustomerDetails();
            this.customerOrdersDetails = this.GetCustomerOrdersDetails();
        }

        public CustomersController CreateCustomersControllerMock()
        {
            Mock<ICustomerService> customerServiceMock = this.SetupCustomerServiceMock();

            CustomersController controller = new CustomersController(customerServiceMock.Object);

            return controller;
        }

        private Mock<ICustomerService> SetupCustomerServiceMock()
        {
            Mock<ICustomerService> serviceMock = new Mock<ICustomerService>();

            serviceMock.Setup(s => s.GetAllCustomers())
                       .Returns(this.customers);

            serviceMock.Setup(s => s.GetCustomerDetailsById(MockConstants.CustomerID))
                       .Returns(this.customerDetails);

            serviceMock.Setup(s => s.GetCustomerOrdersDetailsByCustomerId(MockConstants.CustomerID))
                       .Returns(this.customerOrdersDetails);

            return serviceMock;
        }

        private IEnumerable<ICustomerGridModel> GetAllCustomers()
        {
            var customersList = new List<CustomerGridModel>()
            {
                new CustomerGridModel()
                {
                    Id = MockConstants.FirstCustomerGridModelID,
                    Name = MockConstants.FirstCustomerGridModelName,
                    OrdersCount = MockConstants.FirstCustomerGridModelOrdersCount
                },
                new CustomerGridModel()
                {
                    Id = MockConstants.SecondCustomerGridModelID,
                    Name = MockConstants.SecondCustomerGridModelName,
                    OrdersCount = MockConstants.SecondCustomerGridModelOrdersCount
                }
            };

            return customersList;
        }

        private ICustomerDetailsModel GetCustomerDetails()
        {
            CustomerDetailsModel customerDetails = new CustomerDetailsModel()
            {
                CustomerId = MockConstants.CustomerWithOrdersId,
                CompanyName = MockConstants.CustomerWithOrdersCompanyName,
                ContactName = MockConstants.CustomerWithOrdersContactName,
                ContactTitle = MockConstants.CustomerWithOrdersContactTitle,
                Address = MockConstants.CustomerWithOrdersAddress,
                City = MockConstants.CustomerWithOrdersCity,
                Region = MockConstants.CustomerWithOrdersRegion,
                PostalCode = MockConstants.CustomerWithOrdersPostalCode,
                Country = MockConstants.CustomerWithOrdersCountry,
                Phone = MockConstants.CustomerWithOrdersPhone,
                Fax = MockConstants.CustomerWithOrdersFax,
            };

            return customerDetails;
        }

        private IEnumerable<ICustomerOrderDetails> GetCustomerOrdersDetails()
        {
            var ordersDetails = new List<CustomerOrderDetails>()
            {
                new CustomerOrderDetails()
                {
                    OrderSum = MockConstants.FirstOrderDetailsOrderSum,
                    OrderSumWithFreight = MockConstants.FirstOrderDetailsOrderSumWithFreight,
                    ProductsCount = MockConstants.FirstOrderDetailsProductsCount,
                    PossibleProblem = MockConstants.FirstOrderDetailsPossibleProblem
                },
                new CustomerOrderDetails()
                {
                    OrderSum = MockConstants.SecondOrderDetailsOrderSum,
                    OrderSumWithFreight = MockConstants.SecondOrderDetailsOrderSumWithFreight,
                    ProductsCount = MockConstants.SecondOrderDetailsProductsCount,
                    PossibleProblem = MockConstants.SecondOrderDetailsPossibleProblem
                }
            };

            return ordersDetails;
        }
    }
}