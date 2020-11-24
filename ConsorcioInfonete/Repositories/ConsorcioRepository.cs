using Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ConsorcioRepository : BaseRepository<Consorcio>
    {
        public ConsorcioRepository(PW3_TP_20202CEntities contexto) : base(contexto)
        {
        }

        public override void Modificar(Consorcio m)
        {
            Consorcio consorcioActual = ObtenerPorId(m.IdConsorcio);
            consorcioActual.IdProvincia= m.IdProvincia;
            consorcioActual.Nombre = m.Nombre;
            consorcioActual.Ciudad = m.Ciudad;
            consorcioActual.Calle = m.Calle;
            consorcioActual.Altura = m.Altura;
            consorcioActual.DiaVencimientoExpensas = m.DiaVencimientoExpensas;
      

            ctx.SaveChanges();
        }

        public List<Consorcio> ObtenerConsorciosDeUnUsuario(int id)
        {
            
            return ctx.Consorcio.Where(o => o.IdUsuarioCreador == id).ToList();
        }

    }
}
