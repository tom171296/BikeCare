using BikeManagementAPITests.Support.Context;
using TechTalk.SpecFlow;

namespace BikeManagementAPITests.StepDefinitions.Given
{
    [Binding]
    public class GivenAuth
    {
        private readonly UserContext _userContext;

        public GivenAuth(UserContext userContext)
        {
            _userContext = userContext;
        }

        [Given(@"i am authenticated as employee '(.*)'")]
        public void GivenIAmAuthenticatedAsEmployee(int employeeNumber)
        {
            _userContext.EmployeeNumber = employeeNumber.ToString();
        }

        [Given(@"employee '(.*)' is authorized to register a new bike\.")]
        public void GivenEmployeeIsAuthorizedToRegisterANewBike_(int employeeNumber)
        {
            _userContext.Authorized = true;
        }
    }
}