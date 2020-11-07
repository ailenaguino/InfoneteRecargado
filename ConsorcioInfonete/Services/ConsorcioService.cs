using Repositories.Context;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ConsorcioService : BaseService<ConsorcioRepository, Consorcio>
    {
        ConsorcioRepository repo;
        public ConsorcioService(PW3_TP_20202CEntities contexto) : base(contexto)
        {
            repo = new ConsorcioRepository(contexto);
        }
        public List<Consorcio> ObtenerConsorciosDeUnUsuario(int id)
        {
            
            return repo.ObtenerConsorciosDeUnUsuario(id);
        }
    }
}
