using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;
using Repositories.Context;

namespace Services
{
    public class UsuarioService:BaseService<UsuarioRepository, Usuario>
    {
        public UsuarioService(PW3_TP_20202CEntities contexto) : base(contexto)
        {
        }

        public Usuario GetByEmailAndPassword(string email, string password)
        {
            return repo.GetByEmailAndPassword(email, password);
        }
    }
}
