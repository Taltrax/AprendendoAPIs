using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AprendendoVerbosHTTP.Model;
using AprendendoVerbosHTTP.Model.Context;
using AprendendoVerbosHTTP.Repository.Generic;

namespace AprendendoVerbosHTTP.Repository.Implementations
{
    public class PessoaBusinessImpl : IPessoaBusiness
    {

        private IRepository<Pessoa> _repository;

        public PessoaBusinessImpl(IRepository<Pessoa> repository)
        {
            _repository = repository;
        }

        public Pessoa Create(Pessoa pessoa)
        {
            return _repository.Create(pessoa);
        }

        public void Delete(int ID)
        {
            _repository.Delete(ID);
        }

        public List<Pessoa> FindAll()
        {
            return _repository.FindAll();
        }

        public Pessoa FindById(int ID)
        {
            return _repository.FindById(ID);
        }

        public Pessoa Update(Pessoa pessoa)
        {
            return _repository.Update(pessoa);
        }
    }
}
