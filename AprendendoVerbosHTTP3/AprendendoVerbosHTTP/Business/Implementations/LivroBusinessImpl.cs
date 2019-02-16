using AprendendoVerbosHTTP.Model;
using AprendendoVerbosHTTP.Repository.Generic;
using System.Collections.Generic;

namespace AprendendoVerbosHTTP.Business.Implementations
{
    public class LivroBusinessImpl : ILivroBusiness
    {
        public IRepository<Livro> _repository;

        public LivroBusinessImpl(IRepository<Livro> repository)
        {
            _repository = repository;
        }

        public Livro Create(Livro livro)
        {
            return _repository.Create(livro);
        }

        public bool Delete(int ID)
        {
            return _repository.Delete(ID);
        }

        public List<Livro> FindAll()
        {
            return _repository.FindAll();
        }

        public Livro FindById(int ID)
        {
            return _repository.FindById(ID);
        }

        public Livro Update(Livro livro)
        {
            return _repository.Update(livro);
        }
    }
}
