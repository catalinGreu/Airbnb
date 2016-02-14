using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_AirBnb.Models
{
    public class CreaAnuncioViewModel
    {
        [Required(ErrorMessage ="Selecciona tipo de alojamiento")]
        [Display(Name = "Tipo de alojamiento")]
        public string Alojamiento { get; set; }
        [Required(ErrorMessage ="Selecciona tipo de habitación")]
        [Display(Name = "Tipo de habitación")]
        public string Habitacion { get; set; }
        [Required(ErrorMessage ="Selecciona capacidad")]
        [Display(Name = "Capacidad")]
        [Range(1,16,ErrorMessage = "Huéspedes entre 1 y 16")]
        public int Capacidad { get; set; }
        [Required(ErrorMessage ="Escoge ciudad")]
        [Display(Name = "Ciudad")]
        public string Ciudad { get; set; } 
        public List<string> Alojamientos { get; set; }
        public List<string> Habitaciones { get; set; }

    }

    //hacer otro que sea: Completa Anuncio
    public class CompletaAnuncioViewModel
    {
        [Required(ErrorMessage = "Escribe un título")]
        [Display(Name = "Titulo")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Describe tu anuncio")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Pónle precio a tu anuncio")]
        [Display(Name = "Precio")]
        public int Precio { get; set; }
        [Required(ErrorMessage = "Sube una foto")]
        [Display(Name = "Foto")]
        public HttpPostedFileBase Foto { get; set; }
    }

    public class BuscaAnuncioViewModel
    {
        public string Sitio { get; set; } // A dónde quieres ir?
        public string Huespedes { get; set; } // Cuántos sois?
       // [DataType(DataType.Date)]
        public string Llegada { get; set; }//Cuándo llegáis?
        //[DataType(DataType.Date)]
        public string Salida { get; set; } //Cuándo os piráis?
    }

}