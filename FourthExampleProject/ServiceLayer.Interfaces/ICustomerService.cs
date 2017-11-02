namespace ServiceLayer.Interfaces
{
    using ModelsInterfaces;
    using System.Collections.Generic;

    public interface ICustomerService
    {
        IEnumerable<ICustomerGridModel> GetAllCustomers();
    }
}