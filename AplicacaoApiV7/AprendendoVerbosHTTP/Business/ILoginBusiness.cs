using AprendendoVerbosHTTP.Model;

namespace AprendendoVerbosHTTP.Business
{
    public interface ILoginBusiness
    {
        object FindByLogin(Usuario user);
    }
}
