using AprendendoVerbosHTTP.Data.VO;
using System.Collections.Generic;

namespace AprendendoVerbosHTTP.Business
{
    public interface ILivroBusiness
    {
        LivroVO Create(LivroVO livro);
        LivroVO Update(LivroVO livro);
        bool Delete(int ID);
        LivroVO FindById(int ID);
        List<LivroVO> FindAll();
    }
}
