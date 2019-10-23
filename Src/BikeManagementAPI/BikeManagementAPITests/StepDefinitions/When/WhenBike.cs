using BikeManagementAPITests.Support.Context;
using TechTalk.SpecFlow;

namespace BikeManagementAPITests.StepDefinitions.When
{
    [Binding]
    public class WhenBike
    {
        private readonly UserContext _userContext;

        public WhenBike(UserContext userContext)
        {
            _userContext = userContext;
        }

        [When(@"I register a new bike")]
        public void WhenIRegisterANewBike()
        {
            ScenarioContext.Current.Pending();
        }
    }
}