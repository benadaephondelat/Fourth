using System.Linq;
using System.Collections.Generic;

using ServiceLayer.Models;
using ServiceLayer.Helpers;
using ServiceLayer.Interfaces;
using ServiceLayer.LinqExtentions;
using ServiceLayer.Interfaces.ModelsInterfaces;

using Models;
using DataLayer.Interfaces;
using Exceptions.Customer;

namespace ServiceLayer
{
    public class CustomerService : ICustomerService
    {
        private IData data;

        public CustomerService(IData data)
        {
            this.data = data;
        }

        public IEnumerable<ICustomerGridModel> GetAllCustomers()
        {
            if (ThereIsNoCustomers())
            {
                return new List<CustomerGridModel>();
            }

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
            Customer customer = this.GetCustomerById(customerId);

            ICustomerDetailsModel customerDetailsModel = ObjectMappingHelper.CreateCustomerDetailsModel(customer);

            return customerDetailsModel;
        }

        public IEnumerable<ICustomerOrderDetails> GetCustomerOrdersDetailsByCustomerId(string customerId)
        {
            Customer customer = this.GetCustomerById(customerId);

            var result = customer.Orders.Select(o => new CustomerOrderDetails
            {
                ProductsCount = o.Order_Details.Sum(d => d.Quantity),
                OrderSum = o.Order_Details.GetOrdersSum(),
                OrderSumWithFreight = o.Order_Details.GetOrdersSumWithFreight(o.Freight),
                PossibleProblem = o.Order_Details.Any(d => d.Product.Discontinued || d.Product.UnitsInStock < d.Product.UnitsOnOrder)
            }).OrderByDescending(c => c.OrderSum).ToList();

            return result;
        }

        /// <summary>
        /// Rerturns a Customer or throws an exception
        /// </summary>
        /// <param name="customerId">id of the customer</param>
        /// <exception cref="CustomerNotFoundException"></exception>
        /// <returnsCustomer></returns>
        private Customer GetCustomerById(string customerId)
        {
            Customer customer = this.data.Customers.All().FirstOrDefault(c => c.CustomerID == customerId);

            if (customer == null)
            {
                throw new CustomerNotFoundException();
            }

            return customer;
        }

        /// <summary>
        /// Checks if there are no customers in the database
        /// </summary>
        /// <returns>bool</returns>
        private bool ThereIsNoCustomers()
        {
            return this.data.Customers.All().Any() == false;
        }
    }
}