namespace WebAPI
{
    using Owin;
    using Bootstrapper.IdentityConfiguration;

    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            OwinConfiguration.ConfigureAuth(app);
        }
    }
}