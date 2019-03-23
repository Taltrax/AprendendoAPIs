using AprendendoVerbosHTTP.Model;
using System.Collections.Generic;

namespace AprendendoVerbosHTTP.Repository
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
        List<Pessoa> FindByName(string nome, string sobrenome);
    }
}
