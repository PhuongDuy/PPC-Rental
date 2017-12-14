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
                        PropertyName = item["PropertyName"].ToString(),
                        PropertyType_ID = db.PROPERTY_TYPE.FirstOrDefault(d=>d.CodeType == item["PropertyType_ID"].ToString()).ID,
                        UnitPrice = item["UnitPrice"].ToString(),
                        Price = int.Parse(item["Price"].ToString()),
                        Street_ID = db.STREETs.FirstOrDefault(s => s.StreetName == item["Street"].ToString()).ID,
                        District_ID = db.DISTRICTs.FirstOrDefault(d => d.DistrictName == item["District"].ToString()).ID,
                        Ward_ID = db.WARDs.FirstOrDefault(d => d.WardName == item["Ward"].ToString()).ID,
                        BathRoom = int.Parse(item["Bathroom"].ToString()),
                        BedRoom = int.Parse(item["Bedroom"].ToString()),
                        PackingPlace = int.Parse(item["PackingPlace"].ToString()), 
                        Content = item["Content"].ToString()
                    
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
            var expectedProjectDetails = ShowDetailProject.Rows.Single();

            //Act
            var actualProjectDetails = _result.Model<PROPERTY>();
            var db = new K21T1_Team4Entities1();

            //Assert
            actualProjectDetails.Should().Match<PROPERTY>(
             
                b => b.PropertyName == expectedProjectDetails["PropertyName"]
                && b.PropertyType_ID == db.PROPERTY_TYPE.FirstOrDefault(d=>d.CodeType == expectedProjectDetails["PropertyType"]).ID
                && b.UnitPrice == expectedProjectDetails["UnitPrice"]
                && b.Content == expectedProjectDetails["Content"]
                && b.Street_ID == db.STREETs.FirstOrDefault(s => s.StreetName == expectedProjectDetails["Street"]).ID
                && b.District_ID == db.DISTRICTs.FirstOrDefault(d => d.DistrictName == expectedProjectDetails["District"]).ID
                && b.Ward_ID == db.WARDs.FirstOrDefault(d => d.WardName == expectedProjectDetails["Ward"]).ID
                && b.BathRoom == int.Parse(expectedProjectDetails["BathRoom"])
                && b.BedRoom == int.Parse(expectedProjectDetails["BedRoom"])
                && b.PackingPlace == int.Parse(expectedProjectDetails["PackingPlace"])
                && b.Price == int.Parse(expectedProjectDetails["Price"]));
            
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
