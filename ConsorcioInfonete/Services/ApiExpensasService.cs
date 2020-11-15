using Common;
using Repositories;
using Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ApiExpensasService 
    {
        GastoRepository gastoRepo;
        UnidadRepository unidadRepo;

        public ApiExpensasService(PW3_TP_20202CEntities contexto)
        {
            gastoRepo = new GastoRepository(contexto);
            unidadRepo = new UnidadRepository(contexto);
        }

        public List<Expensa> ObtenerExpensas(int idConsorcio)
        {
            var gastos= gastoRepo.ObtenerGastoPorConsorcio(idConsorcio);
            var unidades= unidadRepo.ObtenerTodosConsorcioId(idConsorcio);

            decimal gastoTotal = 0;

            foreach (var g in gastos)
            {
                gastoTotal += g.Monto;
            }
            foreach (var u in unidades)
            {

            }
            return null;
        }
    }
}
