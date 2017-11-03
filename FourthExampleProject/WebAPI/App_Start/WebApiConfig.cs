namespace WebAPI
{
    using System;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using System.Net.Http.Headers;

    using Microsoft.Owin.Security.OAuth;
    using Newtonsoft.Json.Serialization;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            EnableCorsAttribute corsSettings = GetCorsSettings();
            config.EnableCors(corsSettings);

            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }

        /// <summary>
        /// Returns the CORS settings
        /// </summary>
        /// <returns>EnableCorsAttribute</returns>
        [Obsolete("Do not allow every origin, header and method!")]
        private static EnableCorsAttribute GetCorsSettings()
        {
            string allowedOrigins = "*";
            string allowedHeaders = "*";
            string allowedMethods = "*";

            EnableCorsAttribute corsSettings = new EnableCorsAttribute(allowedOrigins, allowedHeaders, allowedMethods);

            return corsSettings;
        }
    }
}