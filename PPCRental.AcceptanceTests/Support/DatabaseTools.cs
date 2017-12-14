using PPC_Rental.Models;
using TechTalk.SpecFlow;

namespace PPCRental.AcceptanceTests.Support
{
    [Binding]
    public class DatabaseTools
    {
        [BeforeScenario]
        public void CleanDatabase()
        {
            using (var db = new K21T1_Team4Entities1())
            {
                db.PROPERTY_IMAGE.RemoveRange(db.PROPERTY_IMAGE);
                db.PROPERTY_FEATURE.RemoveRange(db.PROPERTY_FEATURE);
                db.PROPERTies.RemoveRange(db.PROPERTies);
                db.SaveChanges();
            }
        }
    }
}
