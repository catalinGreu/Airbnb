using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_AirBnb.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Registro()
        {
            return View();
        }
    }
}