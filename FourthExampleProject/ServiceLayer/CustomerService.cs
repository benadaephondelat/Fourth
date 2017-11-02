namespace ServiceLayer
{
    using System.Linq;
    using System.Collections.Generic;

    using Models;
    using Interfaces;
    using DataLayer.Interfaces;

    public class CustomerService : ICustomerService
    {
        private IData data;

        public CustomerService(IData data)
        {
            this.data = data;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            IEnumerable<Customer> allCustomers = this.data.Customers.All().ToList();

            return allCustomers;
        }
    }
}