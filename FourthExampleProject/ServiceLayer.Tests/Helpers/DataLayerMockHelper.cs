namespace ServiceLayer.Tests.Helpers
{
    using DataLayer.Interfaces;
    using global::Models;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;

    public class DataLayerMockHelper
    {
        private List<Customer> Customers { get; }

        private List<Order> Orders { get; }

        public DataLayerMockHelper()
        {
            this.Customers = this.GetDefaultCustomersList();
            this.Orders = this.GetDefaultOrdersList();
        }

        public Mock<IData> SetupTicTacToeDataMock()
        {
            Mock<IData> dataMock = new Mock<IData>();

            this.AddCustomersUserRepoMock(dataMock);
            this.AddOrdersRepoMock(dataMock);

            return dataMock;
        }

        /// <summary>
        /// Inserts mocked Customers repository to the DataLayer mock 
        /// </summary>
        /// <param name="coursesDataMock">DataLayer mock</param>
        private void AddCustomersUserRepoMock(Mock<IData> coursesDataMock)
        {
            IGenericRepository<Customer> customersRepoMock = this.SetupCustomersRepoMock();

            coursesDataMock.Setup(p => p.Customers).Returns(customersRepoMock);
        }

        /// <summary>
        /// Generates a mock of the Customers repository.
        /// </summary>
        /// <returns>IGenericRepository Customers</returns>
        private IGenericRepository<Customer> SetupCustomersRepoMock()
        {
            Mock<IGenericRepository<Customer>> userRepoMock = new Mock<IGenericRepository<Customer>>();

            userRepoMock.Setup(prop => prop.All()).Returns(this.Customers.AsQueryable());

            return userRepoMock.Object;
        }

        /// <summary>
        /// Inserts mocked Orders repository to the DataLayer mock 
        /// </summary>
        /// <param name="coursesDataMock">DataLayer mock</param>
        private void AddOrdersRepoMock(Mock<IData> coursesDataMock)
        {
            IGenericRepository<Order> customersRepoMock = this.SetupOrdersRepoMock();

            coursesDataMock.Setup(p => p.Orders).Returns(customersRepoMock);
        }

        /// <summary>
        /// Generates a mock of the Order repository.
        /// </summary>
        /// <returns>IGenericRepository Customers</returns>
        private IGenericRepository<Order> SetupOrdersRepoMock()
        {
            Mock<IGenericRepository<Order>> userRepoMock = new Mock<IGenericRepository<Order>>();

            userRepoMock.Setup(prop => prop.All()).Returns(this.Orders.AsQueryable());

            return userRepoMock.Object;
        }

        private List<Customer> GetDefaultCustomersList()
        {
            var customersList = new List<Customer>()
            {
                this.customerWithOrders,
                this.customerWithoutOrders,
            };

            return customersList;
        }

        private Customer customerWithoutOrders = new Customer()
        {
            CustomerID = MockConstants.CustomerWithoutOrdersId,
            CompanyName = MockConstants.CustomerWithoutOrdersCompanyName,
            ContactName = MockConstants.CustomerWithoutOrdersContactName,
            Address = MockConstants.CustomerWithoutOrdersAddress,
            City = MockConstants.CustomerWithoutOrdersCity,
            Region = MockConstants.CustomerWithoutOrdersRegion,
            PostalCode = MockConstants.CustomerWithoutOrdersPostalCode,
            Country = MockConstants.CustomerWithoutOrdersCountry,
            Phone = MockConstants.CustomerWithoutOrdersPhone,
            Fax = MockConstants.CustomerWithoutOrdersFax,
            Orders = new List<Order>()
        };

        private Customer customerWithOrders = new Customer()
        {
            CustomerID = MockConstants.CustomerWithOrdersId,
            CompanyName = MockConstants.CustomerWithOrdersCompanyName,
            ContactName = MockConstants.CustomerWithOrdersContactName,
            Address = MockConstants.CustomerWithOrdersAddress,
            City = MockConstants.CustomerWithOrdersCity,
            Region = MockConstants.CustomerWithOrdersRegion,
            PostalCode = MockConstants.CustomerWithOrdersPostalCode,
            Country = MockConstants.CustomerWithOrdersCountry,
            Phone = MockConstants.CustomerWithOrdersPhone,
            Fax = MockConstants.CustomerWithOrdersFax,
            Orders = new List<Order>()
            {
                new Order()
                {
                    OrderID = MockConstants.OrderId,
                    CustomerID = MockConstants.CustomerWithOrdersId,
                    EmployeeID = null,
                    OrderDate = MockConstants.OrderDate,
                    RequiredDate = MockConstants.RequiredDate,
                    ShippedDate = MockConstants.ShippedDate,
                    ShipVia = null,
                    Freight = MockConstants.Freight,
                    ShipName = MockConstants.ShipName,
                    ShipCity = MockConstants.ShipCity,
                    ShipRegion = MockConstants.ShipRegion,
                    ShipPostalCode = MockConstants.ShipPostalCode,
                    ShipCountry = MockConstants.ShipCountry,
                    Customer = new Customer()
                    {
                        CustomerID = MockConstants.CustomerWithOrdersId,
                        CompanyName = MockConstants.CustomerWithOrdersCompanyName,
                        ContactName = MockConstants.CustomerWithOrdersContactName,
                        Address = MockConstants.CustomerWithOrdersAddress,
                        City = MockConstants.CustomerWithOrdersCity,
                        Region = MockConstants.CustomerWithOrdersRegion,
                        PostalCode = MockConstants.CustomerWithOrdersPostalCode,
                        Country = MockConstants.CustomerWithOrdersCountry,
                        Phone = MockConstants.CustomerWithOrdersPhone,
                        Fax = MockConstants.CustomerWithOrdersFax,
                        Orders = new List<Order>()
                    },
                }
            }
        };

        private List<Order> GetDefaultOrdersList()
        {
            var ordersList = new List<Order>()
            {
                this.order
            };

            return ordersList;
        }

        private Order order = new Order()
        {
            OrderID = MockConstants.OrderId,
            CustomerID = MockConstants.CustomerWithOrdersId,
            EmployeeID = MockConstants.EmployeeID,
            OrderDate = MockConstants.OrderDate,
            RequiredDate = MockConstants.RequiredDate,
            ShippedDate = MockConstants.ShippedDate,
            ShipVia = null,
            Freight = MockConstants.Freight,
            ShipName = MockConstants.ShipName,
            ShipCity = MockConstants.ShipCity,
            ShipRegion = MockConstants.ShipRegion,
            ShipPostalCode = MockConstants.ShipPostalCode,
            ShipCountry = MockConstants.ShipCountry,
            Customer = new Customer()
            {
                CustomerID = MockConstants.CustomerWithOrdersId,
                CompanyName = MockConstants.CustomerWithOrdersCompanyName,
                ContactName = MockConstants.CustomerWithOrdersContactName,
                Address = MockConstants.CustomerWithOrdersAddress,
                City = MockConstants.CustomerWithOrdersCity,
                Region = MockConstants.CustomerWithOrdersRegion,
                PostalCode = MockConstants.CustomerWithOrdersPostalCode,
                Country = MockConstants.CustomerWithOrdersCountry,
                Phone = MockConstants.CustomerWithOrdersPhone,
                Fax = MockConstants.CustomerWithOrdersFax,
                Orders = new List<Order>()
            },
            Employee = new Employee()
            {
                EmployeeID = MockConstants.EmployeeID,
                LastName = MockConstants.EmployeeLastName,
                FirstName = MockConstants.EmployeeFirstName,
                Title = MockConstants.EmployeeTitle,
                TitleOfCourtesy = MockConstants.EmployeeTitleOfCourtesy,
                Address = MockConstants.EmployeeAddress,
                City = MockConstants.EmployeeCity,
                Region = MockConstants.EmployeeRegion,
                PostalCode = MockConstants.EmployeePostalCode,
                Country = MockConstants.EmployeeCountry,
                HomePhone = MockConstants.EmployeeHomePhone,
                Extension = MockConstants.EmployeeExtension,
                Photo = MockConstants.EmployeePhoto,
                PhotoPath = MockConstants.EmployeePhotoPath,
                Notes = MockConstants.EmployeeNotes,
                Employees1 = new List<Employee>(),
                Orders = new List<Order>(),
                Territories = new List<Territory>()
            },
            Order_Details = new List<Order_Detail>()
            {
                new Order_Detail()
                {
                    OrderID = MockConstants.OrderID,
                    Discount = MockConstants.OrderDiscount,
                    Quantity = MockConstants.OrderQuantity,
                    UnitPrice = MockConstants.OrderUnitPrice,
                    Product = new Product()
                    {
                        ProductID = MockConstants.ProductID,
                        ProductName = MockConstants.ProductName,
                        SupplierID = MockConstants.ProductSupplierID,
                        CategoryID = MockConstants.ProductCategoryID,
                        QuantityPerUnit = MockConstants.ProductQuantityPerUnit,
                        UnitPrice = MockConstants.ProductUnitPrice,
                        UnitsInStock = MockConstants.ProductUnitsInStock,
                        UnitsOnOrder = MockConstants.ProductUnitsOnOrder,
                        ReorderLevel = MockConstants.ProductReorderLevel,
                        Discontinued = MockConstants.ProductDiscontinued,
                        Order_Details = new List<Order_Detail>()
                    }
                }
            }
        };

        Employee employee = new Employee()
        {
            EmployeeID = MockConstants.EmployeeID,
            LastName = MockConstants.EmployeeLastName,
            FirstName = MockConstants.EmployeeFirstName,
            Title = MockConstants.EmployeeTitle,
            TitleOfCourtesy = MockConstants.EmployeeTitleOfCourtesy,
            Address = MockConstants.EmployeeAddress,
            City = MockConstants.EmployeeCity,
            Region = MockConstants.EmployeeRegion,
            PostalCode = MockConstants.EmployeePostalCode,
            Country = MockConstants.EmployeeCountry,
            HomePhone = MockConstants.EmployeeHomePhone,
            Extension = MockConstants.EmployeeExtension,
            Photo = MockConstants.EmployeePhoto,
            PhotoPath = MockConstants.EmployeePhotoPath,
            Notes = MockConstants.EmployeeNotes,
            Employees1 = new List<Employee>(),
            Orders = new List<Order>(),
            Territories = new List<Territory>()
        };

        Product product = new Product()
        {
            ProductID = MockConstants.ProductID,
            ProductName = MockConstants.ProductName,
            SupplierID = MockConstants.ProductSupplierID,
            CategoryID = MockConstants.ProductCategoryID,
            QuantityPerUnit = MockConstants.ProductQuantityPerUnit,
            UnitPrice = MockConstants.ProductUnitPrice,
            UnitsInStock = MockConstants.ProductUnitsInStock,
            UnitsOnOrder = MockConstants.ProductUnitsOnOrder,
            ReorderLevel = MockConstants.ProductReorderLevel,
            Discontinued = MockConstants.ProductDiscontinued,
            Order_Details = new List<Order_Detail>()
        };
    }
}