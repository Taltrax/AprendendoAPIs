using AprendendoVerbosHTTP.Data.VO;
using AprendendoVerbosHTTP.Model;
using System.Collections.Generic;

namespace AprendendoVerbosHTTP.Repository
{
    public interface IPessoaBusiness
    {
        PessoaVO Create(PessoaVO pessoa);
        PessoaVO Update(PessoaVO pessoa);
        bool Delete(int ID);
        PessoaVO FindById(int ID);
        List<PessoaVO> FindAll();
    }
}
