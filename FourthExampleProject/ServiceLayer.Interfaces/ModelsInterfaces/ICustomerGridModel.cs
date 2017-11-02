namespace ServiceLayer.Interfaces.ModelsInterfaces
{
    public interface ICustomerGridModel
    {
        string Id { get; set; }

        string Name { get; set; }

        int OrdersCount { get; set; }
    }
}