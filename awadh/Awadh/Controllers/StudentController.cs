using Awadh.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Awadh.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        ProfileDal dal = new ProfileDal();
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult Getsubjectmathsvedio(string cls, string sub)
        {
            var users = dal.GetSubjectMaths(cls, sub);
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Getsubjecthindivedio(string cls, string sub)
        {
            var users = dal.Getsubjecthindivedio(cls, sub);
            return Json(users, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Getsubjectsciencevedio(string cls, string sub)
        {
            var users = dal.Getsubjectsciencevedio(cls, sub);
            return Json(users, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Getsubjectenglishvedio(string cls, string sub)
        {
            var users = dal.Getsubjectenglishvedio(cls, sub);
            return Json(users, JsonRequestBehavior.AllowGet);
        }
    }
}