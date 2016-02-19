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
        UsuarioController control = new UsuarioController();
        // GET: Perfil
        public ActionResult PerfilUsuario()
        {

            ViewBag.Error = "Faltan Campos";
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
                    EditUserViewModel edit = new EditUserViewModel { Nombre = conectado.Nombre, Apellido = conectado.Apellido, Correo = conectado.Correo };
                    return PartialView("EditarPerfil", edit);
                case "reservas":
                    List<Anuncio> reservas = getReservas(conectado);//en realidad cojo Anuncios, reservados por ese usuario
                    return PartialView("MisReservas", reservas);
                case "password":
                    ChangePassViewModel model = new ChangePassViewModel();
                    return PartialView("ChangePasswd", model);
                default:
                    break;
            }
            return PartialView();
        }

        public void AceptarReserva(string destinatario, string remitente, int? idReserva)//remitente es Anfitrión
        {
            //mensaje a Huesped (id huesped de id reserva)
            //mando datos del Anfitrión y del Anuncio.
            //Avisar de realizar pago

            //borro reserva, borro mensaje de reserva
            Usuario anfitrion = control.GetUserById(destinatario);
            Reserva r = GetReserva( (int)idReserva);
            Usuario huesped = control.GetUserById(r.Id_Huesped);

            Anuncio a = getAnuncioById(r.Id_Anuncio);

            string mensaje = huesped.Nombre + ", le comunicamos que "+anfitrion.Nombre+" ha aceptado su reserva en "+a.Localidad
                              +" durante " + r.Noches + " noches, por la cuantia de "+r.Precio
                              + "€. Ya puede proceder a realizar el pago de la reserva. Disfrute de su viaje!";
            MandarMensaje(mensaje, huesped.Id, anfitrion.Id,r.Id_Reserva);
            BorraMensajeByIdReserva(r.Id_Reserva);
            BorrarReserva(r.Id_Reserva);
            
            
        }
        public void RechazarReserva(string remitente, int idReserva)
        {

        }

        [HttpPost]
        public string EditarPerfil(EditUserViewModel model, HttpPostedFileBase foto)
        {

            if (ModelState.IsValid)
            {
                Usuario actual = (Usuario)Session["usuario"];
                actual.Nombre = model.Nombre;
                actual.Apellido = model.Apellido;

                if (foto != null)
                {
                    if (actual.Foto != null)
                    {

                        DeleteFile("/Perfil/" + actual.Foto);//borramos su foto antigua
                    }
                    actual.Foto = actual.Id + foto.FileName;
                    FileUpload(foto, actual);
                }
                control.UpdateUser(actual);

                return ("<script>alert('Cambios realizados con éxito');" +
                        "window.location.assign('http://localhost:17204/Perfil/PerfilUsuario');" +
                    "</script>");

            }
            return ("<script>alert('No puede haber campos vacíos');" +
                         "window.location.assign('http://localhost:17204/Perfil/PerfilUsuario');" +
                     "</script>");
        }

        public string EliminarAnuncio(int? id)
        {
            Anuncio a = getAnuncioById((int)id);
            //comprobar que no está en reservas
            if (estaReservado(a))
            {
                return ("<script>alert('El anuncio está reservado. NO se puede borrar');" +
                        "window.location.assign('http://localhost:17204/Perfil/PerfilUsuario?op=misAnuncios');" +
                    "</script>");
            }
            else
            {
                BorraAnuncio(a);
                DeleteFile("/Anuncios/" + a.Foto);
                return ("<script>alert('Anuncio borrado con éxito.');" +
                       "window.location.assign('http://localhost:17204/Perfil/PerfilUsuario?op=misAnuncios');" +
                   "</script>");
            }

        }
        public string MensajeLeido(int? id)
        {
            Usuario queUsu = (Usuario)Session["usuario"];

            int mensajesSinLeer = MarcarLeido((int)id, queUsu); //--> volvemos a meter en la Session
            Session["mensajes"] = mensajesSinLeer;
            return ("<script>window.location.assign('http://localhost:17204/Perfil/PerfilUsuario?op=mensajes');" +
                   "</script>");
        }
        public string EliminarMensaje(int? id)
        {
            control.EliminaMensaje((int)id);
            return ("<script>window.location.assign('http://localhost:17204/Perfil/PerfilUsuario?op=mensajes');" +
                   "</script>");
        }

        [HttpPost]
        public string ChangePasswd(ChangePassViewModel model)
        {
            if (ModelState.IsValid)
            {
                Usuario u = (Usuario)Session["usuario"];
                string id = u.Id;
                string hash = control.Hashea(id, model.OldPassword);

                //comprobamos si la pass antigua esta ok
                if (control.ExisteUsuario(hash, u.Correo))
                {
                    string newHash = control.Hashea(id, model.NewPass);
                    control.UpdateHash(id, newHash);

                    Session["usuario"] = null;
                    return ("<script>alert('Contraseña cambiada con éxito');" +
                        "window.location.assign('http://localhost:17204/Inicio/Index');" +
                    "</script>");
                    //le cambiamos la pass
                }
            }
            return ("<script>alert('Datos erróneos. Compruebe que la contraseña antigua sea la misma o la nueva coincida en ambos campos');" +
                       "window.location.assign('http://localhost:17204/Perfil/PerfilUsuario?op=password');" +
                   "</script>");
        }
        public void FileUpload(HttpPostedFileBase file, Usuario u) // ---> subo Upload
        {

            string pic = System.IO.Path.GetFileName(u.Id + file.FileName);
            string path = System.IO.Path.Combine(Server.MapPath("~/Content/Imagenes/Perfil"), pic);

            file.SaveAs(path);


        }
        public void DeleteFile(string file)
        {
            string fullPath = Request.MapPath("~/Content/Imagenes/" + file);

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }

        }
        #region "acceso a datos"
        public List<Anuncio> getReservas(Usuario u)
        {
            return OperacionesBDController.GetReservas(u);
        }
        public void BorrarReserva( int idReserva)
        {
            OperacionesBDController.BorrarReserva(idReserva);
        }
        public Reserva GetReserva(int IdReserva)
        {
            return OperacionesBDController.GetReserva(IdReserva);
        }

        private List<Mensaje> getMensajesUsuario(Usuario u)
        {

            return OperacionesBDController.getMensajesUsuario(u);
        }

        public List<Anuncio> getAnunciosSubidos(Usuario u)
        {

            return OperacionesBDController.getAnunciosSubidos(u);

        }
        public Anuncio getAnuncioById(int idAnuncio)
        {

            return OperacionesBDController.GetAnuncio(idAnuncio);

        }
        public bool estaReservado(Anuncio a)
        {
            return OperacionesBDController.estaReservado(a);
        }

        public void BorraAnuncio(Anuncio a)
        {
            OperacionesBDController.BorraAnuncio(a);
        }
        public int MarcarLeido(int idMensaje, Usuario u)
        {
            return OperacionesBDController.MarcarLeido(idMensaje, u);
        }
        public void MandarMensaje(string destino, string remitente, string mensaje, int idReserva)
        {
            OperacionesBDController.MandarMensajeConfirmacion(destino, remitente, mensaje, idReserva);
        }
        public void BorraMensajeByIdReserva(int idReserva)
        {
            OperacionesBDController.BorrarMensaje(idReserva);
        }
        #endregion
        //Perfil/Reservas...

    }
}