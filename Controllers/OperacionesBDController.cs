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
        //esto es una prueba FALTA HASHEAR Y GENERAR ID!!!!
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
            catch (Exception)
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
        public Usuario GetUserById(string id)
        {
            return (from usu in db.Usuarios
                    where usu.Id == id
                    select usu).Single();
        }

        public Usuario SetNombreFoto(string id, string path)
        {
            Usuario ret = ( db.Usuarios.Where(u => u.Id.Equals(id))).Single();

            ret.Foto = path;
           
            db.SubmitChanges();
            return ret;
        }

        public void SetAnfitrion(string idUser)
        {
            db.Usuarios.Where(u => u.Id == idUser).ToList().ForEach(x => x.Anfitrion = true);
            db.SubmitChanges();
            
            
        }

        public void GrabaAnuncio(Anuncio a)
        {
            db.Anuncios.InsertOnSubmit(a);
            db.SubmitChanges();
        }
    }
}