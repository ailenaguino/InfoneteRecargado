using Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UnidadRepository : BaseRepository<Unidad>
    {

        public UnidadRepository(PW3_TP_20202CEntities ctx) : base(ctx) { }

        public List<Unidad> ObtenerTodosConsorcio(Consorcio c)
        {
            return (from u in ctx.Unidad
                 where u.IdConsorcio == c.IdConsorcio
                 orderby u.IdUnidad descending
                 select u).ToList();

        }

        public override void Modificar(Unidad m)
        {
            Unidad u = ObtenerPorId(m.IdUnidad);
            u.Nombre = m.Nombre;
            u.NombrePropietario = m.NombrePropietario;
            u.ApellidoPropietario = m.ApellidoPropietario;
            u.EmailPropietario = m.EmailPropietario;
            u.Superficie = m.Superficie;

            ctx.SaveChanges();
        }
    }
}
