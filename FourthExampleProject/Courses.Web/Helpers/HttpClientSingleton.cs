namespace Courses.Web.Helpers
{
    using System.Net.Http;

    /// <summary>
    /// HttpClient as singleton
    /// Why I made it as a thread safe singleton and not wrap it in a using block or calling the Dispose method manually
    /// <seealso cref="https://aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/"/>
    /// </summary>
    public sealed class HttpClientSingleton
    {
        private static volatile HttpClient instance = null;
        private static object syncRoot = new object();

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

                            SetAuthroziationHeader();
                        }
                    }
                }

                return instance;
            }
        }

        public static void SetAuthroziationHeader()
        {
            string accessToken = "IPglKEp48t8hoewqlhsJcucWl6yeKXWxF3jmfTXmS2eoxnUeT43XSoubuG-fKNR12SG5gQTbobfnYgzC8mbbXM_gkqaxkhxh1pfjr4CadhElf5KUTGaTtgBcNODtpk-O5s5bIjs1bykjZeN_O9SDTDLVdbuywJIwdm1f5lO4YX4M3nbGTg6-olfer9ytsag3tYZYGz_nIF_3Dqvw1ctM4GLhmYd8wUyeBlWRKOwinyD-cgNtzSvRAeHcw8biMP3veoIFIMulf0AqYOBFhf0esdzSEkLygmHRehD5VjagoNva_HU1qvVEjZEZGdwibmfr_uxi6cCHfGTxXRIjVFnnDHZiyp96fRVzLzL4992sZW5H6iYg-qppAYV7X7jXIclDM-zsKiZ_1ehJOSYEnosjAv8iL-jYy1Xefy6iJuC-qD4I4zJf1sdiLVnT7fjPXNpvt34sKj26wszZJnj1wB4csT4EzuwtWuFPrfmA_OlQRqMaR1fXoGJn0zCxG90moD4c";

            lock (syncRoot)
            {
                if (instance == null)
                {
                    instance = new HttpClient();
                }

                instance.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            }
        }

        private HttpClientSingleton()
        {
        }
    }
}