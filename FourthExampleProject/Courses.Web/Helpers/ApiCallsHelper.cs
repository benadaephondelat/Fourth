namespace Courses.Web.Helpers
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Models.Customer.ViewModels;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public static class ApiCallsHelper
    {
        private static int AllowedDelayInResponse = 5000;

        public static List<CustomerOrderDetailsGridViewModel> GetCustomerOrdersDetails(string customerId, List<CustomerOrderDetailsGridViewModel> customerOrdersDetails)
        {
            string route = "api/Customers/GetCustomerOrders/" + customerId;

            CancellationTokenSource cs = new CancellationTokenSource(AllowedDelayInResponse);

            Task task = HttpClientSingleton.Instance.GetAsync(route, cs.Token).ContinueWith((resultTask) =>
            {
                string jsonString = GetResponseAsJsonString(resultTask);

                customerOrdersDetails = JsonConvert.DeserializeObject<List<CustomerOrderDetailsGridViewModel>>(jsonString);
            });

            task.Wait();

            return customerOrdersDetails;
        }

        public static List<CustomerGridViewModel> GetCustomerGridModelList(List<CustomerGridViewModel> customersGridModelList)
        {
            string route = "api/Customers/GetCustomers";

            CancellationTokenSource cs = new CancellationTokenSource(AllowedDelayInResponse);

            Task task = HttpClientSingleton.Instance.GetAsync(route, cs.Token).ContinueWith((resultTask) =>
            {
                string jsonString = GetResponseAsJsonString(resultTask);

                customersGridModelList = JsonConvert.DeserializeObject<List<CustomerGridViewModel>>(jsonString);
            });

            task.Wait();

            return customersGridModelList;
        }

        public static CustomerDetailsViewModel GetCustomerDetails(string customerId, CustomerDetailsViewModel customerDetails)
        {
            string route = "api/Customers/GetCustomer/" + customerId;

            CancellationTokenSource cs = new CancellationTokenSource(AllowedDelayInResponse);

            Task task = HttpClientSingleton.Instance.GetAsync(route, cs.Token).ContinueWith((resultTask) =>
            {
                string jsonString = GetResponseAsJsonString(resultTask);

                customerDetails = JsonConvert.DeserializeObject<CustomerDetailsViewModel>(jsonString);
            });

            task.Wait();

            return customerDetails;
        }

        private static string GetResponseAsJsonString(Task<HttpResponseMessage> resultTask)
        {
            HttpResponseMessage response = resultTask.Result;

            response.EnsureSuccessStatusCode();

            Task<string> responseTask = response.Content.ReadAsStringAsync();

            responseTask.Wait();

            string jsonString = (JObject.Parse(responseTask.Result)["result"]).ToString();

            return jsonString;
        }
    }
}