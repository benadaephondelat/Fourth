namespace Courses.Web.Helpers
{
    using System;
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

        public const string Authorization = "Authorization";
        public static DateTime? TokenExpirationDate = null;

        public static async Task RegisterUserAndAddTokenInRequestHeader(HttpClient client)
        {
            FormUrlEncodedContent requestContent = GetRegisterFormContent();

            HttpResponseMessage response = await client.PostAsync(RegisterUrl, requestContent);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRequestException("Unable to register!");
            }

            string accessToken = await GetAuthorizationTokenAsync(client);

            client.DefaultRequestHeaders.Add(Authorization, "Bearer " + accessToken);
        }

        public static async Task GetAccessTokenAndAddToRequestHeader(HttpClient client)
        {
            string accessToken = await GetAuthorizationTokenAsync(client);

            if (client.DefaultRequestHeaders.Contains(Authorization))
            {
                client.DefaultRequestHeaders.Remove(Authorization);
            }

            client.DefaultRequestHeaders.Add(Authorization, "Bearer " + accessToken);
        }

        private static async Task<string> GetAuthorizationTokenAsync(HttpClient client)
        {
            FormUrlEncodedContent requestContent = GetAccessTokenFormContent();

            HttpResponseMessage response = await client.PostAsync(GetTokenUrl, requestContent);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string result = await response.Content.ReadAsStringAsync();

                JObject jObject = JObject.Parse(result);

                string token = jObject.SelectToken("access_token").ToString();

                SetTokenExpirationDate(jObject);

                return token;
            }

            throw new HttpRequestException("Unable to get access token from the API !");
        }

        private static void SetTokenExpirationDate(JObject jObject)
        {
            string tokenExpirationDate = jObject.GetValue(".expires").ToString();

            DateTime tokenExpirationDateTime = DateTime.Parse(tokenExpirationDate);

            TokenExpirationDate = tokenExpirationDateTime;
        }

        private static FormUrlEncodedContent GetRegisterFormContent()
        {
            FormUrlEncodedContent registerForm = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Email", Email),
                new KeyValuePair<string, string>("Password", Password),
                new KeyValuePair<string, string>("ConfirmPassword", Password)
            });

            return registerForm;
        }

        private static FormUrlEncodedContent GetAccessTokenFormContent()
        {
            FormUrlEncodedContent accessTokenForm = new FormUrlEncodedContent(new[]
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