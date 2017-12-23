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
        private readonly CatalogContext _context = new CatalogContext();
        private ActionResult _result;

        public void Showlistapproved()
        {
            var db = new K21T1_Team4Entities1();
            var viewlist = db.PROPERTies.OrderByDescending(m => m.Create_post).Where(p => p.PROJECT_STATUS.Status_Name == "Đã duyệt" || p.PROJECT_STATUS.Status_Name == "Hết hạn").ToList();
            using (var controller = new SaleController())
            {
                _result = controller.Index();
            }
        }
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
                    var tPropertyName = item["PropertyName"].ToString();

                    var a = db.PROPERTY_TYPE.FirstOrDefault(d1 => d1.CodeType == tPropertyType);
                    var b = db.STREETs.FirstOrDefault(s => s.StreetName == tStreet_ID);
                    var c = db.DISTRICTs.FirstOrDefault(d2 => d2.DistrictName == tDistrict_ID);


                    PROPERTY project = new PROPERTY()
                    {

                        PropertyName = item["PropertyName"].ToString(),
                        PropertyType_ID = a.ID,
                        Street_ID = db.STREETs.FirstOrDefault(s => s.StreetName == tStreet_ID).ID,
                        District_ID = db.DISTRICTs.FirstOrDefault(d => d.DistrictName == tDistrict_ID).ID

                    };
                    _context.ReferenceDetails.Add(projects.Header.Contains("ID") ? item["ID"] : project.PropertyName, project);
                    db.PROPERTies.Add(project);
                }
            }
        }

        public void saleindex()
        {
            using (var controller = new SaleController())
            {
                _result = controller.Index();
            }
        }


    }
}
