namespace ServiceLayer.Models
{
    using Interfaces.ModelsInterfaces;

    public class CustomerOrderDetails : ICustomerOrderDetails
    {
        public decimal OrderSum { get; set; }

        public decimal OrderSumWithFreight { get; set; }

        public int ProductsCount { get; set; }

        public bool PossibleProblem { get; set; }
    }
}