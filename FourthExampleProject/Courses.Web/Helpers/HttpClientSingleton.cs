namespace Courses.Web.Helpers
{
    using System.Net.Http;

    /// <summary>
    /// HttpClient as singleton
    /// Why I made it as singleton and not wrap it in a using block or calling the Dispose method manually
    /// <seealso cref="https://aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/"/>
    /// </summary>
    public sealed class HttpClientSingleton
    {
        private static volatile HttpClient instance = null;
        private static object syncRoot = new object();

        /// <summary>
        /// Get an instance of the HttpClient
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