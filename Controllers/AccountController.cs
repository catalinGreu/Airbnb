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
        UsuarioController usucontr = new UsuarioController();
        // GET: Account
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Registro(RegistroViewModel model)
        {
            if (ModelState.IsValid)
            {
                int currentYear = DateTime.Now.Year;
                int nacimiento = model.Nacimiento.Year;
                int diferencia = currentYear - nacimiento;

                if (diferencia >= 18)
                {
                    string salt = usucontr.GeneraID();
                    string hash = usucontr.Hashea(salt, model.Password);

                    //Construyo Usuario
                    Usuario u = new Usuario { Id = salt, Nombre = model.Nombre, Apellido = model.Apellido, Correo = model.Correo, Hash = hash, Anfitrion = false, Nacimiento = model.Nacimiento };

                    ope.GrabaUser(u);
                    return RedirectToAction("Index", "Inicio");
                }
                else
                {
                    ViewBag.Menor = "Lo sentimos, no puedes registrarte siendo menor de edad";
                }
            }


            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {

                string elID = ope.GetIdByCorreo(model.Email);
                if (elID == null) //---> No existe ese correo
                {
                    ViewBag.ErrorUsuario = "El usuario no existe";
                    return View(model);
                }
                string hash = usucontr.Hashea(elID, model.Password);

                if (ope.ExisteUsuario(hash, model.Email))
                {
                    Usuario u = ope.GetUserById(elID);
                    return RedirectToAction("Index", "Inicio", new { usuario = u });
                }
            }
            return View(model);
        }
    }
}