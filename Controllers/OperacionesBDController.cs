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
        public static void GrabaUser(Usuario u)
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
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

        }

        public static string GetIdByCorreo(string email)
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
            {
                try
                {
                    return db.Usuarios.Where(u => u.Correo == email).Single().Id;

                }
                catch (Exception e)
                {
                    return null;
                }
            }

        }
        public static bool ExisteUsuario(string hash, string email) //aqui compruebo solo con el hash
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
            {
                bool existe = (from usu in db.Usuarios
                               where usu.Correo == email
                               select Convert.ToString(usu.Hash) == hash).Single();
                return existe;
            }

        }

        public static List<Mensaje> getMensajesUsuario(Usuario u)
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
            {
                return db.Mensajes.Where(m => m.Id_Destinatario == u.Id).ToList();
            }
        }

        public static bool ExisteMail(string correo)
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
            {

                return (from user in db.Usuarios
                               where user.Correo == correo
                               select true).SingleOrDefault();
            }
        }

        public static Usuario GetUserById(string id)
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
            {
                return db.Usuarios.Where(u => u.Id == id).Single();
            }

        }

        public static Usuario SetNombreFoto(string id, string path)
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
            {
                Usuario ret = (db.Usuarios.Where(u => u.Id.Equals(id))).Single();

                ret.Foto = path;

                db.SubmitChanges();
                return ret;
            }
        }

        public static List<Anuncio> getAnunciosSubidos(Usuario u)
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
            {
                return db.Anuncios.Where(a => a.Id_Anfitrion == u.Id).ToList();
            }
        }

        public static Anuncio GetAnuncio(int idAnuncio)
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
            {
                return db.Anuncios.Where(a => a.Id_Anuncio == idAnuncio).Single();
            }
        }

        public static void SetAnfitrion(string idUser)
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
            {
                db.Usuarios.Where(u => u.Id == idUser).ToList().ForEach(x => x.Anfitrion = true);
                db.SubmitChanges();
            }


        }

        public static bool estaReservado(Anuncio a)
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
            {
                return (from res in db.Reservas
                        where res.Id_Anuncio == a.Id_Anuncio
                        select true).SingleOrDefault();
            }
        }

        public static Anuncio GetAnuncioByReserva(Reserva r)
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
            {
                return db.Anuncios.Where(a => a.Id_Anuncio == r.Id_Anuncio).Single();
            }

        }

        public static void DeleteMensaje(int id)
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
            {
                Mensaje delete = db.Mensajes.Where(m => m.Id_Mensaje == id).Single();

                db.Mensajes.DeleteOnSubmit(delete);
                db.SubmitChanges();

            }
        }
       

        public static void BorraAnuncio(Anuncio a)
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
            {
                Anuncio borrar = db.Anuncios.Where(an => an.Id_Anuncio == a.Id_Anuncio).Single();
                db.Anuncios.DeleteOnSubmit(borrar);
                db.SubmitChanges();

            }
        }

        public static int MarcarLeido(int idMensaje, Usuario u)
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
            {
                db.Mensajes.Where(m => m.Id_Mensaje == idMensaje).Single().Leido = true;

                db.SubmitChanges();
                return GetMensajes(u.Id);
            }


        }

        public static void GrabaAnuncio(Anuncio a)
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
            {
                db.Anuncios.InsertOnSubmit(a);
                db.SubmitChanges();
            }
        }

        public static int GetMensajes(string elID) //los NO leidos
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
            {
                return db.Mensajes.Where(m => m.Id_Destinatario == elID && m.Leido == false).Count();
            }
        }

        public static Anuncio getAnuncioById(int id)
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
            {
                return db.Anuncios.Where(a => a.Id_Anuncio == id).Single();
            }
        }

        public static bool GrabaReserva(Reserva r)
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
            {
                if (existeReserva(r))
                {
                    return false;
                }
                db.Reservas.InsertOnSubmit(r);
                db.SubmitChanges();
                return true;
            }
        }

        public static Reserva GetReserva(int idReserva)
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
            {
                return db.Reservas.Where(r => r.Id_Reserva == idReserva).Single();
            }
        }

        public static void UpdateHash(string id, string hash)
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
            {
                db.Usuarios.Where(usu => usu.Id == id).Single().Hash = hash;
                db.SubmitChanges();
            }
        }

        public static void BorrarReserva(int idReserva)
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
            {
                db.Reservas.DeleteOnSubmit(db.Reservas.Where(r => r.Id_Reserva == idReserva).Single());
            }
        }

        private static bool existeReserva(Reserva r)
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
            {
                bool existe = (from res in db.Reservas
                               where res.Id_Huesped == r.Id_Huesped &&
                              res.Id_Anuncio == r.Id_Anuncio
                               select true).SingleOrDefault();
                return existe;
            }
        }

        public static string getIdAnfitrion(int id) //--> ID del Anuncio
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
            {
                return (from a in db.Anuncios
                        where a.Id_Anuncio == id
                        select a.Id_Anfitrion).Single();
            }
        }


        public static void MandarMensaje(Mensaje m)
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
            {               
                db.Mensajes.InsertOnSubmit(m);
                db.SubmitChanges();
            }
        }

        public static void BorrarMensaje(int IdMensaje)
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
            {
                db.Mensajes.DeleteOnSubmit(db.Mensajes.Where(m => m.Id_Mensaje == IdMensaje).Single());
                db.SubmitChanges();
            }
            

        }

        public static List<Anuncio> GetReservas(Usuario u)
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
            {
                List<Anuncio> anunciosReservados = new List<Anuncio>();
                List<Reserva> reservas = db.Reservas.Where(r => r.Id_Huesped == u.Id).ToList();

                foreach (Reserva r in reservas)
                {
                    anunciosReservados.Add(db.Anuncios.Where(a => a.Id_Anuncio == r.Id_Anuncio).Single());
                }
                return anunciosReservados;
            }

        }

        public static void UpdateUser(Usuario nuevo)
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
            {
                Usuario viejo = db.Usuarios.Where(usu => usu.Id == nuevo.Id).Single();

                viejo.Nombre = nuevo.Nombre;
                viejo.Apellido = nuevo.Apellido;
                viejo.Correo = nuevo.Correo;
                viejo.Foto = nuevo.Foto;

                db.SubmitChanges();

            }

        }
    }
}