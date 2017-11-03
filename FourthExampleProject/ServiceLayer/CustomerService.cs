namespace ServiceLayer
{
    using System.Linq;
    using System.Collections.Generic;

    using Models;
    using Interfaces;
    using DataLayer.Interfaces;
    using Interfaces.ModelsInterfaces;

    public class CustomerService : ICustomerService
    {
        private IData data;

        public CustomerService(IData data)
        {
            this.data = data;
        }

        public IEnumerable<ICustomerGridModel> GetAllCustomers()
        {
            var customers = this.data.Customers.All().Select(c => new CustomerGridModel
            {
                Id = c.CustomerID,
                Name = c.CompanyName,
                OrdersCount = c.Orders.Count(),

            }).OrderByDescending(c => c.OrdersCount).ToList();

            return customers;
        }

        public ICustomerDetailsModel GetCustomerDetailsById(string customerId)
        {
            var customer = this.data.Customers.All().Where(c => c.CustomerID == customerId)
                                                    .FirstOrDefault();

            if (customer == null)
            {
                //TODO
            }

            var result = LinqExtentions.CreateCustomerDetailsModel(customer);

            return result;
        }

        public IEnumerable<ICustomerOrderDetails> GetCustomerOrdersDetailsByCustomerId(string customerId)
        {
            var customer = this.data.Customers.All().FirstOrDefault(c => c.CustomerID == customerId);

            if (customer == null)
            {
                //TODO
            }

            var result = customer.Orders.Select(o => new CustomerOrderDetails
            {
                ProductsCount = o.Order_Details.Sum(d => d.Quantity),
                OrderSum = o.Order_Details.Sum(d => d.Discount == 0 ? d.Quantity * d.UnitPrice : d.Quantity * d.UnitPrice - ((d.Quantity * d.UnitPrice) * (decimal)d.Discount) ),
                PossibleProblem = o.Order_Details.Any(d => d.Product.Discontinued || d.Product.UnitsInStock < d.Product.UnitsOnOrder)
            }).OrderByDescending(c => c.OrderSum).ToList();

            return result;
        }
    }
}