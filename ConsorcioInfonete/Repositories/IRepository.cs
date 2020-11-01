using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Context
{
    interface IRepository<T>
    {
        void Alta(T m);

        List<T> ObtenerTodos();

        T ObtenerPorId(int id);

        void Eliminar(int id);

        void Modificar(T m);
    }
}
