using AprendendoVerbosHTTP.Model;
using AprendendoVerbosHTTP.Model.Context;
using AprendendoVerbosHTTP.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace AprendendoVerbosHTTP.Repository.Implementations
{
    public class PessoaRepositoryImpl : GenericRepository<Pessoa>, IPessoaRepository
    {
        public PessoaRepositoryImpl(MySQLContext dbContext) : base(dbContext) { }

        public List<Pessoa> FindByName(string nome, string sobrenome)
        {
            if (!string.IsNullOrEmpty(nome) && !string.IsNullOrEmpty(sobrenome))
            {
                return _dbContext.Pessoas.Where(data => data.Nome.Contains(nome) && data.Sobrenome.Contains(sobrenome)).ToList();
            }
            return _dbContext.Pessoas.Where(data => data.Nome.Contains(nome) || data.Sobrenome.Contains(sobrenome)).ToList();
        }
    }
}
