using System.Web.Mvc;

namespace Awadh.Controllers
{
    [SessionCheck]
    [Authrization("Admin", "Teacher", "Student")]
    public class StudentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StudyMaterial()
        {
            return View();
        }
    }
}