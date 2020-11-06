using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;
using Repositories.Context;

namespace Services
{
    public class UsuarioService : BaseService<UsuarioRepository, Usuario>
    {
        public UsuarioService(PW3_TP_20202CEntities contexto) : base(contexto)
        {
        }

        public Usuario GetByEmailAndPassword(string email, string password)
        {
            return repo.GetByEmailAndPassword(email, password);
        }

        public void UpdateLoginDate(Usuario user)
        {
            repo.UpdateLoginDate(user);
        }

        public void Register(Usuario user)
        {
            if (repo.CheckEmail(user))
            {
                user.FechaRegistracion = DateTime.Now;
                repo.Alta(user);
            }
            else
            {
                throw new Exception("El mail ya se encuentra en uso, pruebe utilizando otro");
            }

        }
    }
}
