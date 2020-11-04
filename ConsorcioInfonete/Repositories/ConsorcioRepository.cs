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
    }
}
