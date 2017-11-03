namespace Courses.Web.Controllers
{
    using System.Web.Mvc;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Helpers;
    using Constants;
    using FrameworkExtentions;
    using Models.Customer.ViewModels;

    [ReAuthenticateIfTokenIsExpired]
    public class HomeController : Controller
    {
        private static HttpClient httpClient = HttpClientSingleton.Instance;

        public async Task<ActionResult> Index()
        {
            if (AuthorizationHeaderIsNotPresent())
            {
                await AuthorizationHelper.RegisterOrLoginAndAddAccessTokenToRequestHeaders(httpClient);
            }

            return View();
        }

        [HttpGet]
        public ActionResult CustomersGrid()
        {
            return View(ControllerConstants.CustomersGridView);
        }

        [HttpGet]
        public ActionResult GetCustomersGrid(string param)
        {
            List<CustomerGridViewModel> customersGridModelList = new List<CustomerGridViewModel>();

            customersGridModelList = ApiCallsHelper.GetCustomerGridModelList(customersGridModelList);

            return PartialView(ControllerConstants.CustomersGridPartialView, customersGridModelList);
        }

        [HttpGet]
        public ActionResult GetOrdersGrid(string customerId)
        {
            List<CustomerOrderDetailsGridViewModel> customerOrdersDetails = new List<CustomerOrderDetailsGridViewModel>();

            customerOrdersDetails = ApiCallsHelper.GetCustomerOrdersDetails(customerId, customerOrdersDetails);

            return PartialView(ControllerConstants.OrdersGridPartialView, customerOrdersDetails);
        }

        [HttpGet]
        public ActionResult GetCustomer(string customerId)
        {
            CustomerDetailsViewModel customerDetails = new CustomerDetailsViewModel();

            customerDetails = ApiCallsHelper.GetCustomerDetails(customerId, customerDetails);

            return PartialView(ControllerConstants.CustomerDetailsPartialView, customerDetails);
        }

        [HttpGet]
        public ActionResult Error()
        {
            return View();
        }

        /// <summary>
        /// Checks if there is a Authorization header in the default request headers
        /// </summary>
        /// <returns>bool</returns>
        private static bool AuthorizationHeaderIsNotPresent()
        {
            return httpClient.DefaultRequestHeaders.Contains("Authorization") == false;
        }
    }
}