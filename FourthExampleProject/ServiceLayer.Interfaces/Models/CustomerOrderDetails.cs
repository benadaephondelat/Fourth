namespace ServiceLayer.Interfaces.Models
{
    using ModelsInterfaces;

    public class CustomerOrderDetails : ICustomerOrderDetails
    {
        public decimal OrderSum { get; set; }

        public decimal OrderSumWithFreight { get; set; }

        public int ProductsCount { get; set; }

        public bool PossibleProblem { get; set; }
    }
}