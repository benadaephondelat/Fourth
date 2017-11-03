namespace Courses.Web.Models.Customer.ViewModels
{
    using Newtonsoft.Json;

    public class CustomerOrderDetailsGridViewModel
    {
        [JsonProperty("orderSum")]
        public decimal OrderSum { get; set; }

        [JsonProperty("productsCount")]
        public int ProductsCount { get; set; }

        [JsonProperty("possibleProblem")]
        public bool PossibleProblem { get; set; }
    }
}