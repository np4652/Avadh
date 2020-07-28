using Awadh.Models;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Awadh
{
    public class AuthrizationAttribute : AuthorizeAttribute
    {
        private readonly string[] allowedroles;
        public AuthrizationAttribute(params string[] roles)
        {
            this.allowedroles = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            var loginData = (LoginData)httpContext.Session[SessionKey.Login];
            if(loginData!=null && !string.IsNullOrEmpty(loginData.Role))
            {
                foreach (var role in allowedroles)
                {
                    if (role == loginData.Role) 
                        return true;
                }
            }
            return authorize;
            //if (!string.IsNullOrEmpty(userId))
            //    using (var context = new SqlDbContext())
            //    {
            //        var userRole = (from u in context.Users
            //                        join r in context.Roles on u.RoleId equals r.Id
            //                        where u.UserId == userId
            //                        select new
            //                        {
            //                            r.Name
            //                        }).FirstOrDefault();
            //        foreach (var role in allowedroles)
            //        {
            //            if (role == userRole.Name) return true;
            //        }
            //    }
            //return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary
               {
                    { "controller", "Home" },
                    { "action", "index" }
               });
        }
    }
}