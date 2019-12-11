using BikeManagementAPITests.Support.Context;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BikeManagementAPITests.StepDefinitions.When
{
    [Binding]
    public class WhenBike
    {
        private readonly UserContext userContext;

        public WhenBike(UserContext userContext)
        {
            this.userContext = userContext;
        }

        [When(@"I register a new bike")]
        public async Task WhenIRegisterANewBike()
        {
            // Make call to localhost
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri("http://localhost:80/api/bike")
            };

            using (HttpClient client = new HttpClient())
            {
                var response = await client.SendAsync(request);
            }
        }
    }
}