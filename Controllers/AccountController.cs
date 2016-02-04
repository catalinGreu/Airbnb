using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Proyecto_AirBnb.Models;
namespace Proyecto_AirBnb.Controllers
{
    public class AccountController : Controller
    {
        OperacionesBDController ope = new OperacionesBDController();
        // GET: Account
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Registro(RegistroViewModel model) // va a tener que ser si o si un hilo TASK
        {
            if ( ModelState.IsValid )
            {
                //hago algo y grabo el usuario
                //LLamo controlador que graba user
                Usuario u = new Usuario { Id = "3434543", Nombre = model.Nombre, Apellido = model.Apellido, Correo = model.Correo };
                ope.GrabaUser(u);
                return RedirectToAction("Index", "Inicio");
            }
            

            return View(model);
        }
    }
}