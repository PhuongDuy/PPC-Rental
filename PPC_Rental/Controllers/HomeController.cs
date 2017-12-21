using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPC_Rental.Models;
using System.IO;
using System.Net.Mail;
using System.Net;
using PagedList;

namespace PPC_Rental.Controllers
{
    public class HomeController : Controller
    {
        K21T1_Team4Entities1 m = new K21T1_Team4Entities1();
        public ActionResult Index(int? page=1)
        {
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            var properties = m.PROPERTies.ToList();
            return View(properties.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult About()
        {
            var p = m.ABOUTs.ToList();
            return View(p);
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(string nameUser,string emailUser,string subject , string message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var senderemail = new MailAddress("ppcrentalteam04@gmail.com", "Hỗ trợ");//mail agency
                    var receiveremail = new MailAddress("k21t1ppcrental@gmail.com", "Công ty PPC Rental"); //mail công ty

                    var password = "K21t1team04";// mật khẩu địa chỉ mail   
                    var sub =subject;
                    var body ="Tên: "+ nameUser + " Email: "+emailUser +" Tiêu đề: "+subject + " Nội dung: " + message;
                    // nội dung tin nhắn


                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderemail.Address, password)

                    };

                    using (var mess = new MailMessage(senderemail, receiveremail)
                    {
                        Subject = subject,
                        Body = body
                    }
                    )
                    {
                        smtp.Send(mess);
                    }
                    return RedirectToAction("Index", "home");
                }
            }
            catch (Exception)
            {
                ViewBag.Error= "There are some problem in sending email";
            }
            return View();
        }

        public PartialViewResult SearchBox()
        {
            return PartialView(m);
        }

        [HttpPost]
        public ActionResult Search(string searchtxt, string gia, string quanhuyen, string loaida, string phongtam, string phongngu, string baidauxe)
        {

            IEnumerable<PPC_Rental.Models.PROPERTY> ls;

            //if (searchtxt == "")
            //{
            //    if (gia == "Dưới 50.000")
            //    {
            //        ls = m.PROPERTies.Where(x => (x.Price < 50000 && gia != "Giá") && (x.DISTRICT.DistrictName == quanhuyen && quanhuyen != "Quận/Huyện") && (x.PROPERTY_TYPE.CodeType == loaida && loaida != "Loại Dự Án") && (x.BathRoom.ToString() == phongtam && phongtam != "Phòng tắm") && (x.BedRoom.ToString() == phongngu && phongngu != "Phòng ngủ") && (x.PackingPlace.ToString() == baidauxe && baidauxe != "Bãi đậu xe")).ToList();
            //    }
            //    else if (gia == "Từ 50.000-100.000")
            //    {
            //        ls = m.PROPERTies.Where(x => (x.Price >= 50000 && x.Price < 100000) && (x.DISTRICT.DistrictName == quanhuyen && quanhuyen != "Quận/Huyện") && (x.PROPERTY_TYPE.CodeType == loaida && loaida != "Loại Dự Án") && (x.BathRoom.ToString() == phongtam && phongtam != "Phòng tắm") && (x.BedRoom.ToString() == phongngu && phongngu != "Phòng ngủ") && (x.PackingPlace.ToString() == baidauxe && baidauxe != "Bãi đậu xe")).ToList();
            //    }
            //    else if (gia == "Từ 100.000-150.000")
            //    {
            //        ls = m.PROPERTies.Where(x => (x.Price >= 100000 && x.Price < 150000) && (x.DISTRICT.DistrictName == quanhuyen && quanhuyen != "Quận/Huyện") && (x.PROPERTY_TYPE.CodeType == loaida && loaida != "Loại Dự Án") && (x.BathRoom.ToString() == phongtam && phongtam != "Phòng tắm") && (x.BedRoom.ToString() == phongngu && phongngu != "Phòng ngủ") && (x.PackingPlace.ToString() == baidauxe && baidauxe != "Bãi đậu xe")).ToList();
            //    }
            //    else
            //    {
            //        ls = m.PROPERTies.Where(x => (x.Price >= 150000 && gia != "Giá") && (x.DISTRICT.DistrictName == quanhuyen && quanhuyen != "Quận/Huyện") && (x.PROPERTY_TYPE.CodeType == loaida && loaida != "Loại Dự Án") && (x.BathRoom.ToString() == phongtam && phongtam != "Phòng tắm") && (x.BedRoom.ToString() == phongngu && phongngu != "Phòng ngủ") && (x.PackingPlace.ToString() == baidauxe && baidauxe != "Bãi đậu xe")).ToList();
            //    }
            //}
            //else {
            //    ls = m.PROPERTies.Where(x => x.PropertyName.Trim().ToLower().Contains(searchtxt.Trim().ToLower()));
            //}


            #region
            var dicGia = new Dictionary<string, string> { { "Dưới 50.000", "0#50000" }, { "Từ 50.000-100.000", "50000#100000" }, { "Từ 100.000 - 150.000", "100000#150000" }, { "Trên 150.000", "150000#999999999" } };
            if (searchtxt == "")
            {
                if (gia != "Giá")
                {
                    int first = int.Parse(dicGia[gia].Split('#')[0]);
                    int second = int.Parse(dicGia[gia].Split('#')[1]);
                    ls = m.PROPERTies.Where(x => x.Price >= first && x.Price <= second);
                }
                else
                    ls = m.PROPERTies;
                if (quanhuyen != "Quận/Huyện")
                    ls = ls.Where(x => x.DISTRICT.DistrictName == quanhuyen);
                if (loaida != "Loại Dự Án")
                    ls = ls.Where(x => x.PROPERTY_TYPE.CodeType == loaida);
                if (phongtam != "Phòng tắm")
                    ls = ls.Where(x => x.BathRoom.ToString() == phongtam);
                if (phongngu != "Phòng ngủ")
                    ls = ls.Where(x => x.BedRoom.ToString() == phongngu);
                if (baidauxe != "Bãi đậu xe")
                    ls = ls.Where(x => x.PackingPlace.ToString() == baidauxe);
                ls = ls.ToList();
            }
            else
            {
                ls = m.PROPERTies.Where(x => x.PropertyName.Trim().ToLower().Contains(searchtxt.Trim().ToLower()));
            }
            #endregion
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
            

            if(Session["UserID"] == null)
            {
                return View("Login");
            }
            if(Avatar == null && !Avatar.ContentType.Contains("image"))
            {
                ModelState.AddModelError("Avatar", "chưa có Avatar");
            }
            //Avatar save file on webserver and sign value for model
            if(e.Content==null&&e.PropertyName==null&&e.Area==null&&e.Price==0&&Avatar==null)
            {
                return View();
            }
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
            if (chk1 !=null)
            {
                foreach (string fe in chk1)
                {
                    PROPERTY_FEATURE profe = new PROPERTY_FEATURE();
                    profe.Feature_ID = m.FEATUREs.SingleOrDefault(x => x.FeatureName == fe).ID;
                    profe.Property_ID = e.ID;
                    m.PROPERTY_FEATURE.Add(profe);
                }
            }
            e.Created_at = DateTime.Now;
            e.Create_post = DateTime.Now;
            e.UserID = int.Parse(Session["UserID"].ToString());
            e.Status_ID = 1;

            m.PROPERTies.Add(e);
            m.SaveChanges();


            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult saveDraftPost(PROPERTY e, HttpPostedFileBase Avatar, List<string> chk1, List<HttpPostedFileBase> images)
        {

            if (Session["UserID"] == null)
            {
                return View("Login");
            }
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
            if (chk1 != null)
            {
                foreach (string fe in chk1)
                {
                    PROPERTY_FEATURE profe = new PROPERTY_FEATURE();
                    profe.Feature_ID = m.FEATUREs.SingleOrDefault(x => x.FeatureName == fe).ID;
                    profe.Property_ID = e.ID;
                    m.PROPERTY_FEATURE.Add(profe);
                }
            }
            e.Created_at = DateTime.Now;
            e.Create_post = DateTime.Now;
            e.UserID = int.Parse(Session["UserID"].ToString());
            e.Status_ID = 2;
            if(e.PropertyName == null)
            {
                e.PropertyName = "NULL";
            }
            if(e.Content == null)
            {
                e.Content = "NULL";
            }
            if (e.Price == null)
            {
                e.Price = 0;
            }
            if(e.Area == null)
            {
                e.Area = "NULL";
            }

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
            var viewlist = m.PROPERTies.Where(p => p.PROJECT_STATUS.Status_Name == status).ToList();
            return View(viewlist);
        }

        public ActionResult Savedrafts(string status = "Lưu nháp")
        {
            var viewlist = m.PROPERTies.Where(p => p.PROJECT_STATUS.Status_Name == status).ToList();
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

        public ActionResult Newdetail(int id)
        {
            var p = m.NEWs.ToList().Where(x => x.ID == id);
            return View(p);
        }
    }
}
