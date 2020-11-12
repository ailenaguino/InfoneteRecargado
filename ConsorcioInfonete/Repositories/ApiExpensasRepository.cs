using Common;
using Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ApiExpensasRepository
    {
        PW3_TP_20202CEntities contexto;
        public ApiExpensasRepository(PW3_TP_20202CEntities ctx)
        {
            contexto = ctx;
        }

        public List<Expensa> ObtenerExpensas(int idConsorcio)
        {
            (from gasto in contexto.Gasto
             join unidad in contexto.Unidad on gasto.IdConsorcio equals unidad.IdConsorcio
             where gasto.IdConsorcio == idConsorcio
             group gasto.Monto by gasto.MesExpensa into gastoMes
                    select gastoMes).ToList();
        }
    }
}
