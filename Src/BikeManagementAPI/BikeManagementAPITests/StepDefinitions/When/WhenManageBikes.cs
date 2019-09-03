using TechTalk.SpecFlow;

namespace BikeManagementAPITests.StepDefinitions.When
{
    [Binding]
    public class WhenManageBikes
    {
        [When(@"I ask for bike (.*)")]
        public void WhenIAskForBike(int bikeId)
        {
            //act
        }
    }
}