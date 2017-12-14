using TechTalk.SpecFlow;
using PPCRental.AcceptanceTests.Driver.ViewDetails;

namespace PPCRental.AcceptanceTests.StepDefinitions
{
    [Binding, Scope (Tag ="automated")]
     class ViewDetails
    {
        // private readonly Driver.ViewDetails.ViewDetailsDriver _detailsDriver;
        private readonly ViewDetailsDriver _detailsDriver;
        public ViewDetails(ViewDetailsDriver driver)
        {
            _detailsDriver = driver;
        }

        [Given(@"the following projects")]
        public void GivenTheFollowingProjects(Table givenProjects)
        {
            _detailsDriver.InsertProjectToDB(givenProjects);
        }

        [When(@"I open the details of '(.*)'")]
        public void WhenIOpenTheDetailsOf(string givenPrjName)
        {
            _detailsDriver.OpenPropertyDetails(givenPrjName);
        }

        [Then(@"I should see the following information")]
        public void ThenIShouldSeeTheFollowingInformation(Table shownProject)
        {
            _detailsDriver.ShowDetailProject(shownProject);
        }
    }
}
