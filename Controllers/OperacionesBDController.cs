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
        
    }
}