namespace WebAPI.Controllers
{
    using System.Web.Http;
    using System.Threading.Tasks;
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
        public async Task<IHttpActionResult> GetAllCustomers()
        {
            //TODO REMOVE THAT "ASYNC" CALL, BECAUSE THAT LIBRARY CAN NOT BE TRUSTED
            IEnumerable<ICustomerGridModel> customers = await this.customerService.GetAllCustomersAsync();

            var result = new
            {
                result = customers
            };

            return this.Ok(result);
        }
    }
}