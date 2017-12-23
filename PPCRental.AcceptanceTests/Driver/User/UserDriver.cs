using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PPC_Rental.Controllers;
using FluentAssertions;
using PPC_Rental.Models;
using PPCRental.AcceptanceTests.Support;
using System.Linq;
using TechTalk.SpecFlow;

namespace PPCRental.AcceptanceTests.Driver.User
{
     public class UserDriver
    {
        //private readonly ActionResult _result;
        private  ActionResult _result;
        private readonly CatalogContext _context = new CatalogContext();

        public void Navigate()
        {
            using (var controller = new HomeController())
            {
                //_result = controller.Index();
                _result = controller.Index();
            }
        }
            public void Login(string username, string password)
            {
                using (var controller = new HomeController())
                {
                    _result = controller.Login(username, password);
                }
            }
       
    }
}
