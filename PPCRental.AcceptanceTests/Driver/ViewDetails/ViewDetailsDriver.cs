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
       // private const decimal BookDefaultPrice = 10;
        private readonly CatalogContext _context = new CatalogContext();
        private ActionResult _result;

       
        
        public void InsertProjectToDB(Table projects)
        {
            using (var db = new K21T1_Team4Entities1())
            {
                var oStreets = db.STREETs.ToList();

                foreach (var item in projects.Rows)
                {
                    var tPropertyType = item["PropertyType"].ToString();
                    var tStreet_ID = item["Street"].ToString();
                    var tDistrict_ID = item["District"].ToString();
                    var tWard_ID = item["Ward"].ToString();
                    var tPropertyName = item["PropertyName"].ToString();
                    var tUnitPrice = item["UnitPrice"].ToString();
                    var tContent = item["Content"].ToString();

                    var a = db.PROPERTY_TYPE.FirstOrDefault(d1 => d1.CodeType == tPropertyType);
                    var b = db.STREETs.FirstOrDefault(s => s.StreetName == tStreet_ID);
                    var c = db.DISTRICTs.FirstOrDefault(d2 => d2.DistrictName == tDistrict_ID);
                    var d3 = db.WARDs.FirstOrDefault(d2 => d2.WardName == tWard_ID);


                    PROPERTY project = new PROPERTY()
                    {

                        PropertyName = item["PropertyName"].ToString(),
                        PropertyType_ID = a.ID,
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
                    _context.ReferenceDetails.Add(projects.Header.Contains("ID") ? item["ID"] : project.PropertyName,project);
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

            //Assert
            actualProjectDetails.Should().Match<PROPERTY>(
                b => b.PropertyName == expectedProjectDetails["PropertyName"]);
        }

        public void OpenPropertyDetails(string PropertyName)
        {
            var db = new K21T1_Team4Entities1();

            int _Id = db.PROPERTies.FirstOrDefault(r => r.PropertyName == PropertyName).ID;

            using (var controller = new viewDetailController())
            {
                _result = controller.Index(_Id);
            }
        }
    }
}
