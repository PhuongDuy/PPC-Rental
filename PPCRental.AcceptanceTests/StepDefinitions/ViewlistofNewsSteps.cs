using PPCRental.AcceptanceTests.Driver.Home;
using PPCRental.AcceptanceTests.Driver.ViewlistofNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace PPCRental.AcceptanceTests.StepDefinitions
{
    [Binding]
    class ViewlistofNewsSteps
    {
        private ViewlistofNewsDriver viewlistofNewsDriver;

        public ViewlistofNewsSteps(ViewlistofNewsDriver driver)
        {
            viewlistofNewsDriver = driver;
        }

        [Given(@"user at the Home Page")]
        public void GivenUserAtTheHomePage()
        {
            HomeDriver homeDriver = new HomeDriver();
            homeDriver.Navigate();
        }

        [When(@"user click for new by the pharse '(.*)'")]
        public void WhenUserClickForNewByThePharse(string p0)
        {
           
        }

        [Then(@"user should see the following information")]
        public void ThenUserShouldSeeTheFollowingInformation(Table shownews)
        {
            viewlistofNewsDriver.ShouldShowNews(shownews);
        }

    }
}
