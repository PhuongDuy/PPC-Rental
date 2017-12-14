using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPC_Rental.Models;
using System.IO;

namespace PPC_Rental.Controllers
{
    //[Authorize]
    public class SaleController : Controller
    {
        K21T1_Team4Entities1 db = new K21T1_Team4Entities1();
        // GET: Sale
        public ActionResult Index()
        {
            var viewlist = db.PROPERTies.OrderByDescending(m => m.Create_post).Where(p => p.PROJECT_STATUS.Status_Name == "Đã duyệt" || p.PROJECT_STATUS.Status_Name == "Hết hạn").ToList();
            return View(viewlist.OrderByDescending(m => m.Create_post).ToList());
        }

        public ActionResult Delete(PROPERTY model)
        {
            PROPERTY pro = db.PROPERTies.Find(model.ID);
            var ftpr = db.PROPERTY_FEATURE.Where(x => x.Property_ID == model.ID).ToList();
            var image = db.PROPERTY_IMAGE.Where(x => x.Property_ID == model.ID).ToList();
            db.PROPERTY_IMAGE.RemoveRange(image);
            db.PROPERTY_FEATURE.RemoveRange(ftpr);
            db.PROPERTies.Remove(pro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete1(PROPERTY model)
        {
            PROPERTY pro = db.PROPERTies.Find(model.ID);
            var ftpr = db.PROPERTY_FEATURE.Where(x => x.Property_ID == model.ID).ToList();
            var image = db.PROPERTY_IMAGE.Where(x => x.Property_ID == model.ID).ToList();
            db.PROPERTY_IMAGE.RemoveRange(image);
            db.PROPERTY_FEATURE.RemoveRange(ftpr);
            db.PROPERTies.Remove(pro);
            db.SaveChanges();
            return RedirectToAction("duyetduan");
        }
        public ActionResult Delete2(NEW model)
        {
            NEW pro = db.NEWs.Find(model.ID);
            db.NEWs.Remove(pro);
            db.SaveChanges();
            return RedirectToAction("News");
        }

        public ActionResult EditProject1(int? id)
        {

            PROPERTY editproject = db.PROPERTies.Find(id);
            if (editproject == null)
            {
                return HttpNotFound();
            }
            ViewBag.editprotype = db.PROPERTY_TYPE.OrderByDescending(x => x.ID).ToList();
            ViewBag.streeid = db.STREETs.OrderByDescending(x => x.ID).ToList();
            ViewBag.disid = db.DISTRICTs.OrderByDescending(x => x.ID).ToList();
            ViewBag.wardid = db.WARDs.OrderByDescending(x => x.ID).ToList();
            ViewBag.staid = db.PROJECT_STATUS.OrderByDescending(x => x.ID).Where(p => p.Status_Name == "Đã duyệt" || p.Status_Name == "Hết hạn").ToList();
            return View(editproject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProject1( PROPERTY model, HttpPostedFileBase Avatar, List<string> chk1, List<HttpPostedFileBase> images)
        {
            
            PROPERTY pro = db.PROPERTies.Find(model.ID);
            var ftpr = db.PROPERTY_FEATURE.Where(x => x.Property_ID == model.ID).ToList();
            var imag = db.PROPERTY_IMAGE.Where(x => x.Property_ID == model.ID).ToList();
            db.PROPERTY_FEATURE.RemoveRange(ftpr);
            db.PROPERTY_IMAGE.RemoveRange(imag);            
            
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
                pro.Avatar = avatar;
            }
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
                        ppti.Property_ID = model.ID;
                        db.PROPERTY_IMAGE.Add(ppti);
                    }
                }
                else
                {
                    break;
                }
            }
                foreach (var fe in chk1)
                {
                    PROPERTY_FEATURE profe = new PROPERTY_FEATURE();
                    profe.Feature_ID = db.FEATUREs.SingleOrDefault(x => x.FeatureName == fe).ID;
                    profe.Property_ID = pro.ID;
                    db.PROPERTY_FEATURE.Add(profe);
                }

                pro.PropertyName = model.PropertyName;
                pro.Images = model.Images;
                pro.PropertyType_ID = model.PropertyType_ID;
                pro.Content = model.Content;
                pro.Street_ID = model.Street_ID;
                pro.Ward_ID = model.Ward_ID;
                pro.District_ID = model.District_ID;
                pro.Price = model.Price;
                pro.UnitPrice = model.UnitPrice;
                pro.Area = model.Area;
                pro.BedRoom = model.BedRoom;
                pro.BathRoom = model.BathRoom;
                pro.PackingPlace = model.PackingPlace;
                pro.Status_ID = model.Status_ID;
                pro.Note = model.Note;
                pro.Updated_at = DateTime.Now;
                pro.Sale_ID = int.Parse(Session["UserID"].ToString());

                db.Entry(pro).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
        }

        public ActionResult DetailProject(int id)
        {
            var editproject = db.PROPERTies.FirstOrDefault(x => x.ID == id);
            return View(editproject);
        }

        [HttpGet]
        public ActionResult AddProject()
        {
            var model = new PROPERTY();
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddProject(PROPERTY model, HttpPostedFileBase Avatar, List<string> chk1, List<HttpPostedFileBase> images)
        {
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
                model.Avatar = avatar;
            }

            foreach (var fe in chk1)
            {
                PROPERTY_FEATURE profe = new PROPERTY_FEATURE();
                profe.Feature_ID = db.FEATUREs.SingleOrDefault(x => x.FeatureName == fe).ID;
                profe.Property_ID = model.ID;
                db.PROPERTY_FEATURE.Add(profe);
            }
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
                        ppti.Property_ID = model.ID;
                        db.PROPERTY_IMAGE.Add(ppti);
                    }
                }
                else
                {
                    break;
                }
            }

            model.Created_at = DateTime.Now;
            model.Create_post = DateTime.Now;
            
            model.UserID = int.Parse(Session["UserID"].ToString());
            model.Status_ID = 1;
            db.PROPERTies.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult GetStreet(int? District_id)
        {
            return Json(
            db.STREETs.Where(x => x.DISTRICT.ID == District_id)
            .Select(s => new { id = s.ID, text = s.StreetName }).ToList(),
            JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetWard(int? District_id)
        {
            return Json(
            db.WARDs.Where(x => x.DISTRICT.ID == District_id)
            .Select(s => new { id = s.ID, text = s.WardName }).ToList(),
            JsonRequestBehavior.AllowGet);
        }

        public ActionResult duyetduan()
        {
            var viewlist = db.PROPERTies.OrderByDescending(m => m.Create_post).Where(p => p.PROJECT_STATUS.Status_Name == "Chưa duyệt").ToList();
            return View(viewlist);
        }
        [HttpGet]
        public ActionResult ApprovalProject(int? id)
        {
            var duyet = db.PROPERTies.FirstOrDefault(x => x.ID == id);
            if (duyet == null)
            {
                return HttpNotFound();
            }
            return View(duyet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApprovalProject(PROPERTY model)
        {
            PROPERTY pro = db.PROPERTies.Find(model.ID);
            pro.Status_ID = 3;
            pro.Sale_ID = int.Parse(Session["UserID"].ToString());
            pro.Updated_at = DateTime.Now;

            db.Entry(pro).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("duyetduan");
        }
        
        public ActionResult News()
        {
            var news = db.NEWs.ToList();
            return View(news);
        }

        [HttpGet]
        public ActionResult editnews(int id)
        {
            var news = db.NEWs.Find(id);
            return View(news);
        }
        
        [HttpPost]
        public ActionResult editnews(NEW model, HttpPostedFileBase Avatar)
        {
            NEW n = db.NEWs.Find(model.ID);

            if (Avatar != null)
            {
                string avatar = "";
                if (Avatar.ContentLength > 0)
                {
                    var filename = Path.GetFileName(Avatar.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/News/"), filename);
                    Avatar.SaveAs(path);
                    avatar = filename;
                }
                n.Image = avatar;
            }
            n.Name = model.Name;
            n.Content = model.Content;

            db.Entry(n).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("News");
        }

        [HttpGet]
        public ActionResult addnews(int id)
        {
            var news = db.NEWs.Find(id);
            return View(news);
        }

        [HttpPost]
        public ActionResult addnews(NEW model, HttpPostedFileBase Avatar)
        {
            NEW n = db.NEWs.Find(model.ID);

            if (Avatar != null)
            {
                string avatar = "";
                if (Avatar.ContentLength > 0)
                {
                    var filename = Path.GetFileName(Avatar.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/News/"), filename);
                    Avatar.SaveAs(path);
                    avatar = filename;
                }
                model.Image = avatar;
            }

            model.Created_at = DateTime.Now;
            model.Sale_ID = int.Parse(Session["UserID"].ToString());
            db.NEWs.Add(model);
            db.SaveChanges();
            return RedirectToAction("News");
        }

        [HttpGet]
        public ActionResult About()
        {
            var about = db.ABOUTs.ToList();
            return View(about);
        }
        
        [HttpGet]
        public ActionResult editabout(int id)
        {
            ABOUT edit = db.ABOUTs.Find(id);
            return View(edit);
        }

        [HttpPost]
        public ActionResult editabout(ABOUT model)
        {
            ABOUT pro = db.ABOUTs.Find(model.ID);
            pro.Title = model.Title;
            pro.CEO = model.CEO;
            pro.About_us = model.About_us;
            pro.Our_Team = model.Our_Team;
            pro.Decription = model.Decription;

            db.Entry(pro).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("About");
        }
    }
}