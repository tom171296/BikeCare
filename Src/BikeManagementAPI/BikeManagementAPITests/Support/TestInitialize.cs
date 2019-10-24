using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using TechTalk.SpecFlow;

namespace BikeManagementAPITests.Support
{
    [Binding]
    public class TestInitialize
    {
        private static TestServer _sut;

        [BeforeTestRun]
        public static void StartUp()
        {
            var builder = new WebHostBuilder()
                .UseContentRoot(AppContext.BaseDirectory)
                .UseStartup<TestStartUp>()
                .UseConfiguration(new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build());

            _sut = new TestServer(builder);
        }
    }
}