using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPC_Rental.Models;
using System.Net.Mail;
using System.Net;

namespace PPC_Rental.Controllers
{
    public class viewDetailController : Controller
    {
        // GET: viewDetail
        K21T1_Team4Entities1 m = new K21T1_Team4Entities1();
        public ActionResult Index(int id)
        {
            var p = m.PROPERTies.FirstOrDefault(x=>x.ID==id);
            return View(p);
        }
        
        [HttpPost]
        public ActionResult Support(string nameUser,string numberPhone, string emailUser,string message)
        {
            string emailAgency = TempData["eamailagency"].ToString();//  
            //int proID = int.Parse(TempData["proID"].ToString());
            try
            {
                if (ModelState.IsValid)
                {
                    var senderemail = new MailAddress("k21t1ppcrental@gmail.com", "Công ty PPC Rental");//mail công ty
                    var receiveremail = new MailAddress(emailAgency, "Receiver"); //mail agecy

                    var password = "k21t1team4";// mật khẩu địa chỉ mail   
                    var sub = nameUser;
                    var body = "Dự án của bạn đã được liên hệ từ : " + nameUser + " với nội dung : " + message +
                        " bạn có thể liên hệ với " + nameUser + " thông qua địa chỉ email :" + emailUser + " qua số điện thoại " + numberPhone;
                    // nội dung tin nhắn


                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderemail.Address, password)

                    };

                    using (var mess = new MailMessage(senderemail, receiveremail)
                    {
                        Subject = nameUser,
                        Body = body
                    }
                    )
                    {
                        smtp.Send(mess);
                    }
                    
                    return RedirectToAction("Index", "home");
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "There are some problem in sending email";
            }
            return View();
        }
    }
}