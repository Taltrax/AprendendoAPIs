using AprendendoVerbosHTTP.Data.VO;
using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;

namespace AprendendoVerbosHTTP.Repository
{
    public interface IPessoaBusiness
    {
        PessoaVO Create(PessoaVO pessoa);
        PessoaVO Update(PessoaVO pessoa);
        bool Delete(int ID);
        PessoaVO FindById(int ID);
        List<PessoaVO> FindByName(string nome, string sobrenome);
        List<PessoaVO> FindAll();
        PagedSearchDTO<PessoaVO> FindWithPagedSearch(string nome, string ordenacao, int tamPagina, int pagina);
    }
}
