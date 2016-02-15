using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_AirBnb.Models;

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

        public PartialViewResult Listar(string index)
        {
            Usuario conectado = (Usuario)Session["usuario"];
            switch (index)
            {
                case "mensajes":
                    List<Mensaje> lista = getMensajesUsuario(conectado);
                    return PartialView("Mensajes", lista);

                case "misAnuncios":
                    List<Anuncio> list = getAnunciosSubidos(conectado);
                    return PartialView("MisAnuncios", list);

                case "editarPerfil":


                default:
                    break;
            }
            return PartialView();
        }

        public string EliminarAnuncio(int id)
        {
            Anuncio a = getAnuncioAborrar(id);
            //comprobar que no está en reservas
            if ( estaReservado(a) )
            {

            }

        }
        #region "acceso a datos"

        private List<Mensaje> getMensajesUsuario(Usuario u)
        {
            using (OperacionesBDController db = new OperacionesBDController())
            {
                return db.getMensajesUsuario(u);
            }
        }

        public List<Anuncio> getAnunciosSubidos(Usuario u)
        {
            using (OperacionesBDController db = new OperacionesBDController())
            {
                return db.getAnunciosSubidos(u);
            }

        }
        public Anuncio getAnuncioAborrar(int idAnuncio)
        {
            using (OperacionesBDController db = new OperacionesBDController())
            {
                return db.getAnuncioAborrar(idAnuncio);
            }

        }
        public bool estaReservado(Anuncio a)
        {
            using (OperacionesBDController db = new OperacionesBDController())
            {
                return db.estaReservado(a);
            }
        }

        #endregion
        //Perfil/Anuncios
        //Perfil/Reservas...
    }
}