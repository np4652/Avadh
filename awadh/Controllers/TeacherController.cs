using Awadh.AppCode.Interfaces;
using Awadh.DAL;
using Awadh.Models;
using System;
using System.IO;
using System.Text;
using System.Web.Mvc;

namespace Awadh.Controllers
{
    [SessionCheck]
    [Authrization("Admin","Teacher")]
    public class TeacherController :Controller
    {
        private readonly ITeacher teacherML = new TeacherML();
        private readonly ICommon commonML = new CommonDal();
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
            var subjectList = commonML.GetSubjectMaster();
            return View(subjectList);
        }

        [HttpPost]
        public Response ChangeStatus(string Status, string RegId)
        {
            var response = teacherML.ChangeStatus(Status, RegId);
            return response;
        }

        [HttpPost]
        public JsonResult UploadStudyMaterial(MaterialUploadDetail param)
        {
            if(!param.IsLink){
                if (param.Files != null)
                {
                    string path = Server.MapPath("~/Content/PDF/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    StringBuilder sb = new StringBuilder(path);
                    StringBuilder fileName = new StringBuilder();
                    fileName.Append(param.Class);
                    fileName.Append("_");
                    fileName.Append(param.SubjectID);
                    fileName.Append("_");
                    fileName.Append(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss").Replace("-", "").Replace(" ", "").Replace(":", ""));
                    fileName.Append(Path.GetExtension(param.Files.FileName));
                    sb.Append(fileName);
                    param.Files.SaveAs(sb.ToString());
                    StringBuilder folderPath = new StringBuilder("/Content/PDF/");
                    folderPath.Append(fileName);
                    param.URL = folderPath.ToString();
                }
            }
            var response = teacherML.MaterialUploadDetail(param);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UsersDetail()
        {
            return View();
        }
    }
}