using Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProvinciaRepository : BaseRepository<Provincia>
    {
        public ProvinciaRepository(PW3_TP_20202CEntities ctx) : base(ctx)
        {

        }

        public override void Modificar(Provincia m)
        {
            throw new NotImplementedException();
        }
    }
}
