using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_AirBnb.Models;
using Proyecto_AirBnb.Filtros;
namespace Proyecto_AirBnb.Controllers
{
    //[Authorize] //---> Para todos los Action del Controller---> NO me deja pasar ni estando loggeado. Falta configuracion
    [SessionExpirada]
    public class PerfilController : Controller
    {
        UsuarioController control = new UsuarioController();
        // GET: Perfil
        [RefrescaMensajes]
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


        public ActionResult AccionReserva(string destinatario, string remitente, int idReserva, int idMensaje, string accion)
        {

            Usuario anfitrion = control.GetUserById(destinatario);
            Reserva r = GetReserva(idReserva);
            Usuario huesped = control.GetUserById(remitente);

            Anuncio a = getAnuncioById(r.Id_Anuncio);
            Mensaje m = null;

            if (accion.Equals("aceptar"))
            {
                string mensaje = huesped.Nombre + ", le comunicamos que " + anfitrion.Nombre + " ha aceptado su reserva en " + a.Localidad
                              + " durante " + r.Noches + " noches, por la cuantia de " + r.Precio
                              + "€. Ya puede proceder a realizar el pago de la reserva. Disfrute de su viaje!";

                m = new Mensaje
                {
                    Id_Destinatario = huesped.Id,
                    Id_Remitente = anfitrion.Id,//---> El 0 es el equipo
                    Fecha = DateTime.Now,
                    Mensaje1 = mensaje,
                    Leido = false,
                    Tipo = "confirmacion",
                    Id_Reserva = idReserva

                };
            }
            else if (accion.Equals("rechazar"))
            {
                string mensaje = huesped.Nombre + ", lamentamos comunicarle que " + anfitrion.Nombre + " ha rechazado su reserva en " + a.Localidad
                             + " durante " + r.Noches + " noches, por la cuantia de " + r.Precio
                             + "€ :(. NO deje de reservar con nosotros.";
                m = new Mensaje
                {
                    Id_Destinatario = huesped.Id,
                    Id_Remitente = anfitrion.Id,//---> El 0 es el equipo
                    Fecha = DateTime.Now,
                    Mensaje1 = mensaje,
                    Leido = false,
                    Tipo = "rechazo",
                    Id_Reserva = idReserva

                };
                BorrarReserva(idReserva);//solo borro reserva si el anfitrión rechaza...
            }

            MandarMensaje(m);
            BorraMensajeByIdMensaje(idMensaje);

            return RedirectToAction("PerfilUsuario", "Perfil");

        }


        public ActionResult PagarReserva(int id, int idReserva, string remitente, string destinatario)
        {
            Usuario anfitrion = control.GetUserById(remitente);
            Reserva r = GetReserva(idReserva);
            Usuario huesped = control.GetUserById(destinatario);
            Anuncio a = getAnuncioById(r.Id_Anuncio);

            ViewBag.Anfitrion = anfitrion;
            ViewBag.Huesped = huesped;
            ViewBag.Reserva = r;
            ViewBag.Anuncio = a;
            ViewBag.IdMensaje = id;

            return View();

        }
        public ActionResult GeneraPDF()
        {
            return new Rotativa.ActionAsPdf("PagarReserva");
        }
        [HttpPost]
        public void Pagar(PagoViewModel model)
        {
            //borro reserva una vez que haya pagado el Huesped.
            //guardo en tabla PagosReserva
            //Aumento saldo Anfitrion
            //mando mails de confirmacion a ambos.
            double comision = (double)model.Total * 0.2;
            int saldo = model.Total - (int)comision;
            PagosReserva pago = new PagosReserva
            {
                Id_Reserva = Convert.ToInt16(model.IdReserva),
                Id_Usuario = model.IdHuesped,
                Total = model.Total,
                Comision = (int)comision,
                NumTarjeta = model.NumTarjeta
            };

            //debería generar pdf tb!!!
            GrabaPagos(pago);
            AddSaldoToHost(model.IdAnfitrion, saldo);
            BorrarReserva( Convert.ToInt16(model.IdReserva) );

            Usuario host = control.GetUserById(model.IdAnfitrion);
            Usuario huesped = control.GetUserById(model.IdHuesped);
            string texto = host.Nombre + ", le comunicamos que " + huesped.Nombre + 
                " ya ha realizado el pago de la reserva de su anuncio, por un total de " +
                saldo + " euros. Gracias por confiar en AirBnb";

            Mensaje m = new Mensaje
            {
                Id_Destinatario = model.IdAnfitrion,
                Id_Remitente = model.IdHuesped,
                Fecha = DateTime.Now,
                Leido = false,
                Mensaje1 = texto,
                Tipo="bienvenida" //--> por no crearme oootro tipo
            };
            MandarMensaje(m);
            BorraMensajeByIdMensaje(model.IdMensaje);
            EmailController.ConfirmaReserva(host, "Confirmacion pago", texto, saldo.ToString());
            ///Y al huesped le tendria que mandar el correo con PDF;

        }



        public void DescartarReserva(int id, int idReserva, string remitente, string destinatario)//remitente es el Anfitrión que me ha contestado
        {
            Usuario host = control.GetUserById(remitente);
            Usuario huesped = control.GetUserById(destinatario);
            Reserva r = GetReserva(idReserva);
            Anuncio a = getAnuncioById(r.Id_Anuncio);
            string texto = host.Nombre + ", le comunicamos que " + huesped.Nombre +
                " ha decidido cancelar el pago de la reserva de su anuncio en " + a.Localidad;

            Mensaje m = new Mensaje
            {
                Id_Destinatario = host.Id,
                Id_Remitente = huesped.Id,
                Fecha = DateTime.Now,
                Leido = false,
                Mensaje1=texto,
                Tipo = "bienvenida" //--> por no crearme oootro tipo
            };
            MandarMensaje(m);
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
        private List<Anuncio> getReservas(Usuario u)
        {
            return OperacionesBDController.GetReservas(u);
        }
        private void BorrarReserva(int idReserva)
        {
            OperacionesBDController.BorrarReserva(idReserva);
        }
        private Reserva GetReserva(int IdReserva)
        {
            return OperacionesBDController.GetReserva(IdReserva);
        }

        private List<Mensaje> getMensajesUsuario(Usuario u)
        {

            return OperacionesBDController.getMensajesUsuario(u);
        }

        private List<Anuncio> getAnunciosSubidos(Usuario u)
        {

            return OperacionesBDController.getAnunciosSubidos(u);

        }
        private Anuncio getAnuncioById(int idAnuncio)
        {

            return OperacionesBDController.GetAnuncio(idAnuncio);

        }
        private bool estaReservado(Anuncio a)
        {
            return OperacionesBDController.estaReservado(a);
        }

        private void BorraAnuncio(Anuncio a)
        {
            OperacionesBDController.BorraAnuncio(a);
        }
        private int MarcarLeido(int idMensaje, Usuario u)
        {
            return OperacionesBDController.MarcarLeido(idMensaje, u);
        }
        private void MandarMensaje(Mensaje m)
        {
            OperacionesBDController.MandarMensaje(m);
        }
        private void BorraMensajeByIdMensaje(int idMensaje)
        {
            OperacionesBDController.BorrarMensaje(idMensaje);
        }
        private void GrabaPagos(PagosReserva pr)
        {
            OperacionesBDController.GrabarPago(pr);
        }
        private void AddSaldoToHost(string idAnfitrion, int saldo)
        {
            OperacionesBDController.AddSaldoToAnfitrion(idAnfitrion, saldo);
        }
        #endregion
        //Perfil/Reservas...

    }
}