using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Context;

namespace Repositories
{
    public class UsuarioRepository:BaseRepository<Usuario>
    {
        public UsuarioRepository(PW3_TP_20202CEntities contexto) : base(contexto)
        {

        }

        public override void Modificar(Usuario m)
        {
            throw new NotImplementedException();
        }

        public Usuario GetByEmailAndPassword(string email,string password)
        {
            return ctx.Usuario.FirstOrDefault(usuario => usuario.Email == email && usuario.Password == password);
        }

        public void UpdateLoginDate(Usuario user)
        {
            user.FechaUltLogin=DateTime.Now;
            ctx.SaveChanges();
        }
    }
}
