using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PPC_Rental.Controllers;

namespace PPCRental.AcceptanceTests.Driver.Login
{
    public class LoginDriver
    {
        private ActionResult _result;

        public void Navigate()
        {
            using (var controller = new HomeController())
            {
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
