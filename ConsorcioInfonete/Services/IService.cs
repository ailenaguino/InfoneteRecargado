using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    interface IService<T>
    {
        void Alta(T p);

        List<T> ObtenerTodos();

        T ObtenerPorId(int id);

        void Eliminar(int id);

        void Modificar(T p);
    }
}
