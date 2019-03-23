using AprendendoVerbosHTTP.Model;
using AprendendoVerbosHTTP.Model.Context;
using System.Linq;

namespace AprendendoVerbosHTTP.Repository.Implementations
{
    public class UsuarioRepositoryImpl : IUsuarioRepository
    {
        private MySQLContext _dbContext;

        public UsuarioRepositoryImpl(MySQLContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Usuario FindByLogin(string login)
        {
            return _dbContext.Usuarios.SingleOrDefault(p => p.Login.Equals(login));
        }
    }
}
