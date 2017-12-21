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
    [Binding, Scope(Tag = "automated")]
    class ViewListOfProjectAgencySteps
    {
        private readonly ViewListOfProjectAgencyDriver _viewListOfProjectAgencyDriver;
        public ViewListOfProjectAgencySteps(ViewListOfProjectAgencyDriver driver)
        {
            _viewListOfProjectAgencyDriver = driver;
        }
        [Given(@"the following project list")]
        public void GivenTheFollowingProjectList(Table table) => _viewListOfProjectAgencyDriver.InsertProjectToDB(table);

        [Given(@"The project has been approved")]
        public void GivenTheProjectHasBeenApproved()
        {
            _viewListOfProjectAgencyDriver.Showlistapproved();
        }

        [When(@"I at the Sale Page")]
        public void WhenIAtTheSalePage()
        {
            _viewListOfProjectAgencyDriver.saleindex();
        }

        [Then(@"I will see status of project")]
        public void ThenIWillSeeStatusOfProject(Table table)
        {
            _viewListOfProjectAgencyDriver.Showlistapproved();
        }

    }

}
