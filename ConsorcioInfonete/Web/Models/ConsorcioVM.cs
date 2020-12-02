using Repositories.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;



namespace Web.Models
{
    public class ConsorcioVM
    {

        [Required(ErrorMessage = "Ingrese un nombre")]
        [StringLength(200, ErrorMessage = "El nombre del consorcio no puede tener más de {1} caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ingrese una provincia")]
        public int IdProvincia { get; set; }

        [Required(ErrorMessage = "Ingrese una ciudad")]
        [StringLength(200, ErrorMessage = "El nombre de la ciudad no puede tener más de {1} caracteres")]
        public string Ciudad { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ingrese una calle")]
        [StringLength(200, ErrorMessage = "El nombre de la calle no puede tener más de {1} caracteres")]
        public string Calle { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ingrese una altura")]
        public int Altura { get; set; }

        [Required(ErrorMessage = "Ingrese un dia para la expensa")]
        [Range(1, 28, ErrorMessage = "El dia de vencimiento de las expensas debe ser del 1 al 28")]
        public int DiaVencimientoExpensas { get; set; } 

        public int IdConsorcio { get; set; }

        public int IdUsuarioCreador { get; set; }

        public Consorcio Mapear(ConsorcioVM consorcio)
        {
            Consorcio cons = new Consorcio()
            {
                IdConsorcio = consorcio.IdConsorcio,
                Nombre = consorcio.Nombre,
                IdProvincia = consorcio.IdProvincia,
                Ciudad = consorcio.Ciudad,
                Calle = consorcio.Calle,
                Altura = consorcio.Altura,
                DiaVencimientoExpensas = consorcio.DiaVencimientoExpensas,
                FechaCreacion = DateTime.Now,
                IdUsuarioCreador = consorcio.IdUsuarioCreador,
            };
            return cons;
        }
    }
}