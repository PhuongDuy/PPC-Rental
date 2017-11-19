using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPC_Rental.Models;

namespace PPC_Rental.Controllers
{
    public class SaleController : Controller
    {
        K21T1_Team4Entities1 db = new K21T1_Team4Entities1();
        // GET: Sale
        public ActionResult Index()
        {
            var viewlist = db.PROPERTies.OrderByDescending(x => x.ID).ToList();
            return View(viewlist);
        }
        
        public ActionResult Delete(int id)
        {
            var de = db.PROPERTies.First(p => p.ID == id) ;
            db.PROPERTies.Remove(de);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditProject(int id)
        {
            var editproject = db.PROPERTies.FirstOrDefault(x => x.ID == id);
            return View(editproject);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditProject(int id,PROPERTY model)
        {
            PROPERTY pro = db.PROPERTies.FirstOrDefault(x => x.ID == id);
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
            pro.Created_at = model.Created_at;
            pro.Create_post = model.Create_post;
            pro.Status_ID = model.Status_ID;
            pro.Note = model.Note;
            pro.Updated_at = model.Updated_at;
            pro.Sale_ID = model.Sale_ID;

            //db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            //try
            //{
                db.SaveChanges();
                return RedirectToAction("Index");
            //}
            //catch (Exception e)
            //{
            //    ViewBag.Error = e.Message;
            //    return View(model);
            //}

        }
    }
}