using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using PPCRental.AcceptanceTests.Support;
using System.Web.Mvc;
using PPC_Rental.Models;
using PPC_Rental.Controllers;
using TechTalk.SpecFlow;
using BookShop.AcceptanceTests.Support;

namespace PPCRental.AcceptanceTests.Driver.ViewDetails
{
    class ViewDetailsDriver
    {
        private const decimal BookDefaultPrice = 10;
        private readonly CatalogContext _context;
        private ActionResult _result;

        public void InsertProjectToDB(Table projects)
        {
            using (var db = new K21T1_Team4Entities1())
            {
                var oStreets = db.STREETs.ToList();

                foreach (var item in projects.Rows)
                {
                    PROPERTY project = new PROPERTY
                    {
                        PropertyName = item["PropertyName"],
                        UnitPrice = item["UnitPrice"],
                        Price = int.Parse(item["Price"]),
                        Street_ID = db.STREETs.FirstOrDefault(s => s.StreetName == item["Street"]).ID,
                        District_ID = db.DISTRICTs.FirstOrDefault(d => d.DistrictName == item["District"]).ID,
                        Ward_ID = db.WARDs.FirstOrDefault(d => d.WardName == item["Ward"]).ID,
                        BathRoom = int.Parse(item["Bathroom"]),
                        BedRoom = int.Parse(item["Bedroom"]),
                        PackingPlace = int.Parse(item["PackingPlace"]), 
                        Content = item["Content"]
               
                    };
                    //project.STREET = db.STREETs.Find(project.Street_ID);
                    // project.STREET.StreetName
                    db.PROPERTies.Add(project);
                }
                db.SaveChanges();
                
            }
        }
        public void ShowDetailProject(Table ShowDetailProject)
        {
            //Arrange
            var expectedBookDetails = ShowDetailProject.Rows.Single();

            //Act
            var actualBookDetails = _result.Model<PROPERTY>();

            //Assert
            actualBookDetails.Should().Match<PROPERTY>(
                b => b.PropertyName == expectedBookDetails["PropertyName"]
                && b.UnitPrice == expectedBookDetails["UnitPrice"]
                && b.Content == expectedBookDetails["Content"]
                && b.Ward_ID == decimal.Parse(expectedBookDetails["Ward"])
                && b.Street_ID == decimal.Parse(expectedBookDetails["Street"])
                && b.District_ID == decimal.Parse(expectedBookDetails["Dicstrict"])
                && b.BathRoom == decimal.Parse(expectedBookDetails["BathRoom"])
                && b.BedRoom == decimal.Parse(expectedBookDetails["BedRoom"])
                && b.PackingPlace == decimal.Parse(expectedBookDetails["PackingPlace"])
                && b.Price == decimal.Parse(expectedBookDetails["Price"]));
        }
        public void OpenPropertyDetails(string propertyId)
        {
            var book = _context.ReferenceBooks.GetById(propertyId);
            using (var controller = new viewDetailController())
            {
                _result = controller.Index(book.ID);
            }
        }
    }
}
