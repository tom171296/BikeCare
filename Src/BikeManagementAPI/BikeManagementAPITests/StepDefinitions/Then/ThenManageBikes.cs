using TechTalk.SpecFlow;

namespace BikeManagementAPITests.StepDefinitions.Then
{
    [Binding]
    public class ThenManageBikes
    {
        [Then(@"all data for bike (.*) should be returned")]
        public void ThenAllDataForBikeShouldBeReturned(int bikeId)
        {
            // assert
        }
    }
}