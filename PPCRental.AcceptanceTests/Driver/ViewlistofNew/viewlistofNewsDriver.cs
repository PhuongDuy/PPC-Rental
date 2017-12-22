using PPC_Rental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPCRental.AcceptanceTests.Driver.ViewlistofNew
{
    public class ViewlistofNewsDriver
    {
        public void ShouldShowNews(object shownews)
        {
            var db = new K21T1_Team4Entities1();
            var viewlist = db.NEWs.OrderByDescending(m => m.Created_at).ToList();
        }
    }
}
