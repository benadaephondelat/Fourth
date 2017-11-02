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

        public async Task<IEnumerable<ICustomerGridModel>> GetAllCustomersAsync()
        {
            var customers = this.data.Customers.All().AsParallel().Select(c => new CustomerGridModel
            {
                Id = c.CustomerID,
                Name = c.CompanyName,
                OrdersCount = c.Orders.Count(),

            }).OrderBy(c => c.Name).ToList();

            return customers;
        }
    }
}