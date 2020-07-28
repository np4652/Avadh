using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Awadh.DAL;
using Awadh.Models;
using Newtonsoft.Json;

namespace Awadh.Controllers
{
    [SessionCheck]
    [Authrization("Admin", "Teacher", "Student")]
    public class CommonController : Controller
    {
        // GET: ProfilePage
        ProfileDal dal = new ProfileDal();
        public ActionResult Index()
        {
            return View();
        }
        
        public JsonResult GetProfiledetails()
        {
            var login = (LoginData)Session[SessionKey.Login];
            var users = dal.GetProfiledetails(login.LoginID);
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