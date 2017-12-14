using PPCRental.AcceptanceTests.Driver.Filter;
using PPCRental.AcceptanceTests.Driver.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace PPCRental.AcceptanceTests.StepDefinitions
{
    [Binding, Scope(Tag = "automated")]
    class FilterSteps
    {
        private FilterDriver _filterDriver;

        public FilterSteps(FilterDriver driver)
        {
            _filterDriver = driver;
        }

        [Given(@"the following property")]
        public void GivenTheFollowingProperty(Table inputProperty)
        {

        }

        [Given(@"User at the Home page")]
        public void GivenUserAtTheHomePage()
        {
            HomeDriver _homeDriver = new HomeDriver();
            _homeDriver.Navigate();
        }

        [When(@"I search for property by the pharse '(.*)'")]
        public void WhenISearchForPropertyByThePharse(string Property_Name)
        {
            _filterDriver.Filter(Property_Name);
        }


        [Then(@"User should see the list name of project")]
        public void ThenUserShouldSeeTheListNameOfProject(Table ShownProperties)
        {
            _filterDriver.ShouldShowProjects(ShownProperties);
        }


    }
}
