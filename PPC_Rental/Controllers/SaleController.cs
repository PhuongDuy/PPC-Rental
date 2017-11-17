﻿using System;
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
            var viewlist = db.PROPERTies.ToList();
            return View(viewlist);
        }
        
        public ActionResult Delete(int id)
        {
            var de = db.PROPERTies.First(p => p.ID == id) ;
            db.PROPERTies.Remove(de);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EditProject(int id = 0)
        {
            var editproject = db.PROPERTies.Find(id);
            if (editproject == null)
                return RedirectToAction("Index");
            return View(editproject);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditProject(PROPERTY model)
        {
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            try
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View(model);
            }

        }
    }
}