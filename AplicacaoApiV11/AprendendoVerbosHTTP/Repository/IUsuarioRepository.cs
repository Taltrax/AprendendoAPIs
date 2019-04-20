using AprendendoVerbosHTTP.Model;

namespace AprendendoVerbosHTTP.Repository
{
    public interface IUsuarioRepository
    {
        Usuario FindByLogin(string login);
    }
}
