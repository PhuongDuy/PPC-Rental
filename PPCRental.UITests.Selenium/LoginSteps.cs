using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace PPCRental.UITests.Selenium
{
    [Binding, Scope(Tag = "web")]
    public class LoginSteps
    {
        [Given(@"I am at Home page")]
        public void GivenIAmAtHomePage()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Navigate to login page")]
        public void GivenNavigateToLoginPage()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I input the following information")]
        public void WhenIInputTheFollowingInformation(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click on Dangnhap Button")]
        public void WhenIClickOnDangnhapButton()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should see successfull message")]
        public void ThenIShouldSeeSuccessfullMessage()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
