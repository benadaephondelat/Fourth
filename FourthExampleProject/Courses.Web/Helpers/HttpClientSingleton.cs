namespace Courses.Web.Helpers
{
    using System;
    using System.Net.Http;

    /// <summary>
    /// HttpClient as singleton
    /// Why I made it as a thread safe singleton and not wrap it in a using block or calling the Dispose method manually
    /// <seealso cref="https://aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/"/>
    /// </summary>
    public sealed class HttpClientSingleton
    {
        private static object syncRoot = new object();
        private static volatile HttpClient instance = null;
        private static Uri BaseAddress = new Uri("http://localhost:58768/");

        /// <summary>
        /// Get the HttpClient
        /// </summary>
        public static HttpClient Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new HttpClient();

                            instance.BaseAddress = BaseAddress;
                        }
                    }
                }

                return instance;
            }
        }

        private HttpClientSingleton()
        {
        }
    }
}