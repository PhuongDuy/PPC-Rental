using TechTalk.SpecFlow;
using System;
using PPCRental;
using PPCRental.AcceptanceTests.Driver.ViewDetails;
using PPCRental.UITests.Selenium.Support;

namespace PPCRental.AcceptanceTests.StepDefinitions
{
    [Binding, Scope (Tag ="automated")]
    public class ViewDetails
    {
        private readonly ViewDetailsDriver _detailsDriver;
        int _Avatar;
        string _PropertyName;
        string _images;
        string _PropertyTypeID;
        string _content;
        int _StreetID;
        int _WardID;
        int _DistrictID;
        int _Area;
        int _PackingPlace;
        int _Bedroom;
        int _Bathroom;


        [Given(@"the following projects")]
        public void GivenTheFollowingProjects(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"User click ""(.*)""")]
        public void WhenUserClick(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Hien thi thong tin chi tiet du an")]
        public void ThenHienThiThongTinChiTietDuAn(Table table)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
