namespace ServiceLayer.Models
{
    using Interfaces.ModelsInterfaces;

    public class CustomerGridModel : ICustomerGridModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int OrdersCount { get; set; }
    }
}