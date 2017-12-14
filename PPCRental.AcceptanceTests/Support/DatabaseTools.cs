using PPC_Rental.Models;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.Support
{
    [Binding]
    public class DatabaseTools
    {
        [BeforeScenario]
        public void CleanDatabase()
        {
            using (var db = new K21T1_Team4Entities1())
            {

                db.PROPERTies.RemoveRange(db.PROPERTies);
                db.SaveChanges();
            }
        }
    }
}
