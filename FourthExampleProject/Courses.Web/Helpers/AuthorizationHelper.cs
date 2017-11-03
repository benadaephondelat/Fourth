namespace Courses.Web.Helpers
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Newtonsoft.Json.Linq;

    public static class AuthorizationHelper
    {
        public const string GetTokenUrl = "Token";
        public const string RegisterUrl = "api/Account/Register";

        public const string Email = "application_user@yahoo.com";
        public const string Password = "123123";

        public static async Task RegisterUserAndAddTokenInRequestHeader(HttpClient client)
        {
            var requestContent = GetRegisterFormContent();

            HttpResponseMessage response = await client.PostAsync(RegisterUrl, requestContent);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRequestException("Unable to register!");
            }

            string accessToken = await GetAuthorizationToken(client);

            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
        }

        public static async Task GetAccessTokenAndAddToRequestHeader(HttpClient client)
        {
            var accessToken = await GetAuthorizationToken(client);

            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
        }

        private static async Task<string> GetAuthorizationToken(HttpClient client)
        {
            var requestContent = GetAccessTokenFormContent();

            HttpResponseMessage response = await client.PostAsync(GetTokenUrl, requestContent);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string result = await response.Content.ReadAsStringAsync();

                JObject jObject = JObject.Parse(result);

                var token = jObject.SelectToken("access_token").ToString();

                return token;
            }

            throw new HttpRequestException("Unable to get access token from the API !");
        }

        private static FormUrlEncodedContent GetRegisterFormContent()
        {
            var registerForm = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Email", Email),
                new KeyValuePair<string, string>("Password", Password),
                new KeyValuePair<string, string>("ConfirmPassword", Password)
            });

            return registerForm;
        }

        private static FormUrlEncodedContent GetAccessTokenFormContent()
        {
            var accessTokenForm = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("Username", Email),
                new KeyValuePair<string, string>("Password", Password),
                new KeyValuePair<string, string>("ConfirmPassword", Password)
            });

            return accessTokenForm;
        }
    }
}