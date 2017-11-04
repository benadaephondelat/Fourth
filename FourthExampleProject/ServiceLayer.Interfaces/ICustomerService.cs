namespace ServiceLayer.Interfaces
{
    using ModelsInterfaces;
    using System.Collections.Generic;

    public interface ICustomerService
    {
        /// <summary>
        /// Returns all customers or throws an execption
        /// </summary>
        /// <exception cref="CustomerNotFoundException"></exception>
        /// <returns>IEnumerable<ICustomerGridModel></ICustomerGridModel></returns>
        IEnumerable<ICustomerGridModel> GetAllCustomers();

        ICustomerDetailsModel GetCustomerDetailsById(string customerId);

        IEnumerable<ICustomerOrderDetails> GetCustomerOrdersDetailsByCustomerId(string customerId);
    }
}