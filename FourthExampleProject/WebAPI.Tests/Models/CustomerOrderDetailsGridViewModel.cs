namespace Courses.WebAPI.Tests.Models
{
    using Newtonsoft.Json;

    public class CustomerOrderDetailsGridViewModel
    {
        [JsonProperty("orderSum")]
        public decimal OrderSum { get; set; }

        [JsonProperty("orderSumWithFreight")]
        public decimal OrderSumWithFreight { get; set; }

        [JsonProperty("productsCount")]
        public int ProductsCount { get; set; }

        [JsonProperty("possibleProblem")]
        public bool PossibleProblem { get; set; }
    }
}