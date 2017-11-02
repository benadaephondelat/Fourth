namespace WebAPI.Controllers
{
    using System.Web.Http;
    using System.Collections.Generic;

    using ServiceLayer.Interfaces;
    using ServiceLayer.Interfaces.ModelsInterfaces;

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
    }
}