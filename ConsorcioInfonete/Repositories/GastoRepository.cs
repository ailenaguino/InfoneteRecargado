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

        public override void Modificar(Gasto m)
        {
            throw new NotImplementedException();
        }
    }
}
