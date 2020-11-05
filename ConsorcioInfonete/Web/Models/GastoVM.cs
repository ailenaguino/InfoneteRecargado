﻿using Repositories.Context;
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
        public int idGasto { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string ArchivoComprobante { get; set; }

        public Gasto Mapear(int idusuario, GastoVM gasto)
        {
            Gasto g = new Gasto()
            {
                Nombre = gasto.Nombre,
                IdGasto=gasto.idGasto,
                Descripcion = gasto.Descripcion,
                IdConsorcio = gasto.idConsorcio,
                IdTipoGasto = gasto.idTipoGasto,
                FechaGasto = gasto.Fecha,
                AnioExpensa = gasto.AnioExpensa,
                MesExpensa = gasto.MesExpensa,
                ArchivoComprobante = "",
                Monto = gasto.Monto,
                FechaCreacion = DateTime.Now,
                IdUsuarioCreador = idusuario
            };
            return g;
        }

        public GastoVM MapearInversa(Gasto gasto)
        {
            GastoVM g = new GastoVM()
            {
                idGasto=gasto.IdGasto,
                Nombre = gasto.Nombre,
                Descripcion = gasto.Descripcion,
                idConsorcio = gasto.IdConsorcio,
                idTipoGasto = gasto.IdTipoGasto,
                Fecha = gasto.FechaGasto,
                AnioExpensa = gasto.AnioExpensa,
                MesExpensa = gasto.MesExpensa,
                ArchivoComprobante = "",
                Monto = gasto.Monto,
                idUsuario = gasto.IdUsuarioCreador
            };
            return g;
        }

    }
}