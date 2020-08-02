using System.Web;
using System.Web.Mvc;
using Awadh.AppCode.Interfaces;
using Awadh.DAL;
using Awadh.Models;

namespace Awadh.Controllers
{

    [SessionCheck]
    [Authrization("Admin", "Teacher", "Student")]
    public class CommonController : Controller
    {
        
        private readonly ICommon commonML = new CommonML();

        [HttpPost]
        public JsonResult Dashboard()
        {
            var data = commonML.Dashboard();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AskedQuestion()
        {
            var subjects = commonML.GetSubjectMaster();
            return View(subjects);
        }        

        [HttpPost]
        public ActionResult ChangePassword()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult ChangeUserPassword(string currentPass,string newPass,string rePass)
        {
            var response = new Response
            {
                StatusCode = -1,
                Status = "Something went wrong.Please try after sometime."
            };
            if (newPass != rePass)
            {
                response.Status = "Password not matched.Please re-enter password";
            }
            response = commonML.ChangePassword(currentPass, newPass);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ReplyToQuestion(int QuestionID)
        {
            var response = commonML.GetAskedQuestionByID(QuestionID);
            return PartialView(response);
        }

        [HttpPost]
        public JsonResult PostReply(AskedQuestion param)
        {
            var response = commonML.ReplyToQuestion(param);
            return Json(response,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AskedQuestion(AskedQuestion param)
        {
            var response = commonML.AskedQuestion(param);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult GetAskedQuestion()
        {
            var list = commonML.GetAskedQuestion();
            return View(list);
        }

        [HttpPost]
        public JsonResult uploadImage(HttpPostedFileBase file)
        {
            var src = commonML.uploadEditorImage(file);
            return Json(src, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProfiledetails()
        {
            var login = (LoginData)Session[SessionKey.Login];
            var users = commonML.GetProfiledetails(login.LoginID);
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllProfileDetails(string RegId)
        {
            var users = commonML.GetAllProfileDetails(RegId);
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSubjectMaster()
        {
            var subjectList = commonML.GetSubjectMaster();
            return Json(subjectList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetuploadedMaterial(int SubjectID)
        {
            var list = commonML.GetuploadedMaterial(SubjectID);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}