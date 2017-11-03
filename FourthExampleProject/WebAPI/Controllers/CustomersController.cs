namespace WebAPI.Controllers
{
    using System.Web.Http;
    using System.Collections.Generic;

    using ServiceLayer.Interfaces;
    using ServiceLayer.Interfaces.ModelsInterfaces;

    [Authorize]
    [RoutePrefix("api/Customers")]
    public class CustomersController : ApiController
    {
        private readonly ICustomerService customerService;

        public CustomersController()
        {
        }

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        [Route("GetCustomers")]
        public IHttpActionResult GetAllCustomers()
        {
            IEnumerable<ICustomerGridModel> customers = this.customerService.GetAllCustomers();

            var result = new
            {
                result = customers
            };

            return this.Ok(result);
        }

        [HttpGet]
        [Route("GetCustomer/{id}")]
        public IHttpActionResult GetCustomer(string id)
        {
            ICustomerDetailsModel customerDetails = this.customerService.GetCustomerDetailsById(id);

            var result = new
            {
                result = customerDetails
            };

            return this.Ok(result);
        }

        [HttpGet]
        [Route("GetCustomerOrders/{id}")]
        public IHttpActionResult GetCustomerOrders(string id)
        {
            var customerOrdersDetails = this.customerService.GetCustomerOrdersDetailsByCustomerId(id);

            var result = new
            {
                result = customerOrdersDetails
            };

            return this.Ok(result);
        }
    }
}