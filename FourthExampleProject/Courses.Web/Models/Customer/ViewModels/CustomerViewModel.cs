namespace Courses.Web.Models.Customer.ViewModels
{
    using Newtonsoft.Json;

    public class CustomerViewModel
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ordersCount")]
        public int OrdersCount { get; set; }
    }
}