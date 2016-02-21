using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_AirBnb.Models;
using System.Threading.Tasks;
using Proyecto_AirBnb.Filtros;
namespace Proyecto_AirBnb.Controllers
{

    public class InicioController : Controller
    {

        // GET: Inicio
        [RefrescaMensajes]
        public ActionResult Index(Usuario u)
        {
            return View(u);
        }



        [HttpPost]
        public PartialViewResult BuscarAnuncio(BuscaAnuncioViewModel model)//--> formato JSON
        {
            //a tomar por culo!!!!!!!!!!!---------> El datePicker esta en formato mm/dd/yyyy y no me funcionaba al cambiarlo
            // tampoco me cogia el parse aqui al cambiarle de formato con IFormat....

            string mmL = model.Llegada.Split('/')[0]; //--> mm llegada
            string ddL = model.Llegada.Split('/')[1]; //--> dd llegada
            string yyL = model.Llegada.Split('/')[2];// --> yy Llegada

            string mmS = model.Salida.Split('/')[0];//--> mm Salida
            string ddS = model.Salida.Split('/')[1];//--> dd Salida
            string yyS = model.Salida.Split('/')[2];//--> yy Salida

            DateTime llegada = DateTime.Parse(ddL + "/" + mmL + "/" + yyL);
            DateTime salida = DateTime.Parse(ddS + "/" + mmS + "/" + yyS);
            TimeSpan resta = salida.Subtract(llegada);
            if (resta.Days < 0 || resta.Days == 0)
            {
                return PartialView("ListarAnuncios", null);
            }

            Session["noches"] = resta.Days;

            List<Anuncio> lista = getAnuncios(model);

            return PartialView("ListarAnuncios", lista);
        }

        [HttpPost]
        public ActionResult GetLocalidades()
        {
            string[] locs = Locs();
            return Json(locs);
        }
        public string[] Locs()
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
            {
                
                return db.Anuncios.Select(a => a.Localidad).Distinct().ToArray();
               
            }
        }

        public List<Anuncio> getAnuncios(BuscaAnuncioViewModel modelo)
        {
            using (MiDataBaseDataContext db = new MiDataBaseDataContext())
            {

                return db.Anuncios.Where(a => a.Localidad.Contains(modelo.Sitio) && a.Capacidad >= Convert.ToInt16(modelo.Huespedes)).ToList();
            }

        }
    }
}