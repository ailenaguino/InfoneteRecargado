//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Repositories.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class Gasto
    {
        public int IdGasto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdConsorcio { get; set; }
        public int IdTipoGasto { get; set; }
        public System.DateTime FechaGasto { get; set; }
        public int AnioExpensa { get; set; }
        public int MesExpensa { get; set; }
        public string ArchivoComprobante { get; set; }
        public decimal Monto { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int IdUsuarioCreador { get; set; }
    
        public virtual Consorcio Consorcio { get; set; }
        public virtual TipoGasto TipoGasto { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
