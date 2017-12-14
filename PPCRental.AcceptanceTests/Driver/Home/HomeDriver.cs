using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PPC_Rental.Models;
using PPC_Rental.Controllers;

namespace PPCRental.AcceptanceTests.Driver.Home
{
    class HomeDriver
    {
        private ActionResult _result;

        public void Navigate()
        {
            using(var controller = new HomeController())
            {
                _result = controller.Index();
            }
        }
    }
}
