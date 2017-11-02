namespace Courses.Web.Controllers
{
    using System.Web.Mvc;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Models.Customer.ViewModels;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            HttpClient client = new HttpClient();

            List<CustomerViewModel> customersGridModelList = new List<CustomerViewModel>();

            string route = "http://localhost:58768/api/Customers/GetCustomers";

            Task task = client.GetAsync(route).ContinueWith((resultTask) =>
            {
                 HttpResponseMessage response = resultTask.Result;

                 Task<string> responseTask = response.Content.ReadAsStringAsync();

                 responseTask.Wait();

                 string jsonString = (JObject.Parse(responseTask.Result)["result"]).ToString();

                 customersGridModelList = JsonConvert.DeserializeObject<List<CustomerViewModel>>(jsonString);
             });

            task.Wait();

            return View();
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