namespace Courses.Web.FrameworkExtentions
{
    using Helpers;
    using System;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    /// <summary>
    /// If the access token is expired, get the new one and add it to the request headers
    /// </summary>
    public class ReAuthenticateIfTokenIsExpired : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (AuthorizationHelper.TokenExpirationDate == null)
            {
                return;
            }

            if (DateTime.Now > AuthorizationHelper.TokenExpirationDate)
            {
                var httpClient = HttpClientSingleton.Instance;

                var result = Task.Run(async () =>
                {
                    await AuthorizationHelper.GetAccessTokenAndAddToRequestHeader(httpClient);
                });

                result.Wait();
            }
        }
    }
}