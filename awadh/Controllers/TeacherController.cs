using Awadh.DAL;
using Awadh.Models;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Awadh.Controllers
{
    [SessionCheck]
    [Authrization("Admin","Teacher")]
    public class TeacherController :Controller
    {
        // GET: Teacher
        LoginData loginData = new LoginData();
        StudentRegistrationDal dal = new StudentRegistrationDal();
        public ActionResult Index()
        {
            return View();
        }

        public string ChangeStatus(string Status, string RegId)
        {
            string Val = "";            
            Val = dal.ChangeStatus(Status, RegId);
            return Val;
        }

        public ContentResult Upload(string newname)
        {
            string RecentGenerateID = newname.ToString();
            string path = Server.MapPath("~/Content/PDF/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            HttpPostedFileBase postedFile = Request.Files[0];
            //postedFile.SaveAs(path + postedFile.FileName);
            postedFile.SaveAs(path + RecentGenerateID.ToString() + System.IO.Path.GetExtension(postedFile.FileName));

            string imagepath = "/Content/PDF/" + newname;
            //foreach (string key in Request.Files)
            //{
            //    HttpPostedFileBase postedFile = Request.Files[key];
            //    postedFile.SaveAs(path + postedFile.FileName);

            //}

            return Content(imagepath);
        }



        public string VedioDetails(string Comm)
        {
            string Val = "";
            Models.ProfileData REG = JsonConvert.DeserializeObject<Models.ProfileData>(Comm);
            Val = dal.VideoDetails(REG);
            return Val;
        }

        public ActionResult UsersDeatil()
        {
            return View();
        }
        

        public ActionResult StatusChange()
        {
            return View();
        }

        
        public JsonResult GetSubjectMaster()
        {
            var users = dal.GetSubjectMaster();
            return Json(users, JsonRequestBehavior.AllowGet);
        }
    }
}