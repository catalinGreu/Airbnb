using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_AirBnb.Models;
namespace Proyecto_AirBnb.Controllers
{
    public class AnunciosController : Controller
    {
        // GET: Anuncios
        public ActionResult NuevoAnuncio()
        {
            CreaAnuncioViewModel model = new CreaAnuncioViewModel();
            model.Alojamientos = new List<string> { "Apartamento", "Casa", "Bed&Breakfast" };
            model.Habitaciones = new List<string> { "Casa/Apto. Entero", "Habitacion privada", "Habitacion compartida" };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult NuevoAnuncio(CreaAnuncioViewModel model)
        {
            // SI el usuario no esta conectado no puede subir anuncios

            if (ModelState.IsValid)
            {
                if (Session["usuario"] != null)
                {
                    //grabo el anuncio y voy a completar anuncio


                }
                else
                {
                    //le mando a registro o a login...y guardo en sesion el Anuncio (Incompleto)
                    Anuncio a = new Anuncio { Alojamiento = model.Alojamiento, Habitacion = model.Habitacion, Capacidad = model.Capacidad, Localidad = model.Ciudad };
                    Session["anuncio"] = a;
                    // AUN NO GRABO EN BD, HASTA QUE NO SE REGISTRE O LOGGEE
                    // PERO METO EN SESSION EL Anuncio POR AHORA
                    ViewBag.Warning = "Registrate o Inicia sesión para continuar";
                    return RedirectToAction("NuevoAnuncio", "Anuncios");
                }
            }
            return View();
        }

















        #region "Accesso a datos"
        #endregion





















    }
}