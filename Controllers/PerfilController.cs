using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_AirBnb.Controllers
{
    public class PerfilController : Controller
    {
        // GET: Perfil
        public ActionResult MiPerfil()
        {
            return View();
        }

        public ActionResult Mensajes()
        {
            return View();
        }
        public ActionResult Anuncios()
        {
            return View();
        }



        //Perfil/Mensajes

        //Perfil/Anuncios
        //Perfil/Reservas...
    }
}