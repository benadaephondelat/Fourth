namespace Courses.Web.Controllers
{
    using System.Web.Mvc;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Helpers;
    using FrameworkExtentions;
    using Models.Customer.ViewModels;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    [ReAuthenticateIfTokenIsExpired]
    public class HomeController : Controller
    {
        private static HttpClient httpClient = HttpClientSingleton.Instance;

        public async Task<ActionResult> Index()
        {
            if (httpClient.DefaultRequestHeaders.Contains("Authorization") == false)
            {
                await AuthorizationHelper.RegisterUserAndAddTokenInRequestHeader(httpClient);
            }

            return View();
        }

        [HttpGet]
        public ActionResult CustomersGrid()
        {
            return View("CustomersGrid");
        }

        [HttpGet]
        public ActionResult GetCustomersGrid(string param)
        {
            List<CustomerGridViewModel> customersGridModelList = new List<CustomerGridViewModel>();

            string route = "api/Customers/GetCustomers";

            CancellationTokenSource cs = new CancellationTokenSource();

            cs.CancelAfter(1000000);

            Task task = httpClient.GetAsync(route, cs.Token).ContinueWith((resultTask) =>
            {
                HttpResponseMessage response = resultTask.Result;

                response.EnsureSuccessStatusCode();

                Task<string> responseTask = response.Content.ReadAsStringAsync();

                responseTask.Wait();

                string jsonString = (JObject.Parse(responseTask.Result)["result"]).ToString();

                customersGridModelList = JsonConvert.DeserializeObject<List<CustomerGridViewModel>>(jsonString);
            });

            task.Wait();

            return PartialView("_CustomersGrid", customersGridModelList);
        }

        [HttpGet]
        public ActionResult GetOrdersGrid(string customerId)
        {
            List<CustomerOrderDetailsGridViewModel> customerOrdersDetails = new List<CustomerOrderDetailsGridViewModel>();

            string route = "api/Customers/GetCustomerOrders/" + customerId;

            Task task = httpClient.GetAsync(route).ContinueWith((resultTask) =>
            {
                HttpResponseMessage response = resultTask.Result;

                response.EnsureSuccessStatusCode();

                Task<string> responseTask = response.Content.ReadAsStringAsync();

                responseTask.Wait();

                string jsonString = (JObject.Parse(responseTask.Result)["result"]).ToString();

                customerOrdersDetails = JsonConvert.DeserializeObject<List<CustomerOrderDetailsGridViewModel>>(jsonString);
            });

            task.Wait();

            return PartialView("_OrdersGrid", customerOrdersDetails);
        }

        [HttpGet]
        public ActionResult GetCustomer(string customerId)
        {
            CustomerDetailsViewModel customerDetails = new CustomerDetailsViewModel();

            string route = "api/Customers/GetCustomer/" + customerId;

            Task task = httpClient.GetAsync(route).ContinueWith((resultTask) =>
            {
                HttpResponseMessage response = resultTask.Result;

                response.EnsureSuccessStatusCode();

                Task<string> responseTask = response.Content.ReadAsStringAsync();

                responseTask.Wait();

                string jsonString = (JObject.Parse(responseTask.Result)["result"]).ToString();

                customerDetails = JsonConvert.DeserializeObject<CustomerDetailsViewModel>(jsonString);
            });

            task.Wait();

            return PartialView("_CustomerDetails", customerDetails);
        }
    }
}