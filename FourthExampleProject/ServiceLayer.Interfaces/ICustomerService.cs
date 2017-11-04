namespace ServiceLayer.Interfaces
{
    using ModelsInterfaces;
    using System.Collections.Generic;

    public interface ICustomerService
    {
        /// <summary>
        /// Returns all customers as ICustomerGridModel or throws an exception
        /// </summary>
        /// <exception cref="CustomerNotFoundException"></exception>
        /// <returns>IEnumerable<ICustomerGridModel></ICustomerGridModel></returns>
        IEnumerable<ICustomerGridModel> GetAllCustomers();

        /// <summary>
        /// Returns ICustomerDetailsModel or throws an exception
        /// </summary>
        /// <param name="customerId">id of the customer</param>
        /// <exception cref="CustomerNotFoundException"></exception>
        /// <returns>ICustomerDetailsModel</returns>
        ICustomerDetailsModel GetCustomerDetailsById(string customerId);

        /// <summary>
        /// Returns a list of ICustomerOrderDetails or throws an exception
        /// </summary>
        /// <param name="customerId">id of the user</param>
        /// <exception cref="CustomerNotFoundException"></exception>
        /// <returns>IEnumerable<ICustomerOrderDetails></ICustomerOrderDetails></returns>
        IEnumerable<ICustomerOrderDetails> GetCustomerOrdersDetailsByCustomerId(string customerId);
    }
}