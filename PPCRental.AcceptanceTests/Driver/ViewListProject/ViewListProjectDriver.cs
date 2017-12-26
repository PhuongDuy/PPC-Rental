using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPC_Rental.Controllers;
using System.Web.Mvc;
using TechTalk.SpecFlow;
using PPCRental.AcceptanceTests.Support;
using PPC_Rental.Models;
using PPCRental.AcceptanceTests.Common;
using FluentAssertions;

namespace WebPPC.AcceptanceTests.Drivers.Property
{
    public class PropertyDrivers
    {
        K21T1_Team4Entities1 db = new K21T1_Team4Entities1();
        private ActionResult _result;

        public void NavigateToHome()
        {
            using (var controller = new HomeController())
            {
                _result = controller.Login();
            }
        }

        public void ShowProject(IEnumerable<string> expectedTitles)
        {
            //Act
            var shownProject = _result.Model<IEnumerable<PROPERTY>>();
            //Assert
            ProjectAssertions.HomeScreenShouldShow(shownProject, expectedTitles);
        }

        public void NavigategoToHome()
        {
            using (var controller = new HomeController())
            {
                _result = controller.Index();
            }
        }

        public void ShowListOfAgencyProject(Table showProject)
        {
            //Arrange
            var expectedProjects = showProject.Rows.Select(r => r["PropertyName"]);
            //Actual
            var actualProjects = _result.Model<IEnumerable<PROPERTY>>();
            //Assert
            ProjectAssertions.HomeScreenShouldShow(actualProjects, expectedProjects);
        }

  

        public void NavigateHome()
        {
            using (var controller = new HomeController())
            {
                _result = controller.Index();
            }
        }

        public void FilterByPrice(string price)
        {
            using (var controller = new HomeController())
            {
               // _result = controller.Search(price, null, null, null, null, null);
            }
        }

        public void ShowListProjectByPrice(Table showProject)
        {
            //Arrange
            var expectedProjects = showProject.Rows.Select(r => r["Price"]);
            //Actual
            var actualProjects = _result.Model<IEnumerable<PROPERTY>>();
            //Assert
            ProjectAssertions.HomeScreenShouldShow(actualProjects, expectedProjects);
        }

        public void NavigateToSearch()
        {
            using (var controller = new HomeController())
            {
               // _result = controller.SearchI();
            }
        }

        public void ClickDetail(string propertyName)
        {
            var db = new K21T1_Team4Entities1();

            int id = db.PROPERTies.FirstOrDefault(r => r.PropertyName == propertyName).ID;

            using (var controller = new HomeController())
            {
                _result = controller.Viewlistofproject();
            }
        }

        public void Property(Table project)
        {
            PROPERTY p = new PROPERTY();
            p.PropertyName = project.Rows[0]["PropertyName"];
            p.Content = project.Rows[0]["Content"];
            p.Price = int.Parse(project.Rows[0]["Price"]);
            p.Area = project.Rows[0]["Area"];
            p.BedRoom = int.Parse(project.Rows[0]["BedRoom"]);
            p.PackingPlace = int.Parse(project.Rows[0]["PackingPlace"]);
            p.Status_ID = db.PROJECT_STATUS.ToList().FirstOrDefault(s => s.Status_Name == project.Rows[0]["Status_Name"]).ID;
            db.PROPERTies.Add(p);
            db.SaveChanges();
            var propertyID = db.PROPERTies.ToList().FirstOrDefault(u => u.PropertyName == project.Rows[0]["PropertyName"]).ID;
        }

        public void ShowListProject(Table showProject)
        {
            //Arrange
            var expectedProjects = showProject.Rows.Select(r => r["PropertyName"]);
            //Actual
            var actualProjects = _result.Model<IEnumerable<PROPERTY>>();
            //Assert
            ProjectAssertions.HomeScreenShouldShow(actualProjects, expectedProjects);
        }

        public void ShowListOfProject(Table showProject)
        {
            //Arrange
            var expectedProjects = showProject.Rows.Select(r => r["PropertyName"]);
            //Actual
            var actualProjects = ScenarioContext.Current.Get<IEnumerable<PROPERTY>>("agencyProperty");
            //var actualProjects = result;

            //Assert
            ProjectAssertions.HomeScreenShouldShow(actualProjects, expectedProjects);
        }

        public void ShowDetail(Table expectedDetail)
        {
            //ShowProject(expectedProjet.Rows.Select(r => r["Title"]));
            //Arrange
            var expectedDetails = expectedDetail.Rows.Single();

            //Actual
            var actualProjectDetails = _result.Model<PROPERTY>();

            //Assert
            actualProjectDetails.Should().Match<PROPERTY>(
                b => b.PropertyName == expectedDetails["PropertyName"]);
        }
    }
}
