using Awadh.AppCode.Interfaces;
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
        StudentRegistrationDal dal = new StudentRegistrationDal();
        private readonly ITeacher teacherML = new TeacherML();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Dashboard()
        {
            var data = teacherML.Dashboard();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Uploads()
        {
            return View();
        }

        [HttpPost]
        public Response ChangeStatus(string Status, string RegId)
        {
            var response = teacherML.ChangeStatus(Status, RegId);
            return response;
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
            postedFile.SaveAs(path + RecentGenerateID.ToString() + System.IO.Path.GetExtension(postedFile.FileName));

            string imagepath = "/Content/PDF/" + newname;
            return Content(imagepath);
        }



        public string VedioDetails(string Comm)
        {
            Models.ProfileData REG = JsonConvert.DeserializeObject<Models.ProfileData>(Comm);
            var Val = dal.VideoDetails(REG);
            return Val;
        }

        public ActionResult UsersDetail()
        {
            return View();
        }
    }
}