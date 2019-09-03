using BikeManagementAPITests.Support.Authentication;
using TechTalk.SpecFlow;

namespace BikeManagementAPITests.StepDefinitions.Given
{
    [Binding]
    public class GivenManageBikes
    {
        [Given(@"I am authorized as an employee that has permission to see bike data")]
        public void GivenIAmAuthorizedAsAnEmployeeThatHasPermissionToSeeBikeData()
        {
            TestAuthenticationHandler.ValidationState = AuthenticationState.Valid;
        }
    }
}