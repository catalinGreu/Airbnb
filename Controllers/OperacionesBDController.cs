using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_AirBnb.Models;
namespace Proyecto_AirBnb.Controllers
{

    public class OperacionesBDController : Controller
    {
        MiDataBaseDataContext db = new MiDataBaseDataContext();
        public void GrabaUser(Usuario u)
        {
            db.Usuarios.InsertOnSubmit(u);

            try
            {
                db.SubmitChanges();
            }
            catch (Exception)
            {
            }

        }

        public string GetIdByCorreo(string email)
        {
            try
            {
                return (from user in db.Usuarios
                        where user.Correo == email
                        select user.Id).Single();
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public bool ExisteUsuario(string hash, string email) //aqui compruebo solo con el hash
        {
            bool existe = (from usu in db.Usuarios
                           where usu.Correo == email
                           select Convert.ToString(usu.Hash) == hash).Single();
            return existe;

        }

        public List<Mensaje> getMensajesUsuario(Usuario u)
        {
            return db.Mensajes.Where(m => m.Id_Destinatario == u.Id && m.Leido == false).ToList();
        }

        public Usuario GetUserById(string id)
        {
            return (from usu in db.Usuarios
                    where usu.Id == id
                    select usu).Single();
        }

        public Usuario SetNombreFoto(string id, string path)
        {
            Usuario ret = (db.Usuarios.Where(u => u.Id.Equals(id))).Single();

            ret.Foto = path;

            db.SubmitChanges();
            return ret;
        }

        public List<Anuncio> getAnunciosSubidos(Usuario u)
        {
            return db.Anuncios.Where(a => a.Id_Anfitrion == u.Id).ToList();
        }

        public Anuncio getAnuncioAborrar(int idAnuncio)
        {
            return db.Anuncios.Where(a => a.Id_Anuncio == idAnuncio).Single();
        }

        public void SetAnfitrion(string idUser)
        {
            db.Usuarios.Where(u => u.Id == idUser).ToList().ForEach(x => x.Anfitrion = true);
            db.SubmitChanges();


        }

        public bool estaReservado(Anuncio a)
        {
            return (from res in db.Reservas
                    where res.Id_Anuncio == a.Id_Anuncio
                    select true).Single();
        }

        public void MandarMensaje(Usuario u)
        {
            string mensaje = u.Nombre + ", el equipo de AirBnb le da la bienvenida. " +
                                    " Gracias por registrarse con nosotros.";
            Mensaje m = new Mensaje
            {
                Id_Destinatario = u.Id,
                Id_Remitente = "0",//---> El 0 es el equipo
                Fecha = DateTime.Now,
                Mensaje1 = mensaje,
                Leido = false

            };
            db.Mensajes.InsertOnSubmit(m);
            db.SubmitChanges();
        }

        public void GrabaAnuncio(Anuncio a)
        {
            db.Anuncios.InsertOnSubmit(a);
            db.SubmitChanges();
        }

        public int GetMensajes(string elID) //los NO leidos
        {
            return db.Mensajes.Where(m => m.Id_Destinatario == elID && m.Leido == false).Count();
        }

        public Anuncio getAnuncioById(int id)
        {
            return db.Anuncios.Where(a => a.Id_Anuncio == id).Single();
        }

        public bool GrabaReserva(Reserva r)
        {
            if (existeReserva(r))
            {
                return false;
            }
            db.Reservas.InsertOnSubmit(r);
            db.SubmitChanges();
            return true;
        }
        private bool existeReserva(Reserva r)
        {
            bool existe = (from res in db.Reservas
                    where res.Id_Huesped == r.Id_Huesped &&
                   res.Id_Anuncio == r.Id_Anuncio
                    select true).Single();
            return existe;
        }

        public string getIdAnfitrion(int id) //--> ID del Anuncio
        {
            return (from a in db.Anuncios
                    where a.Id_Anuncio == id
                    select a.Id_Anfitrion).Single();
        }

        public void MandaNotificacionReserva(Mensaje m)
        {
            db.Mensajes.InsertOnSubmit(m);
            db.SubmitChanges();
        }
    }
}