using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using PPC_Rental.Models;
//using TechTalk.SpecFlow;
using PPCRental.UITests.Selenium.Support;

namespace PPCRental.UITests.Selenium
{
    [Binding, Scope(Tag = "web")]
    public class ViewDetailsSelenium : SeleniumStepsBase
    {


        [Given(@"the following projects")]
        public void GivenTheFollowingProjects()
        {
            Browser.NavigateTo("Home/Index");
        }

        [When(@"I open the details of '(.*)'")]
        public void WhenIOpenTheDetailsOf(string givenPrjName)
        {
            Browser.ClickButton(givenPrjName);
        }

        [Then(@"I should see the following information")]
        public void ThenIShouldSeeTheFollowingInformation(Table shownProject)
        {
            String expectedTitle = shownProject.Rows.Single().ToString();
            string actualTitle = Browser.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div[1]/h3")).Text;
            true.Equals(actualTitle.Contains(expectedTitle));
        }

    }
}
