using BikeManagementAPI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BikeManagementAPITests.Support
{
    public class TestStartUp : Startup
    {
        public TestStartUp(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void AddAuth0Authentication(IServiceCollection services)
        {
            base.AddAuth0Authentication(services);
        }
    }
}