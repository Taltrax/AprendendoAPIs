using AprendendoVerbosHTTP.Data.VO;

namespace AprendendoVerbosHTTP.Business
{
    public interface ILoginBusiness
    {
        object FindByLogin(UsuarioVO usuario);
    }
}
