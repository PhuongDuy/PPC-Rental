using System;
using TechTalk.SpecFlow;
using PPC_Rental;
using PPCRental.AcceptanceTests.Driver.Home;
using PPCRental.AcceptanceTests.Driver.Login;
using PPCRental.UITests.Selenium.Support;

namespace PPCRental.AcceptanceTests.StepDefinitions
{
    [Binding, Scope(Tag = "automated")]
    public class LoginSteps
    {
        private readonly LoginDriver _loginDriver;
        string _username;
        string _password;
        [Given(@"I am at Home page")]
        public void GivenIAmAtHomePage()
        {
            HomeDriver _homeDriver = new HomeDriver();
            _homeDriver.Navigate();
        }

        [Given(@"Navigate to login page")]
        public void GivenNavigateToLoginPage()
        {
            _loginDriver.Navigate();
        }

        [When(@"I input the following information")]
        public void WhenIInputTheFollowingInformation(Table user)
        {
            var dictionary = TableExtensions.ToDictionary(user);
            _username = dictionary["Email"].ToString();
            _password = dictionary["Password"].ToString();
        }

        [When(@"I click on Dangnhap Button")]
        public void WhenIClickOnDangnhapButton()
        {
            _loginDriver.Login(_username, _password);
        }

        [Then(@"I should see successfull message")]
        public void ThenIShouldSeeSuccessfullMessage()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
