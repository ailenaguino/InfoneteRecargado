using Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class GastoRepository : BaseRepository<Gasto>
    {
        public GastoRepository(PW3_TP_20202CEntities contexto):base(contexto)
        {

        }

        public override void Modificar(Gasto g)
        {
            Gasto gastoActual = ObtenerPorId(g.IdGasto);
            gastoActual.IdTipoGasto = g.IdTipoGasto;
            gastoActual.Nombre = g.Nombre;
            gastoActual.Descripcion = g.Descripcion;
            gastoActual.FechaGasto = g.FechaGasto;
            gastoActual.AnioExpensa = g.AnioExpensa;
            gastoActual.MesExpensa = g.MesExpensa;
            gastoActual.ArchivoComprobante = g.ArchivoComprobante;
            gastoActual.Monto = g.Monto;

            ctx.SaveChanges();
        }
    }
}
