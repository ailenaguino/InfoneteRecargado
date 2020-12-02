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
    public class GastoVM
    {
       
        [Required(ErrorMessage = "Ingrese un nombre")]
        [StringLength(200, ErrorMessage = "El nombre del gasto no puede tener más de {1} caracteres")]
        public string Nombre { get; set; } = string.Empty;       
        
        [Required(ErrorMessage = "Ingrese una fecha")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Ingrese un año")]
        public int AnioExpensa { get; set; }

        [Required(ErrorMessage = "Ingrese un mes")]
        public int MesExpensa { get; set; }

        [Required(ErrorMessage = "Ingrese un monto")]
        [Range(1, Double.PositiveInfinity, ErrorMessage = "El monto debe ser mayor a 0")]
        public Decimal Monto { get; set; }
                       
        public HttpPostedFileBase fileComrobante { get; set; }
        public string ArchivoComprobante { get; set; }
        public int idConsorcio { get; set; }
        public int idTipoGasto { get; set; }
        public int idUsuario { get; set; }
        public int idGasto { get; set; }
        public string Descripcion { get; set; } = string.Empty;

       
        public Gasto Mapear(GastoVM gasto)
        {
            Gasto g = new Gasto()
            {        
                IdGasto=gasto.idGasto,
                IdTipoGasto = gasto.idTipoGasto,
                IdConsorcio = gasto.idConsorcio,
                IdUsuarioCreador = gasto.idUsuario,
                Nombre = gasto.Nombre,
                Descripcion = gasto.Descripcion,
                FechaGasto = gasto.Fecha,
                AnioExpensa = gasto.AnioExpensa,
                MesExpensa = gasto.MesExpensa,
                ArchivoComprobante = gasto.ArchivoComprobante,
                Monto = gasto.Monto,
                FechaCreacion = DateTime.Now
            };
            return g;
        }

        public GastoVM MapearInversa(Gasto gasto)
        {
            GastoVM g = new GastoVM()
            {
                idGasto=gasto.IdGasto,
                idUsuario = gasto.IdUsuarioCreador,
                idConsorcio = gasto.IdConsorcio,
                idTipoGasto = gasto.IdTipoGasto,
                Nombre = gasto.Nombre,
                Descripcion = gasto.Descripcion,
                Fecha = gasto.FechaGasto,
                AnioExpensa = gasto.AnioExpensa,
                MesExpensa = gasto.MesExpensa,
                ArchivoComprobante = gasto.ArchivoComprobante,
                Monto = gasto.Monto
            };
            return g;
        }

    }
}