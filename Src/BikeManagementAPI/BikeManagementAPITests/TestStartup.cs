using BikeManagementAPI;
using BikeManagementAPITests.Support.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BikeManagementAPITests
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        ///     Override the authentication scheme so the <see cref="TestAuthenticationHandler"/> is used instead of the Auth0 handler.
        /// </summary>
        /// <param name="services"></param>
        protected override void AddAuthentication(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Test scheme"; // Has to match scheme in AuthenticationBuilderExtensions
                options.DefaultChallengeScheme = "Test scheme";
            })
            .AddTestAuth(o => { });
        }
    }
}