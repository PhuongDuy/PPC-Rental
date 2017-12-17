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
    [Binding]
    class FilterSteps
    {
        private FilterDriver filterDriver;

        public FilterSteps (FilterDriver driver)
        {
            filterDriver = driver;
        }

        [Given(@"the following property")]
        public void GivenTheFollowingProperty(Table table)
        {
            
        }

        [Given(@"I at the Home Page")]
        public void GivenIAtTheHomePage()
        {
            HomeDriver homeDriver = new HomeDriver();
            homeDriver.Navigate();
        }

        [When(@"I search for property by the pharse '(.*)'")]
        public void WhenISearchForPropertyByThePharse(string Property_Name)
        {
            filterDriver.Filter(Property_Name);
        }

        [Then(@"I should see the following information")]
        public void ThenIShouldSeeTheFollowingInformation(Table ShownProperties)
        {
            filterDriver.ShouldShowProjects(ShownProperties);
        }



    }
}
