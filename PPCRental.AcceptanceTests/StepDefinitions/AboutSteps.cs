using PPCRental.AcceptanceTests.Driver.About;
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
    class AboutSteps
    {
        private AboutDriver aboutDriver;

        public AboutSteps(AboutDriver driver)
        {
            aboutDriver = driver;
        }

        [Given(@"User at a Home Page")]
        public void GivenUserAtAHomePage()
        {
            HomeDriver homeDriver = new HomeDriver();
            homeDriver.Navigate();
        }

        [When(@"User click for about by the pharse '(.*)'")]
        public void WhenUserClickForAboutByThePharse(string p0)
        {
            
        }

        [Then(@"User should see the following information")]
        public void ThenUserShouldSeeTheFollowingInformation(Table showAbout)
        {
            aboutDriver.ShouldShowAbout(showAbout);
        }

    }
}
