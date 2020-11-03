using Repositories;
using Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UnidadService
    {
        UnidadRepository UR;
        //ConsorcioRespository CR;

        public UnidadService(PW3_TP_20202CEntities ctx)
        {
            UR = new UnidadRepository(ctx);
            //CR = new ConsorcioRespositoy(ctx);
        }

        public List<Unidad> ObtenerTodos(int idConsorcio)
        {
            //Consorcio c = CR.ObtenerPorId(idConsorcio);

            Consorcio c = new Consorcio() { IdConsorcio = 5 };

            return UR.ObtenerTodosConsorcio(c);
        }

        public void Alta(Unidad u)
        {
            u.FechaCreacion = System.DateTime.Now;
            UR.Alta(u);
        }

    }
}
