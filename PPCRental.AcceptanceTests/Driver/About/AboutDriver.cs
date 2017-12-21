using PPC_Rental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPCRental.AcceptanceTests.Driver.About
{
    public class AboutDriver
    {
        internal void ShouldShowAbout(object showAbout)
        {
            var db = new K21T1_Team4Entities1();
            var viewlist = db.ABOUTs.ToList();
        }
    }
}
