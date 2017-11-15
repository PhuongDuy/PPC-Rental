using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPC_Rental.Models; 

namespace PPC_Rental.Controllers
{
    public class HomeController : Controller
    {
        K21T1_Team4Entities1 m = new K21T1_Team4Entities1();
        public ActionResult Index()
        {
            var p = m.PROPERTies.ToList();
            return View(p);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public PartialViewResult SearchBox()
        {
            return PartialView(m);
        }

        [HttpPost]
        public ActionResult Search(string gia,string quanhuyen,string loaida,string duong, string phongtam,string phongngu,string baidauxe)
        {
            IEnumerable<PPC_Rental.Models.PROPERTY> ls;

            if (gia == "Dưới 50000") {
                ls = m.PROPERTies.ToList().Where(x => x.Price < 50000 || x.DISTRICT.DistrictName == quanhuyen || x.PROPERTY_TYPE.CodeType == loaida || x.STREET.StreetName == duong || x.BathRoom.ToString() == phongtam || x.BedRoom.ToString() == phongngu);
            }
            else if(gia == "Từ 50000-100000")
            {
                ls = m.PROPERTies.ToList().Where(x => (x.Price >= 50000 && x.Price < 100000) || x.DISTRICT.DistrictName == quanhuyen || x.PROPERTY_TYPE.CodeType == loaida || x.STREET.StreetName == duong || x.BathRoom.ToString() == phongtam || x.BedRoom.ToString() == phongngu);
            }
            else if(gia == "Từ 100000-150000") {
                ls = m.PROPERTies.ToList().Where(x => (x.Price >= 100000 && x.Price < 150000) || x.DISTRICT.DistrictName == quanhuyen || x.PROPERTY_TYPE.CodeType == loaida || x.STREET.StreetName == duong || x.BathRoom.ToString() == phongtam || x.BedRoom.ToString() == phongngu);
            }
            else
            {
                ls = m.PROPERTies.ToList().Where(x => x.Price >= 150000 || x.DISTRICT.DistrictName == quanhuyen || x.PROPERTY_TYPE.CodeType == loaida || x.STREET.StreetName == duong || x.BathRoom.ToString() == phongtam || x.BedRoom.ToString() == phongngu);
            }

            return View(ls);
        }
    }
}