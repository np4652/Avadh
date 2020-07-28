using Awadh.DAL;
using Awadh.Models;
using System.IO;
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
            var users = dal.login(RegId, PSD);
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public ActionResult logout(string RegId, string PSD)
        {
            string lg = null;
            Session["UserId"] = lg;
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Registration()
        {
            return PartialView();
        }

        [HttpPost]
        public string _Registration(Registration data)
        {
            StudentRegistrationDal dal = new StudentRegistrationDal();
            var Val = dal.RegistrationPer(data);
            return Val;
        }

        [HttpPost]
        public ContentResult Upload(string newname)
        {
            string RecentGenerateID = newname.ToString();
            string path = Server.MapPath("~/Uploads/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            HttpPostedFileBase postedFile = Request.Files[0];            
            postedFile.SaveAs(path + RecentGenerateID.ToString() + System.IO.Path.GetExtension(postedFile.FileName));
            string imagepath = "~/Uploads/" + RecentGenerateID.ToString();            
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
    }
}