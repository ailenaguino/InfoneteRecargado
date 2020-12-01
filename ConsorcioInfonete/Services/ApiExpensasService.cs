
using Repositories;
using Repositories.Context;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ApiExpensasService 
    {
        GastoRepository gastoRepo;
        UnidadRepository unidadRepo;
        PW3_TP_20202CEntities ctx;
        public ApiExpensasService(PW3_TP_20202CEntities contexto)
        {
            gastoRepo = new GastoRepository(contexto);
            unidadRepo = new UnidadRepository(contexto);
            ctx = contexto;
        }

        public List<Expensa> ObtenerExpensas(int idConsorcio)
        {
            var unidadesPorConsorcio = unidadRepo.ObtenerTodosConsorcio(idConsorcio);
            ObjectResult<ObtenerExpensasProc_Result> res =ctx.ObtenerExpensasProc(idConsorcio);
            List<Expensa> expensas = new List<Expensa>();
            foreach (var item in res)
            {
                
                Expensa expensa = new Expensa()
                {
                    Año=item.Anio,
                    GastoTotal= (decimal)item.GastoTotal,
                    Mes=item.Mes,
                    ExpensasPorUnidad= (decimal)item.GastoPorUnidad,
                    unidades= unidadesPorConsorcio.Count()
                };
                expensas.Add(expensa);
            }
            return expensas;
        }
    }
}
