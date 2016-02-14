using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_AirBnb.Models;
using System.Threading.Tasks;

namespace Proyecto_AirBnb.Controllers
{
    
    public class InicioController : Controller
    {
        MiDataBaseDataContext db = new MiDataBaseDataContext();

        // GET: Inicio
        public ActionResult Index(Usuario u)
        {            
            return View(u);
        }

        
       
        [HttpPost]
        public ActionResult BuscarAnuncio(BuscaAnuncioViewModel model)
        {
            //a tomar por culo!!!!!!!!!!!---------> El datePicker esta en formato mm/dd/yyyy y no me funcionaba al cambiarlo
            // tampoco me cogia el parse aqui al cambiarle de formato con IFormat....

            string ddL = model.Llegada.Split('/')[1]; //--> dd llegada
            string mmL = model.Llegada.Split('/')[0]; //--> mm llegada
            string yyL = model.Llegada.Split('/')[2];// --> yy Llegada

            string ddS = model.Salida.Split('/')[1];//--> dd Salida
            string mmS = model.Llegada.Split('/')[0];//--> mm Salida
            string yyS = model.Llegada.Split('/')[2];//--> yy Salida

            DateTime llegada = DateTime.Parse( ddL +"/" + mmL + "/" + yyL) ;
            DateTime salida = DateTime.Parse( ddS + "/" + mmS + "/" +yyS);
            TimeSpan days = salida.Subtract(llegada);


            List<Anuncio> lista = getAnuncios(model);

            // 1.Llamo a controlador de anuncios
            // 2. Busco lista de anuncios con esa búsqueda
            // 3. Devuelvo la lista aquí y se la paso a la vista BuscaAnuncio, que cargará PartialViews de ese List<Anuncios>

            TempData["lista"] = lista;
            return RedirectToAction("ListarAnuncios", "Anuncios");
        }


        public List<Anuncio> getAnuncios(BuscaAnuncioViewModel modelo)
        {
           
            return db.Anuncios.Where(a => a.Localidad.Contains(modelo.Sitio) && a.Capacidad >= Convert.ToInt16(modelo.Huespedes) ).ToList();

        }
    }
}