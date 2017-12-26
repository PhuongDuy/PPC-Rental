using PPCRental.UITests.Selenium.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace PPCRental.UITests.Selenium
{
    [Binding, Scope(Tag = "web")]
    class FilterSelenium : SeleniumStepsBase
    {
        [Given(@"the following property")]
        public void GivenTheFollowingProperty(Table table)
        {

        }

        [Given(@"I at the Home Page")]
        public void GivenIAtTheHomePage()
        {
            Browser.NavigateTo("Home/Index");
        }

        [When(@"I search for property by the pharse '(.*)'")]
        public void WhenISearchForPropertyByThePharse(string Property_Name)
        {
            
        }

        [Then(@"I should see the following information")]
        public void ThenIShouldSeeTheFollowingInformation(Table ShownProperties)
        {
            
        }
    }
}
