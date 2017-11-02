namespace ServiceLayer
{
    using System.Linq;
    using System.Threading.Tasks;
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
    }
}