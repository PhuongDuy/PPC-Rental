using PPC_Rental.Controllers;
using PPCRental.AcceptanceTests.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TechTalk.SpecFlow;

namespace PPCRental.AcceptanceTests.Driver.Filter
{
    public class FilterDriver
    {
        private ActionResult _result;
        private readonly PropertyContext _context;

        public object ProjectAssertion { get; private set; }

        public void Filter(string property_Name)
        {
            using (var controller = new HomeController())
            {
                _result = controller.Search(property_Name, null, null, null, null, null, null);
            }
        }

        public void ShouldShowProjects(Table shownProperties)
        {
            //Arrange
            var expectedProject = shownProperties.Rows.Select(m => m["Property_Name"]);

            //Act
            var actualProject = _result.Model<IEnumerable<PPC_Rental.Models.PROPERTY>>();

            //Assert
            FilterAssertions.HomeScreenShouldShow(shownProperties, expectedProject);
        }

        private class FilterAssertions
        {
            internal static void HomeScreenShouldShow(Table shownProperties, IEnumerable<string> expectedProject)
            {
                
            }
        }
    }
}
