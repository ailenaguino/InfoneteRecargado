using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Context;

namespace Services
{
    public class BaseService<T, J> : IService<J> where T : BaseRepository<J> where J : class
    {
        protected T repo;
        public BaseService(PW3_TP_20202CEntities contexto)
        {
            PW3_TP_20202CEntities ctx = contexto;
            repo = Activator.CreateInstance(typeof(T), new object[] { contexto }) as T;
        }

        public virtual void Alta(J p)
        {
            repo.Alta(p);
        }

        public virtual void Eliminar(int id)
        {
            repo.Eliminar(id);
        }

        public virtual void Modificar(J p)
        {
            repo.Modificar(p);
        }

        public virtual J ObtenerPorId(int id)
        {
            return repo.ObtenerPorId(id);
        }

        public virtual List<J> ObtenerTodos()
        {
            return repo.ObtenerTodos();
        }
    }
}
