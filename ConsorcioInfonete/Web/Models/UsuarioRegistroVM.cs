using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class UsuarioRegistroVM
    {
        [Required(ErrorMessage = "Ingrese un email")]
        [EmailAddress(ErrorMessage = "Formato de Email invalido")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Ingrese una contraseña")]
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "Ingrese una contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas deben coincidir")]
        public string PasswordRepeated { get; set; } = string.Empty;
    }
}