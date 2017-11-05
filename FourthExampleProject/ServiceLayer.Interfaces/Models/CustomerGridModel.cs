namespace ServiceLayer.Interfaces.Models
{
    using ModelsInterfaces;

    public class CustomerGridModel : ICustomerGridModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int OrdersCount { get; set; }
    }
}