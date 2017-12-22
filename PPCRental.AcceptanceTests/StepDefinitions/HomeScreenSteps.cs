using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using PPC_Rental.Models;
using PPC_Rental.Controllers;
using PPCRental.AcceptanceTests.Driver.Home;

namespace PPCRental.AcceptanceTests.StepDefinitions
{
    class HomeScreenSteps
    {
        private readonly HomeDriver _HomeScreen;
        public HomeScreenSteps(HomeDriver driver)
        {
            _HomeScreen = driver;
        }
        [Given(@"show the new project")]
        public void GivenShowTheNewProject(Table table)
        {
            
        }

        [Given(@"show the hot project")]
        public void GivenShowTheHotProject(Table table)
        {
           
        }

        [When(@"User enter the main page")]
        public void WhenUserEnterTheMainPage()
        {
            _HomeScreen.Navigate();
        }

        [Then(@"the home screen should show the interface of the website")]
        public void ThenTheHomeScreenShouldShowTheInterfaceOfTheWebsite(Table table)
        {
            _HomeScreen.Navigate();
        }

    }
}
