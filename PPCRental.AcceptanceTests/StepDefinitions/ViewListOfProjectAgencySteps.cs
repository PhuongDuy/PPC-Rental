using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using PPC_Rental.Models;
using PPC_Rental.Controllers;
using PPCRental.AcceptanceTests.Driver.ViewListOfProjectAgency;

namespace PPCRental.AcceptanceTests.StepDefinitions
{
    class ViewListOfProjectAgencySteps
    {
        private readonly ViewListOfProjectAgencyDriver _viewListOfProjectAgencyDriver;
        public ViewListOfProjectAgencySteps(ViewListOfProjectAgencyDriver driver)
        {
            _viewListOfProjectAgencyDriver = driver;
        }

        [Given(@"Saler login system by Sale account")]
        public void GivenSalerLoginSystemBySaleAccount(string email, string password)
        {
            _viewListOfProjectAgencyDriver.Login(email, password);
        }

        [When(@"Saler enter account information")]
        public void WhenSalerEnterAccountInformation(Table givenProjects)
        {
            _viewListOfProjectAgencyDriver.InsertPropertyToDB(givenProjects);
        }

        [When(@"Saler click on Login Button")]
        public void WhenSalerClickOnLoginButton()
        {
            _viewListOfProjectAgencyDriver.OpenPropert();
        }

        [Then(@"Show project list of agency")]
        public void ThenShowProjectListOfAgency(Table shownProject)
        {
            _viewListOfProjectAgencyDriver.Showpropertylist(shownProject);
        }

    }
}
