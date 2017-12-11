using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace PPCRental.AcceptanceTests.StepDefinitions
{
    class RegisterNewUserSteps
    {
        

        [Given(@"Navigate to register page")]
        public void GivenNavigateToRegisterPage()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I input the following information")]
        public void WhenIInputTheFollowingInformation(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        

        [Then(@"I should see successful message")]
        public void ThenIShouldSeeSuccessfulMessage()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
