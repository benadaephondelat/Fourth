namespace WebAPI.Tests
{
    using System.Net;
    using System.Web.Http;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Helpers;
    using Constants;
    using Controllers;
    using Courses.WebAPI.Tests.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;

    [TestClass]
    public class CustomersControllerTests
    {
        private CustomersController customersController;

        [TestInitialize]
        public void Setup()
        {
            CustomersControllerMockHelper helper = new CustomersControllerMockHelper();

            this.customersController = helper.CreateCustomersControllerMock();

            SetupController(customersController);
        }

        [TestMethod]
        public void GetAllCustomers_Should_Return_HttpStatus_Code_OK()
        {
            var actionResult = this.customersController.GetAllCustomers().ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.OK, actionResult.StatusCode);
        }

        [TestMethod]
        public void GetAllCustomers_Should_Return_Valid_JSON_That_Represents_A_List_Of_CustomerGridViewModel()
        {
            var actionResult = this.customersController.GetAllCustomers().ExecuteAsync(CancellationToken.None).Result;

            string jsonString = ConvertResponseToJsonString(actionResult);

            var customersGridModels = JsonConvert.DeserializeObject<List<CustomerGridViewModel>>(jsonString);

            Assert.IsNotNull(customersGridModels);

            Assert.IsInstanceOfType(customersGridModels, typeof(List<CustomerGridViewModel>));
        }

        [TestMethod]
        public void GetAllCustomers_CustomerGridViewModel_Should_Contain_Valid_Data()
        {
            var actionResult = this.customersController.GetAllCustomers().ExecuteAsync(CancellationToken.None).Result;

            string jsonString = ConvertResponseToJsonString(actionResult);

            var customersGridModels = JsonConvert.DeserializeObject<List<CustomerGridViewModel>>(jsonString);

            foreach (var customer in customersGridModels)
            {
                Assert.IsFalse(string.IsNullOrWhiteSpace(customer.ID));
                Assert.IsFalse(string.IsNullOrWhiteSpace(customer.Name));
                Assert.IsFalse(customer.OrdersCount < 0);
            }
        }

        [TestMethod]
        public void GetCustomer_Should_Return_HttpStatusCode_OK()
        {
            var actionResult = this.customersController.GetCustomer(MockConstants.CustomerID)
                                                       .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.OK, actionResult.StatusCode);
        }

        [TestMethod]
        public void GetCustomer_Should_Return_Valid_JSON_That_Represents_CustomerDetailsViewModel()
        {
            var actionResult = this.customersController.GetCustomer(MockConstants.CustomerID)
                                                       .ExecuteAsync(CancellationToken.None).Result;

            string jsonString = ConvertResponseToJsonString(actionResult);

            var customerDetailsModel = JsonConvert.DeserializeObject<CustomerDetailsViewModel>(jsonString);

            Assert.IsNotNull(customerDetailsModel);

            Assert.IsInstanceOfType(customerDetailsModel, typeof(CustomerDetailsViewModel));
        }

        [TestMethod]
        public void GetCustomer_CustomerDetailsViewModel_Should_Contain_Valid_Data()
        {
            var actionResult = this.customersController.GetCustomer(MockConstants.CustomerID)
                                                       .ExecuteAsync(CancellationToken.None).Result;

            string jsonString = ConvertResponseToJsonString(actionResult);

            var customerDetailsModel = JsonConvert.DeserializeObject<CustomerDetailsViewModel>(jsonString);

            Assert.IsNotNull(customerDetailsModel);

            Assert.IsFalse(string.IsNullOrEmpty(customerDetailsModel.Address));
            Assert.IsFalse(string.IsNullOrEmpty(customerDetailsModel.City));
            Assert.IsFalse(string.IsNullOrEmpty(customerDetailsModel.CompanyName));
            Assert.IsFalse(string.IsNullOrEmpty(customerDetailsModel.ContactTitle));
            Assert.IsFalse(string.IsNullOrEmpty(customerDetailsModel.Country));
            Assert.IsFalse(string.IsNullOrEmpty(customerDetailsModel.CustomerId));
            Assert.IsFalse(string.IsNullOrEmpty(customerDetailsModel.Fax));
            Assert.IsFalse(string.IsNullOrEmpty(customerDetailsModel.Phone));
            Assert.IsFalse(string.IsNullOrEmpty(customerDetailsModel.PostalCode));
            Assert.IsFalse(string.IsNullOrEmpty(customerDetailsModel.Region));
        }

        [TestMethod]
        public void GetCustomerOrders_Should_Return_HttpStatusCode_OK()
        {
            var actionResult = this.customersController.GetCustomerOrders(MockConstants.CustomerID)
                                                       .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.OK, actionResult.StatusCode);
        }

        [TestMethod]
        public void GetCustomerOrders_Should_Return_Valid_JSON_That_Represents_IEnumerable_Of_CustomerOrderDetailsGridViewModel()
        {
            var actionResult = this.customersController.GetCustomerOrders(MockConstants.CustomerID)
                                                       .ExecuteAsync(CancellationToken.None).Result;

            string jsonString = ConvertResponseToJsonString(actionResult);

            var customerOrders = JsonConvert.DeserializeObject<List<CustomerOrderDetailsGridViewModel>>(jsonString);

            Assert.IsNotNull(customerOrders);

            Assert.IsInstanceOfType(customerOrders, typeof(IEnumerable<CustomerOrderDetailsGridViewModel>));
        }

        [TestMethod]
        public void GetCustomerOrders_List_Of_CustomerOrderDetailsGridViewModel_Should_Contain_Valid_Data()
        {
            var actionResult = this.customersController.GetCustomerOrders(MockConstants.CustomerID)
                                                       .ExecuteAsync(CancellationToken.None).Result;

            string jsonString = ConvertResponseToJsonString(actionResult);

            var customerOrders = JsonConvert.DeserializeObject<List<CustomerOrderDetailsGridViewModel>>(jsonString);

            foreach (var order in customerOrders)
            {
                Assert.IsFalse(order.OrderSum < 0);
                Assert.IsFalse(order.OrderSumWithFreight < 0);
                Assert.IsFalse(order.ProductsCount < 0);
                Assert.IsTrue(order.PossibleProblem == true || order.PossibleProblem == false);
            }
        }

        private static void SetupController(CustomersController controller)
        {
            controller.Configuration = new HttpConfiguration();

            controller.Request = new HttpRequestMessage();
        }

        private static string ConvertResponseToJsonString(HttpResponseMessage actionResult)
        {
            Task<string> responseTask = actionResult.Content.ReadAsStringAsync();

            responseTask.Wait();

            string jsonString = (JObject.Parse(responseTask.Result)["result"]).ToString();

            return jsonString;
        }
    }
}