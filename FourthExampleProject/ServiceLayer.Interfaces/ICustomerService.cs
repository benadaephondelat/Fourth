namespace ServiceLayer.Interfaces
{
    using Models;
    using System.Collections.Generic;

    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
    }
}