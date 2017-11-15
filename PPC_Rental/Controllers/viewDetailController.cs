using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPC_Rental.Models;

namespace PPC_Rental.Controllers
{
    public class viewDetailController : Controller
    {
        // GET: viewDetail
        K21T1_Team4Entities1 m = new K21T1_Team4Entities1();
        public ActionResult Index(int id)
        {
            var p = m.PROPERTies.FirstOrDefault(x=>x.ID==id);
            return View(p);
        }
        public ActionResult Support()
        {
            return View();
        }
    }
}