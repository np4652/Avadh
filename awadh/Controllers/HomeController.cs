using Awadh.AppCode.Interfaces;
using Awadh.DAL;
using Awadh.Models;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Awadh.Controllers
{
    public class HomeController : Controller
    {
        ProfileDal dal = new ProfileDal();
        private readonly ICommon commonML = new CommonDal();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult _Login(string RegId, string PSD)
        {
            var users = (Response)dal.login(RegId, PSD);
            if (users != null && users.StatusCode==1)
            {
                var login = (LoginData)Session[SessionKey.Login];
                switch(login.Role)
                {
                    case Roles.Admin:
                        users.CommonString = "/Teacher/Index";
                        break;
                    case Roles.Teacher:
                        users.CommonString = "/Teacher/Index";
                        break;
                    case Roles.Student:
                        users.CommonString = "/Student/Index";
                        break;
                }
            }
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public ActionResult logout(string RegId, string PSD)
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Registration()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult _Registration(Registration data)
        {
            var response = commonML.RegistrationPer(data);

            if(response.StatusCode==1 && response.CommonInt > 0)
            {
                try
                {
                    string path = Server.MapPath("~/Content/Uploads/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    HttpPostedFileBase postedFile = Request.Files[0];
                    StringBuilder sb = new StringBuilder();
                    sb.Append(path);
                    sb.Append(response.CommonInt);
                    sb.Append(".jpg");
                    postedFile.SaveAs(sb.ToString());
                }
                catch(Exception ex)
                {
                    
                }
            }
            return Json(response);
        }


        public string SendingMail(string Comm)
        {
            string Val = "mail Send";
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("ankit070518@gmail.com");
            message.To.Add(new MailAddress("theaj0001@gmail.com"));
            message.Subject = "Test";
            message.IsBodyHtml = true; //to make message body as html  
            message.Body = "This is for testing SMTP mail from GMAIL";
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com"; //for gmail host  
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("ankit070518@gmail.com", "ankit@12345");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
            return Val;
        }
    }
}