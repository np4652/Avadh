using Awadh.DAL;
using Awadh.Models;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Awadh.Controllers
{
    public class HomeController : Controller
    {
        ProfileDal dal = new ProfileDal();

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
            StudentRegistrationDal dal = new StudentRegistrationDal();
            var result = dal.RegistrationPer(data);
            return Json(result);
        }

        [HttpPost]
        public ContentResult Upload(string newname)
        {

            if (string.IsNullOrEmpty(newname))
            {
                return Content("Name cann't be empty");
            }

            string RecentGenerateID = newname.ToString();
            string path = Server.MapPath("~/Content/Uploads/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            HttpPostedFileBase postedFile = Request.Files[0];            
            postedFile.SaveAs(path + RecentGenerateID.ToString() + System.IO.Path.GetExtension(postedFile.FileName));
            string imagepath = "~/Content/Uploads/" + RecentGenerateID.ToString();            
            return Content(imagepath);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
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
    }
}