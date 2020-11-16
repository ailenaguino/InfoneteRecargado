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
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ingrese una provincia")]
        public int IdProvincia { get; set; }

        [Required(ErrorMessage = "Ingrese una ciudad")]
        public string Ciudad { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ingrese una calle")]
        public string Calle { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ingrese una altura")]
        public int Altura { get; set; }

        [Required(ErrorMessage = "Ingrese un dia para la expensa")]
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