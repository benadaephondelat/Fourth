namespace Courses.Web.Controllers
{
    using System.Web.Mvc;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Models.Customer.ViewModels;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Helpers;

    public class HomeController : Controller
    {
        private static HttpClient httpClient = HttpClientSingleton.Instance;

        public ActionResult Index()
        {
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

            string route = "http://localhost:58768/api/Customers/GetCustomers";

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

            string route = "http://localhost:58768/api/Customers/GetCustomerOrders/" + customerId;

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
            //make two requests, one concise view model, print customer info and pass order info to grid
            //or make one request is better

            CustomerDetailsViewModel customerDetails = new CustomerDetailsViewModel();

            string route = "http://localhost:58768/api/Customers/GetCustomer/" + customerId;

            Task task = httpClient.GetAsync(route).ContinueWith((resultTask) =>
            {
                HttpResponseMessage response = resultTask.Result;

                Task<string> responseTask = response.Content.ReadAsStringAsync();

                responseTask.Wait();

                string jsonString = (JObject.Parse(responseTask.Result)["result"]).ToString();

                customerDetails = JsonConvert.DeserializeObject<CustomerDetailsViewModel>(jsonString);
            });

            task.Wait();

            return PartialView("_CustomerDetails", customerDetails);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}