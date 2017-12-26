using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

using PPCRental.AcceptanceTests.Driver.ViewListOfProjectAgency;
using PPC_Rental.Models;

namespace WebPPC.AcceptanceTests.StepDefinitions
{
    [Binding, Scope(Tag = "automation")]
    public class ViewListAgencySteps
    {
        K21T1_Team4Entities1 db = new K21T1_Team4Entities1();
       // private readonly PropertyDrivers _projectdriver;
        private readonly ViewListAgencySteps _agencydriver;


        //public ViewListAgencySteps(PropertyDrivers Prodriver, AgencyDrivers Agdriver)
        //{
        //    _projectdriver = Prodriver;
        //    _agencydriver = Agdriver;
        //}

      
        [Given(@"the following users")]
        public void GivenTheFollowingUsers(Table user)
        {
            // ScenarioContext.Current.Pending();
            //_agencydriver.User(user);
        }

        [Given(@"the following projects")]
        public void GivenTheFollowingProjects(Table project)
        {
            //_projectdriver.Property(project);
        }

        [Given(@"Toi dang o trang chu")]
        public void GivenToiDangOTrangChu()
        {
          //  _projectdriver.NavigateToHome();
        }

        [Given(@"Toi di den dang nhap")]
        public void GivenToiDiDenDangNhap()
        {
          //  _agencydriver.GotoLogin();
        }

        [When(@"Toi dang nhap email '(.*)' va '(.*)'")]
        public void WhenToiDangNhapEmailVa(string email, string password)
        {
            //_agencydriver.Login(email, password);
        }

        [Then(@"Toi se thay duoc danh sach cac du an cua toi")]
        public void ThenToiSeThayDuocDanhSachCacDuAnCuaToi(Table showProject)
        {
           // _projectdriver.ShowListOfProject(showProject);
        }


    }
}
