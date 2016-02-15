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
            if (TempData["warning"] != null)
            {
                ViewBag.Warning = TempData["warning"].ToString();

            }
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
                if (u != null)
                {
                    string idUser = ((Usuario)Session["usuario"]).Id;
                    //grabo el anuncio y voy a completar anuncio
                    // ya es anfitrion
                    Anuncio a = new Anuncio
                    {
                        Id_Anfitrion = idUser,
                        Alojamiento = model.Alojamiento,
                        Habitacion = model.Habitacion,
                        Capacidad = model.Capacidad,
                        Localidad = model.Ciudad
                    };
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
                   
                    TempData["warning"] = "Registrate o Inicia sesión para continuar";
                    //ViewBag.Warning = "Registrate o Inicia sesión para continuar";
                    return RedirectToAction("NuevoAnuncio", "Anuncios");
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
                string idUser = ((Usuario)Session["usuario"]).Id;
                Anuncio a = (Anuncio)Session["anuncio"];
                a.Titulo = model.Titulo;
                a.Precio = model.Precio;
                a.Foto = idUser + model.Foto.FileName;
                a.Descripcion = model.Descripcion;

                GrabaAnuncio(a); Session["anuncio"] = null;//--->Ya no me hace falta
                FileUpload(model.Foto, idUser);
                return RedirectToAction("Index", "Inicio");
            }
            return View(model);
        }


        public void FileUpload(HttpPostedFileBase file, string id) // ---> subo Upload
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(id + file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Content/Imagenes/Anuncios"), pic);
                // file is uploaded
                file.SaveAs(path);

            }
        }


        public ActionResult DetalleAnuncio(int? id)
        {
            Anuncio a = getAnuncioById((int)id);
            return View(a);
        }
        public ActionResult ListarAnuncios()
        {
            List<Anuncio> lista = (List<Anuncio>)TempData["lista"];
            return View(lista);
        }

        public string Reserva(string id) //--> ID del Anuncio
        {
            if (Session["usuario"] != null)
            {
                Usuario conectado = (Usuario)Session["usuario"];
                Reserva r = new Models.Reserva { Id_Anuncio = Convert.ToInt16(id), Id_Huesped = conectado.Id };

                if (GrabaReserva(r))
                {
                    string idAnfitrion = getIdAnfitrion(Convert.ToInt16(id)); //id ---> Anuncio
                    if(idAnfitrion.Equals(conectado.Id))
                    {
                        return ("<script>alert('Este anuncio lo has publicado tu, Capullo!');" +
                       "window.location.assign('http://localhost:17204/Inicio/Index');" +
                   "</script>");
                    }
                    string texto = "El usuario " + conectado.Nombre + " ha hecho una reserva para su anuncio con ID=" + Convert.ToInt16(id);
                    Mensaje m = new Mensaje
                    {
                        Fecha = DateTime.Now,
                        Id_Destinatario = idAnfitrion,
                        Id_Remitente = conectado.Id,
                        Leido = false,
                        Mensaje1 = texto
                    };
                    MandaNotificacionReserva(m);
                    return ("<script>alert('Reserva realizada con éxito');" +
                        "window.location.assign('http://localhost:17204/Inicio/Index');" +
                    "</script>");

                }
                else
                {
                    return ("<script>alert('Este anuncio ya lo había reservado. Espere confirmación del Anfitrión');" +
                         "window.location.assign('http://localhost:17204/Inicio/Index');" +
                     "</script>");
                }


            }
            else
            {
                return ("<script>alert('Inicia sesión o regístrate para reservar anuncios');" +
                 "window.location.assign('http://localhost:17204/Inicio/Index');" +
             "</script>");
            }

        }





        #region "Accesso a datos"
        private void GrabaAnuncio(Anuncio a)
        {
            using (OperacionesBDController db = new OperacionesBDController())
            {
                db.GrabaAnuncio(a);
            }
        }

        private Anuncio getAnuncioById(int id)
        {
            using (OperacionesBDController db = new OperacionesBDController())
            {
                return db.getAnuncioById(id);
            }
        }

        private bool GrabaReserva(Reserva r)
        {
            using (OperacionesBDController db = new OperacionesBDController())
            {
                return db.GrabaReserva(r);
            }
        }

        private string getIdAnfitrion(int id)
        {
            using (OperacionesBDController db = new OperacionesBDController())
            {
                return db.getIdAnfitrion(id);
            }
        }
        private void MandaNotificacionReserva(Mensaje m)
        {
            using (OperacionesBDController db = new OperacionesBDController())
            {
                db.MandaNotificacionReserva(m);
            }
        }
        #endregion





















    }
}