using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Proyecto_AirBnb.Models;
namespace Proyecto_AirBnb.Filtros
{
    public class RefrescaMensajes : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
            {
                Usuario conectado = (Usuario)HttpContext.Current.Session["usuario"];
                if (conectado != null)
                {

                    int mensajes = db.Mensajes.Where(m => m.Id_Destinatario == conectado.Id && m.Leido == false).ToList().Count;
                    Usuario user = db.Usuarios.Where(u => u.Id == conectado.Id).Single();
                    HttpContext.Current.Session["mensajes"] = mensajes;
                    HttpContext.Current.Session["usuario"] = user; //refresco usuario de paso...para el SALDO
                }
            }
        }

    }
}