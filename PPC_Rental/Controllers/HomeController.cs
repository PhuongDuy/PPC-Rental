using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPC_Rental.Models;
using System.IO;

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
        public ActionResult Search(string gia, string quanhuyen, string loaida, string phongtam, string phongngu, string baidauxe)
        {

            IEnumerable<PPC_Rental.Models.PROPERTY> ls;

            if (gia == "Dưới 50000") {
                ls = m.PROPERTies.ToList().Where(x => (x.Price < 50000 && gia != "Giá") || (x.DISTRICT.DistrictName == quanhuyen && quanhuyen != "Quận/Huyện") || (x.PROPERTY_TYPE.CodeType == loaida && loaida != "Loại Dự Án") || (x.BathRoom.ToString() == phongtam && phongtam != "Phòng tắm") || (x.BedRoom.ToString() == phongngu && phongngu != "Phòng ngủ") || (x.PackingPlace.ToString() == baidauxe && baidauxe != "Bãi đậu xe"));
            }
            else if (gia == "Từ 50000-100000")
            {
                ls = m.PROPERTies.ToList().Where(x => (x.Price >= 50000 && x.Price < 100000 && gia != "Giá") || (x.DISTRICT.DistrictName == quanhuyen && quanhuyen != "Quận/Huyện") || (x.PROPERTY_TYPE.CodeType == loaida && loaida != "Loại Dự Án") || (x.BathRoom.ToString() == phongtam && phongtam != "Phòng tắm") || (x.BedRoom.ToString() == phongngu && phongngu != "Phòng ngủ") || (x.PackingPlace.ToString() == baidauxe && baidauxe != "Bãi đậu xe"));
            }
            else if (gia == "Từ 100000-150000") {
                ls = m.PROPERTies.ToList().Where(x => (x.Price >= 100000 && x.Price < 150000 && gia != "Giá") || (x.DISTRICT.DistrictName == quanhuyen && quanhuyen != "Quận/Huyện") || (x.PROPERTY_TYPE.CodeType == loaida && loaida != "Loại Dự Án") || (x.BathRoom.ToString() == phongtam && phongtam != "Phòng tắm") || (x.BedRoom.ToString() == phongngu && phongngu != "Phòng ngủ") || (x.PackingPlace.ToString() == baidauxe && baidauxe != "Bãi đậu xe"));
            }
            else
            {
                ls = m.PROPERTies.ToList().Where(x => (x.Price >= 150000 && gia != "Giá") || (x.DISTRICT.DistrictName == quanhuyen && quanhuyen != "Quận/Huyện") || (x.PROPERTY_TYPE.CodeType == loaida && loaida != "Loại Dự Án") || (x.BathRoom.ToString() == phongtam && phongtam != "Phòng tắm") || (x.BedRoom.ToString() == phongngu && phongngu != "Phòng ngủ") || (x.PackingPlace.ToString() == baidauxe && baidauxe != "Bãi đậu xe"));
            }

            return View(ls);
        }
        
        public ActionResult postProject()
        {
            var model = new PROPERTY();
            return View(model);
        }

        [HttpPost]
        public ActionResult postProject(PROPERTY e, HttpPostedFileBase Avatar, List<string> chk1, List<HttpPostedFileBase> images)
        {

            //Avatar save file on webserver and sign value for model
            if (Avatar != null)
            {
                string avatar = "";
                if (Avatar.ContentLength > 0)
                {
                    var filename = Path.GetFileName(Avatar.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/"), filename);
                    Avatar.SaveAs(path);
                    avatar = filename;
                }
                e.Avatar = avatar;
            }

            //Image save file on webserver and add new PROPERTY_IMAGE into table PROPERTY_IMAGE
            foreach (HttpPostedFileBase img in images)
            {
                if (img != null)
                {
                    if (img.ContentLength > 0)
                    {
                        var filename = Path.GetFileName(img.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images/"), filename);
                        img.SaveAs(path);
                        PROPERTY_IMAGE ppti = new PROPERTY_IMAGE();
                        ppti.Image = filename;
                        ppti.Property_ID = e.ID;
                        m.PROPERTY_IMAGE.Add(ppti);
                    }
                }
                else
                {
                    break;
                }
            }

            //save PROPERTY_FEATURE into PROPERTY_FEATURE table foreach Feature
            foreach (string fe in chk1)
            {
                PROPERTY_FEATURE profe = new PROPERTY_FEATURE();
                profe.Feature_ID = m.FEATUREs.SingleOrDefault(x => x.FeatureName == fe).ID;
                profe.Property_ID = e.ID;
                m.PROPERTY_FEATURE.Add(profe);
            }
            e.Created_at = DateTime.Now;
            e.Create_post = DateTime.Now;
            e.UserID = int.Parse(Session["UserID"].ToString());
            e.Status_ID = 1;

            m.PROPERTies.Add(e);
            m.SaveChanges();


            return RedirectToAction("Index");
        }
        [HttpGet]
        public JsonResult requestStreets(int? District_ID) {
            return Json(
                m.STREETs.Where(x => x.DISTRICT.ID == District_ID).Select(s => new { id = s.ID, text = s.StreetName }).ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult requestWard(int? District_ID)
        {
            return Json(
                m.WARDs.Where(x => x.DISTRICT.ID == District_ID).Select(s => new { id = s.ID, text = s.WardName }).ToList(), JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var user = m.USERs.FirstOrDefault(x => x.Email == email);
            if (user != null)
            {
                if (user.Password.Equals(password))
                {
                    Session["FullName"] = user.FullName;
                    Session["UserID"] = user.ID;
                    if (user.Role == "1")
                    { 
                    return RedirectToAction("Viewlistofproject");
                    }
                    if(user.Role == "2")
                    {
                        return RedirectToAction("Index","Sale");
                    }
                }
            }
            else
            {
                ViewBag.mgs = "tài khoản không tồn tại";
            }
            return View();
        }

        public ActionResult Logout(int id)
        {
            var user = m.USERs.FirstOrDefault(x => x.ID == id);
            if (user != null)
            {
                Session["FullName"] = null;
                Session["UserID"] = null;
            }
            return RedirectToAction("Login");
        }
        
        public ActionResult Viewlistofproject(string status = "Đã duyệt")
        {
            var viewlist = m.PROPERTies.Where(p => p.PROJECT_STATUS.Status_Name == status /*&& p.USER.FullName == Session["FullName"].ToString()*/).ToList();
            return View(viewlist);
        }

        public ActionResult Savedrafts(string status = "Lưu nháp")
        {
            var viewlist = m.PROPERTies.Where(p => p.PROJECT_STATUS.Status_Name == status /*|| p.UserID == int.Parse(Session["UserID"].ToString())*/).ToList();
            return View(viewlist);
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(USER user, string confirmpassword, string email, string password, string fullname, string phone, string address, string role)
        {
                var reg = new USER();
                reg.FullName = user.FullName;
                reg.Email = user.Email;
                reg.Password = user.Password;
                reg.Phone = user.Phone;
                reg.Address = user.Address;
                reg.Role = user.Role;
                m.USERs.Add(reg);
                m.SaveChanges();
         
                return View("Register");
        }

        public ActionResult News()
        {
            var p = m.NEWs.ToList();
            return View(p);
        }
    }
}