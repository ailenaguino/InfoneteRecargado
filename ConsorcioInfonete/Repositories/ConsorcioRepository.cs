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
            throw new NotImplementedException();
        }

        public List<Consorcio> ObtenerConsorciosDeUnUsuario(int id)
        {
            
            return ctx.Consorcio.Where(o => o.IdUsuarioCreador == id).ToList();
        }

    }
}
