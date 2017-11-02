namespace ServiceLayer.Interfaces
{
    using ModelsInterfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICustomerService
    {
        Task<IEnumerable<ICustomerGridModel>> GetAllCustomersAsync();
    }
}