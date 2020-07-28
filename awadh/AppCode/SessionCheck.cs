using Awadh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Awadh
{
    public class SessionCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if (HttpContext.Current.Session[SessionKey.Login] == null)
            {
                filterContext.Result = new RedirectResult("~/Home/Index?q=-1");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}