using Repositories;
using Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProvinciaService : BaseService<ProvinciaRepository, Provincia>
    {
        public ProvinciaService(PW3_TP_20202CEntities ctx) : base(ctx)
        {

        }
    }
}
