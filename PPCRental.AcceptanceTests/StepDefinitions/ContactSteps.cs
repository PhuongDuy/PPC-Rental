using PPCRental.AcceptanceTests.Driver.Contact;
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
    class ContactSteps
    {
        private ContactDriver contactDriver;

        public ContactSteps(ContactDriver driver)
        {
            contactDriver = driver;
        }

        [Given(@"i at the Home Page")]
        public void GivenIAtTheHomePage()
        {
            HomeDriver homeDriver = new HomeDriver();
            homeDriver.Navigate();
        }

        [When(@"i click for contact by the pharse '(.*)'")]
        public void WhenIClickForContactByThePharse(string p0)
        {
            
        }

        [When(@"i enter information")]
        public void WhenIEnterInformation(Table entercontact)
        {
            contactDriver.EnterInformationContact(entercontact);
        }

        [Then(@"i click to sent contact")]
        public void ThenIClickToSentContact()
        {
            
        }

    }
}
