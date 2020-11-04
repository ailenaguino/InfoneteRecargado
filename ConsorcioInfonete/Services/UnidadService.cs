using Repositories;
using Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UnidadService : BaseService<UnidadRepository, Unidad>
    {
        UnidadRepository UR;
        //ConsorcioRespository CR;

        public UnidadService(PW3_TP_20202CEntities ctx) : base(ctx)
        {
            //CR = new ConsorcioRespositoy(ctx);
        }

        public List<Unidad> ObtenerTodos(int idConsorcio)
        {
            //Consorcio c = CR.ObtenerPorId(idConsorcio);

            Consorcio c = new Consorcio() { IdConsorcio = 1 };

            return repo.ObtenerTodosConsorcio(c);
        }

        public override void Alta(Unidad u)
        {
            u.FechaCreacion = System.DateTime.Now;
            repo.Alta(u);
        }

    }
}
