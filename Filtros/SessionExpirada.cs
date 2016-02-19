using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Proyecto_AirBnb.Filtros
{
    public class SessionExpirada : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (HttpContext.Current.Session["usuario"] == null)
            {
                RouteValueDictionary redirect = new RouteValueDictionary();
                redirect.Add("action", "Login");
                redirect.Add("controller", "Account");

                filterContext.Result = new RedirectToRouteResult(redirect);
            }
        }
    }
}