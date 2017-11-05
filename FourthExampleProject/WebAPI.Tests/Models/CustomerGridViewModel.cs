namespace Courses.WebAPI.Tests.Models
{
    using Newtonsoft.Json;

    public class CustomerGridViewModel
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ordersCount")]
        public int OrdersCount { get; set; }
    }
}