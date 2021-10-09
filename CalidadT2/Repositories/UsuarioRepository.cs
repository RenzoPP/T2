using CalidadT2.Models;
using System.Linq;

namespace CalidadT2.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario FindUserByCredentials(string username, string password);
    }
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppBibliotecaContext context;

        public UsuarioRepository(AppBibliotecaContext context)
        {
            this.context = context;
        }
        public Usuario FindUserByCredentials(string username, string password)
        {
            return context.Usuarios
                .Where(o => o.Username == username && o.Password == password)
                .FirstOrDefault();
        }
    }
}

