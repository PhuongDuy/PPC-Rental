using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPC_Rental.Models;
using PPC_Rental.Controllers;
using System.Web.Mvc;
using FluentAssertions;
using PPCRental.AcceptanceTests.Support;
using TechTalk.SpecFlow;

namespace PPCRental.AcceptanceTests.Driver.ViewListOfProjectAgency
{
    class ViewListOfProjectAgencyDriver
    {
        K21T1_Team4Entities1 db = new K21T1_Team4Entities1();
        //private readonly CatalogContext _context;
        private ActionResult _result;
        public void Login()
        {
            using (var controller = new HomeController())
            {
                _result = controller.Login();
            }
        }

        public void Login(string email, string password)
        {
            using (var controller = new HomeController())
            {
                _result = controller.Login(email, password);
            }
        }

        public void InsertPropertyToDB(Table project)
        {
            using (var db = new K21T1_Team4Entities1())
            {
                foreach (var item in project.Rows)
                {
                    PROPERTY pro = new PROPERTY
                    {
                        PropertyName = item["PropertyName"],
                        PropertyType_ID = db.PROPERTY_TYPE.FirstOrDefault(t => t.CodeType == item["PropertyType"]).ID,
                        District_ID = db.DISTRICTs.FirstOrDefault(d => d.DistrictName == item["District"]).ID,
                        Street_ID = db.STREETs.FirstOrDefault(s => s.StreetName == item["Street"]).ID,
                        Status_ID = db.PROJECT_STATUS.FirstOrDefault(s => s.Status_Name == item["Status"]).ID
                    };
                    db.PROPERTies.Add(pro);
                }
                db.SaveChanges();
            }
        }

        public void Showpropertylist(Table showpropertylist)
        {
            var expectedProject = showpropertylist.Rows.Single();
            var actualProject = _result.Model<PROPERTY>();
            var db = new K21T1_Team4Entities1();

            actualProject.Should().Match<PROPERTY>(
                b => b.PropertyName == expectedProject["PropertyName"]
                && b.PropertyType_ID == db.PROPERTY_TYPE.FirstOrDefault(d => d.CodeType == expectedProject["PropertyType"]).ID
                && b.District_ID == db.DISTRICTs.FirstOrDefault(d => d.DistrictName == expectedProject["District"]).ID
                && b.Street_ID == db.STREETs.FirstOrDefault(s => s.StreetName == expectedProject["Street"]).ID
                && b.Status_ID == db.PROJECT_STATUS.FirstOrDefault(s => s.Status_Name == expectedProject["Status"]).ID
                );
        }
        public void OpenPropert()
        {
            //var book = _context.ReferenceBooks.GetById(propertyId);
            using (var controller = new SaleController())
            {
                _result = controller.Index();
            }
        }

    }
}
