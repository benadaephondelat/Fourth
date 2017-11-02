using ServiceLayer.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        private readonly ICustomerService customerService;

        public ValuesController()
        {
        }

        public ValuesController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            var serviceLayerTest = this.customerService.GetAllCustomers();

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
