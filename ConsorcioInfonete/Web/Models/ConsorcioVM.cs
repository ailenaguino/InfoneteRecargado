using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Web.Models
{
    public class ConsorcioVM
    {

        [Required(ErrorMessage = "Ingrese un nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese una provincia")]
        public int IdProvincia { get; set; }

        [Required(ErrorMessage = "Ingrese una ciudad")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "Ingrese una calle")]
        public string Calle { get; set; }

        [Required(ErrorMessage = "Ingrese una altura")]
        public int Altura { get; set; }

        [Required(ErrorMessage = "Ingrese un dia para la expensa")]
        [Range(1, 31)]
        public int DiaVencimientoExpensas { get; set; }

        public int IdUsuarioCreador { get; set; }
    }
}