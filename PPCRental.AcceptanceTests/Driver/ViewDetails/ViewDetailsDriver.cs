using FluentAssertions;
using PPC_Rental.Controllers;
using PPC_Rental.Models;
using PPCRental.AcceptanceTests.Support;
using System.Linq;
using System.Web.Mvc;
using TechTalk.SpecFlow;
using System;



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
                    var tPropertyType_ID = item["PropertyType_ID"].ToString();
                    var tStreet_ID = item["Street"].ToString();
                    var tDistrict_ID = item["District"].ToString();
                    var tWard_ID = item["Ward"].ToString();

                    var a = db.PROPERTY_TYPE.FirstOrDefault(d1 => d1.CodeType == tPropertyType_ID);
                    var b = db.STREETs.FirstOrDefault(s => s.StreetName == tStreet_ID);
                    var c = db.DISTRICTs.FirstOrDefault(d2 => d2.DistrictName == tDistrict_ID);
                    var d3 = db.WARDs.FirstOrDefault(d2 => d2.WardName == tWard_ID);

                    PROPERTY project = new PROPERTY()
                    {

                        PropertyName = item["PropertyName"].ToString(),
                        PropertyType_ID = int.Parse(tPropertyType_ID),

                        Street_ID = db.STREETs.FirstOrDefault(s => s.StreetName == tStreet_ID).ID,
                        District_ID = db.DISTRICTs.FirstOrDefault(d => d.DistrictName == tDistrict_ID).ID,
                        Ward_ID = db.WARDs.FirstOrDefault(d => d.WardName == tWard_ID).ID,
                        UnitPrice = item["UnitPrice"].ToString(),
                        Price = int.Parse(item["Price"].ToString()),
                        BathRoom = int.Parse(item["Bathroom"].ToString()),
                        BedRoom = int.Parse(item["Bedroom"].ToString()),
                        PackingPlace = int.Parse(item["PackingPlace"].ToString()),
                        Content = item["Content"].ToString(),
                        Area = "20m2",
                        

                    };
                    //project.STREET = db.STREETs.Find(project.Street_ID);
                    // project.STREET.StreetName
                    //_context.ReferenceDetails.Add(projects.Header.Contains("ID") ? item["ID"] : project.PropertyName, project.PackingPlace, project.Price);
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
        public void OpenPropertyDetails(string detailsID)
        {
            var details = _context.ReferenceDetails.GetById(detailsID);
            using (var controller = new viewDetailController())
            {
                //_result = controller.Index(int.Parse(bookID));
                _result = controller.Index(details.ID);
            }
        }
    }
}
