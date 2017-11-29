using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPC_Rental.Models;
using System.IO;

namespace PPC_Rental.Controllers
{
    public class SaleController : Controller
    {
        K21T1_Team4Entities1 db = new K21T1_Team4Entities1();
        // GET: Sale
        public ActionResult Index(/*string status = "Đã duyệt"*/)
        {
            var viewlist = db.PROPERTies/*.Where(p => p.PROJECT_STATUS.Status_Name == status)*/.ToList();
            return View(viewlist);
        }

        public ActionResult Delete(int id)
        {
            var de = db.PROPERTies.First(p => p.ID == id);
            db.PROPERTies.Remove(de);
            db.SaveChanges();
            return RedirectToAction("Index");
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
            ViewBag.staid = db.PROJECT_STATUS.OrderByDescending(x => x.ID).ToList();
            return View(editproject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProject1(PROPERTY model, HttpPostedFileBase Avatar, List<string> chk1)
        {
            PROPERTY pro = db.PROPERTies.Find(model.ID);
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
            

            pro.PropertyName = model.PropertyName;
            pro.Avatar = Avatar.FileName;
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
            pro.UserID = model.UserID;
            pro.Created_at = model.Created_at.Value;
            pro.Status_ID = model.Status_ID;
            pro.Note = model.Note;
            pro.Updated_at = DateTime.Now;
            pro.Sale_ID = model.Sale_ID;
            pro.PROPERTY_FEATURE = model.PROPERTY_FEATURE;

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
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddProject(PROPERTY model)
        {
            var pro = new PROPERTY();
            pro.PropertyName = model.PropertyName;
            pro.Avatar = model.Avatar;
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
            pro.UserID = model.UserID;
            pro.Created_at = DateTime.Now;
            pro.Create_post = DateTime.Now;
            pro.Status_ID = model.Status_ID;
            pro.Note = model.Note;
            pro.Updated_at = DateTime.Now;
            pro.Sale_ID = model.Sale_ID;
            pro.PROPERTY_FEATURE = model.PROPERTY_FEATURE;
            db.PROPERTies.Add(pro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult GetStreet(int District_id)
        {
            return Json(
            db.STREETs.Where(s => s.District_ID == District_id)
            .Select(s => new { id = s.ID, text = s.StreetName }).ToList(),
            JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetWard(int District_id)
        {
            return Json(
            db.WARDs.Where(s => s.District_ID == District_id)
            .Select(s => new { id = s.ID, text = s.WardName }).ToList(),
            JsonRequestBehavior.AllowGet);
        }
    }
}