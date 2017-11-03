namespace ServiceLayer
{
    using global::Models;
    using Models;

    public static class LinqExtentions
    {
        /// <summary>
        /// Creates a CustomerDetailsModel from a given Customer model
        /// </summary>
        /// <param name="source">Customer</param>
        /// <returns>CustomerDetailsModel</returns>
        public static CustomerDetailsModel CreateCustomerDetailsModel(this Customer source)
        {
            CustomerDetailsModel customerDetails = new CustomerDetailsModel();

            customerDetails.CustomerId = source.CustomerID;
            customerDetails.CompanyName = source.CompanyName;
            customerDetails.ContactName = source.ContactName;
            customerDetails.ContactTitle = source.ContactTitle;
            customerDetails.Address = source.Address;
            customerDetails.City = source.City;
            customerDetails.Country = source.Country;
            customerDetails.Region = source.Region;
            customerDetails.PostalCode = source.PostalCode;
            customerDetails.Phone = source.Phone;
            customerDetails.Fax = source.Fax;

            return customerDetails;
        }
    }
}