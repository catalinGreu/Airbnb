using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_AirBnb.Models
{
    public class RegistroViewModel
    {

        // Modelo que le paso ala Vista Registro
        //----> Para posteriormente cargar las propiedades de DataContextUsuario
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Correo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Fecha de Nacimiento")]
        public DateTime Nacimiento { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "La {0} debe tener al menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar password")]
        [Compare("Password", ErrorMessage = "Las passwords no coinciden.")]
        public string ConfirmPassword { get; set; }
    }

    // Modelo que paso a la Vista Login para que cree los campos
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    //meteré tambien un RegistroAnfitrión
    // o tambien PublicarAnuncio...
}