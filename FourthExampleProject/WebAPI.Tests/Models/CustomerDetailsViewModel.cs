namespace Courses.WebAPI.Tests.Models
{
    using Newtonsoft.Json;

    public class CustomerDetailsViewModel
    {
        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [JsonProperty("contactName")]
        public string ContactName { get; set; }

        [JsonProperty("contactTitle")]
        public string ContactTitle { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("fax")]
        public string Fax { get; set; }
    }
}