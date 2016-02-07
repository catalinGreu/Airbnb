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
        UsuarioController controlUsu = new UsuarioController();
        // GET: Anuncios
        public ActionResult NuevoAnuncio()
        {
            //CreaAnuncioViewModel model = new CreaAnuncioViewModel();
            //model.Alojamientos = new List<string> { "Apartamento", "Casa", "Bed&Breakfast" };
            //model.Habitaciones = new List<string> { "Casa/Apto. Entero", "Habitacion privada", "Habitacion compartida" };
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult NuevoAnuncio(CreaAnuncioViewModel model)
        {
            // SI el usuario no esta conectado no puede subir anuncios

            if (ModelState.IsValid)
            {
                Usuario u = (Usuario)Session["usuario"];
                if ( u != null)
                {
                    string idUser = ((Usuario) Session["usuario"]).Id;
                    //grabo el anuncio y voy a completar anuncio
                    // ya es anfitrion
                    Anuncio a = new Anuncio { Id_Anfitrion = idUser, Alojamiento = model.Alojamiento,
                                            Habitacion = model.Habitacion,
                                            Capacidad = model.Capacidad,
                                            Localidad = model.Ciudad };
                    controlUsu.SetAnfitrion(idUser); //-- > Au nno grabo en la BD
                    u.Anfitrion = true;
                    Session["usuario"] = u; //lo vuelvo a meter en session
                    Session["anuncio"] = a; //----> LO meto en la sesion para leerlo en COmpletarAnuncio

                    return RedirectToAction("CompletaAnuncio", "Anuncios");
                }
                else
                {
                    //le mando a registro o a login...y guardo en sesion el Anuncio (Incompleto)
                    Anuncio a = new Anuncio { Alojamiento = model.Alojamiento, Habitacion = model.Habitacion, Capacidad = model.Capacidad, Localidad = model.Ciudad };
                    Session["anuncio"] = a;
                    // AUN NO GRABO EN BD, HASTA QUE NO SE REGISTRE O LOGGEE
                    // PERO METO EN SESSION EL Anuncio POR AHORA
                    /*
                        Le mando a registrarse.....o loggearse
                        Pero tengo que ver como hago que vuelva a anuncios...desde Index, porq index es vista unica...
                        no prevé que haya un anuncio en curso

                    Y ADEMAS!!!! TANTO SI SE LOGGEA COMO REGISTRA, TENGO QUE SETTEAR ANFITRION = TRUE
                    */
                    ViewBag.Warning = "Registrate o Inicia sesión para continuar";
                    return RedirectToAction("NuevoAnuncio", "Anuncios",ViewBag.Warning);
                }
            }
            return View();
        }

        public ActionResult CompletaAnuncio()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CompletaAnuncio(CompletaAnuncioViewModel model)
        {
            if (ModelState.IsValid)
            {
                Anuncio a = (Anuncio)Session["anuncio"];
                a.Titulo = model.Titulo;
                a.Precio = model.Precio;
                a.Foto = model.Foto;
                a.Descripcion = model.Descripcion;

                GrabaAnuncio(a);
                return RedirectToAction("Index", "Inicio");
                //hago algo....
                //guardo foto...
            }
            return View(model);
        }

        #region "Accesso a datos"
        public void GrabaAnuncio(Anuncio a)
        {
            using (OperacionesBDController db = new OperacionesBDController() )
            {
                db.GrabaAnuncio(a);
            }
        }
        #endregion





















    }
}