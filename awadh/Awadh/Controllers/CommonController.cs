using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Awadh.DAL;
using Newtonsoft.Json;

namespace Awadh.Controllers
{
    public class CommonController : Controller
    {
        // GET: ProfilePage
        ProfileDal dal = new ProfileDal();
        public ActionResult Index()
        {
            return View();
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


        public JsonResult GetProfiledetails(string RegId)
        {
            var users = dal.GetProfiledetails(RegId);
            return Json(users, JsonRequestBehavior.AllowGet);
        }
        
        public string loginsummery(string RegId)
        {
            string Val = ""; 
            //  Models.Registration REG = JsonConvert.DeserializeObject<Models.Registration>(RegId);
            Val = dal.loginsummery(RegId);
            return Val;
        }

        public JsonResult GetAllProfileDetails(string RegId)
        {
            var users = dal.GetAllProfileDetails(RegId);
            return Json(users, JsonRequestBehavior.AllowGet);
        }
    }
}