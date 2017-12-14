using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using PPC_Rental.Controllers;
using TechTalk.SpecFlow;

namespace PPCRental.AcceptanceTests.Driver.Login
{
    class LoginDriver
    {
        
        [Given(@"I am at home page")]
        public void GivenIAmAtHomePage()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Navigate to Login page")]
        public void GivenNavigateToLoginPage()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I input the following information")]
        public void WhenIInputTheFollowingInformation(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click on Login Button")]
        public void WhenIClickOnLoginButton()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should see sucessfull message")]
        public void ThenIShouldSeeSucessfullMessage()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
