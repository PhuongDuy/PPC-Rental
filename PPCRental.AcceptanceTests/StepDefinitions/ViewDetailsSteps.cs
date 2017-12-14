using TechTalk.SpecFlow;
using PPCRental.AcceptanceTests.Driver.ViewDetails;

namespace PPCRental.AcceptanceTests.StepDefinitions
{
    [Binding, Scope (Tag ="automated")]
     class ViewDetails
    {
        // private readonly Driver.ViewDetails.ViewDetailsDriver _detailsDriver;
        private readonly ViewDetailsDriver _detailsDriver;
        public ViewDetails(ViewDetailsDriver driver)
        {
            _detailsDriver = driver;
        }
     
        [Given(@"the following projects")]
        public void GivenTheFollowingProjects(Table Project)
        {
            _detailsDriver.InsertProjectToDB(Project);
        }

        [When(@"User click ""(.*)""")]
        public void WhenUserClick(string p0)
        {
            _detailsDriver.OpenPropertyDetails(p0);
        }

        [Then(@"Hien thi thong tin chi tiet du an")]
        public void ThenHienThiThongTinChiTietDuAn(Table table)
        {
            _detailsDriver.ShowDetailProject(table);
        }

    }
}
