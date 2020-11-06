using Repositories;
using Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class GastoService:BaseService<GastoRepository,Gasto>
    {
        GastoRepository repo;
        public GastoService(PW3_TP_20202CEntities ctx):base(ctx)
        {
            repo = new GastoRepository(ctx);
        }

        public List<Gasto> ObtenerGastoPorConsorcio(int c)
        {
            return repo.ObtenerGastoPorConsorcio(c);        
        }
        
    }
}
