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

}