using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;

namespace Web.Models
{
    public class GastoVM
    {
       
        [Required(ErrorMessage = "Ingrese un nombre")]
        public string Nombre { get; set; } = string.Empty;       
        
        [Required(ErrorMessage = "Ingrese una fecha")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Ingrese un año")]
        public int AnioExpensa { get; set; }
        [Required(ErrorMessage = "Ingrese un mes")]
        public int MesExpensa { get; set; }

        [Required(ErrorMessage = "Ingrese un monto")]
        public Decimal Monto { get; set; }
        public int idConsorcio { get; set; }
        public int idTipoGasto { get; set; }
        public int idUsuario { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        // public File ArchivoComprobante=new File();




    }
}