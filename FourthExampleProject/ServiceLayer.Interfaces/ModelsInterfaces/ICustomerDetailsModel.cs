namespace ServiceLayer.Interfaces.ModelsInterfaces
{
    public interface ICustomerDetailsModel
    {
        string CustomerId { get; set; }

        string CompanyName { get; set; }

        string ContactName { get; set; }

        string ContactTitle { get; set; }

        string Address { get; set; }

        string Region { get; set; }

        string PostalCode { get; set; }

        string City { get; set; }

        string Country { get; set; }

        string Phone { get; set; }

        string Fax { get; set; }
    }
}