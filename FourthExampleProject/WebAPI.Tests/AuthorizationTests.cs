namespace WebAPI.Tests
{
    using System;
    using System.Net;
    using System.Web.Http;
    using System.Net.Http;
    using System.Collections.Generic;

    using Models;
    using Helpers;

    using Owin;
    using Microsoft.Owin.Testing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AuthorizationTests
    {
        private const string TestUserUsername = "application_user@yahoo.com";
        private const string TestUserPassword = "123123";

        private static TestServer server;
        private static HttpClient client;

        private string accessToken;

        private string AccessToken
        {
            get
            {
                if (this.accessToken == null)
                {
                    var loginResponse = this.Login();

                    if (loginResponse.IsSuccessStatusCode == false)
                    {
                        Assert.Fail("Unable to login: " + loginResponse.ReasonPhrase);
                    }

                    var loginData = loginResponse.Content.ReadAsAsync<LoginDto>().Result;

                    this.accessToken = loginData.Access_Token;
                }

                return this.accessToken;
            }
        }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            server = TestServer.Create(appBuilder =>
            {
                var config = new HttpConfiguration();
                WebApiConfig.Register(config);

                var startup = new Startup();
                startup.Configuration(appBuilder);

                appBuilder.UseWebApi(config);
            });

            client = server.HttpClient;

            client.BaseAddress = new Uri("http://localhost:58768/");

            var seedConfig = new SeedConfiguration(TestUserUsername, TestUserPassword);

            seedConfig.Seed();
        }

        [AssemblyCleanup]
        public static void Cleanup()
        {
            if (server != null)
            {
                server.Dispose();
            }
        }

        [TestMethod]
        public void GetCustomers_Should_Return_Unauthorized_If_Access_Token_Is_Not_Present_In_The_Request_Headers()
        {
            this.SetAuthorizationHeaders(false);

            var response = client.GetAsync("api/Customers/GetCustomers").Result;

            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [TestMethod]
        public void GetCustomers_If_Access_Token_Is_Present_It_Should_Execute_The_Method()
        {
            this.SetAuthorizationHeaders(true);

            var response = client.GetAsync("api/Customers/GetCustomers").Result;

            var expected = HttpStatusCode.InternalServerError; //the service is not injected and it's null!

            Assert.AreEqual(expected, response.StatusCode);
        }

        [TestMethod]
        public void GetCustomer_Should_Return_Unauthorized_If_Access_Token_Is_Not_Present_In_The_Request_Headers()
        {
            this.SetAuthorizationHeaders(false);

            var response = client.GetAsync("api/Customers/GetCustomer/ABCDE").Result;

            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [TestMethod]
        public void GetCustomer_If_Access_Token_Is_Present_It_Should_Execute_The_Method()
        {
            this.SetAuthorizationHeaders(true);

            var response = client.GetAsync("api/Customers/GetCustomer/ABCDE").Result;

            var expected = HttpStatusCode.InternalServerError; //the service is not injected and it's null!

            Assert.AreEqual(expected, response.StatusCode);
        }

        [TestMethod]
        public void GetCustomerOrders_Should_Return_Unauthorized_If_Access_Token_Is_Not_Present_In_The_Request_Headers()
        {
            this.SetAuthorizationHeaders(false);

            var response = client.GetAsync("api/Customers/GetCustomerOrders/ABCDE").Result;

            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [TestMethod]
        public void GetCustomerOrders_If_Access_Token_Is_Present_It_Should_Execute_The_Method()
        {
            this.SetAuthorizationHeaders(true);

            var response = client.GetAsync("api/Customers/GetCustomerOrders/ABCDE").Result;

            var expected = HttpStatusCode.InternalServerError; //the service is not injected and it's null!

            Assert.AreEqual(expected, response.StatusCode);
        }

        private HttpResponseMessage Login()
        {
            var loginData = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", TestUserUsername),
                new KeyValuePair<string, string>("password", TestUserPassword),
                new KeyValuePair<string, string>("grant_type", "password")
            });

            var response = client.PostAsync("Token", loginData).Result;

            return response;
        }

        private void SetAuthorizationHeaders(bool isLogged)
        {
            client.DefaultRequestHeaders.Remove("Authorization");

            if (isLogged)
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + this.AccessToken);
            }
        }
    }
}