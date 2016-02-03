using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_AirBnb.Models;

namespace Proyecto_AirBnb.Controllers
{
    
    public class InicioController : Controller
    {
        MiDataBaseDataContext db = new MiDataBaseDataContext();

        // GET: Inicio
        public ActionResult Index()
        {
             Usuario usu = (from user in db.Usuarios
                      where user.Nombre == "Pepe"
                      select user).Single();
            return View(usu);
        }
    }
}