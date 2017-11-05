namespace WebAPI.Tests.Helpers
{
    using System.Linq;

    using DataLayer;
    using global::Models;
    using Bootstrapper.IdentityConfiguration;

    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class SeedConfiguration
    {
        public SeedConfiguration(string userUsername, string userPassword)
        {
            this.TestUserUsername = userUsername;
            this.TestUserPassword = userPassword;
        }

        public string TestUserUsername { get; set; }

        public string TestUserPassword { get; set; }

        public void Seed()
        {
            var context = new ApplicationDbContext();

            if (!context.Users.Any(u => u.UserName == TestUserUsername))
            {
                SeedUsers(context);
            }
        }

        private void SeedUsers(ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);

            var userManager = new ApplicationUserManager(userStore);

            var user = new ApplicationUser()
            {
                UserName = TestUserUsername,
                Email = TestUserUsername
            };

            var userResult = userManager.CreateAsync(user, TestUserPassword).Result;

            if (userResult.Succeeded == false)
            {
                Assert.Fail(string.Join("\n", userResult.Errors));
            }
        }
    }
}