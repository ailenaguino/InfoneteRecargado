using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class UsuarioVM
    {
        [Required(ErrorMessage = "Ingrese un email")]
        public string Email { get; set; }=string.Empty;
        [Required(ErrorMessage = "Ingrese una contraseña")]
        public string Password { get; set; } = string.Empty;
    }
}