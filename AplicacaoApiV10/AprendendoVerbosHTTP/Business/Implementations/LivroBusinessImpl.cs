using AprendendoVerbosHTTP.Data.Converters;
using AprendendoVerbosHTTP.Data.VO;
using AprendendoVerbosHTTP.Model;
using AprendendoVerbosHTTP.Repository;
using System.Collections.Generic;

namespace AprendendoVerbosHTTP.Business.Implementations
{
    public class LivroBusinessImpl : ILivroBusiness
    {
        private IRepository<Livro> _repository;
        private readonly LivroConverter _converter;

        public LivroBusinessImpl(IRepository<Livro> repository)
        {
            _repository = repository;
            _converter = new LivroConverter();
        }

        public LivroVO Create(LivroVO livro)
        {
            var livroEntity = _converter.Parse(livro);
            livroEntity =  _repository.Create(livroEntity);
            return _converter.Parse(livroEntity);
        }

        public LivroVO Update(LivroVO livro)
        {
            var livroEntity = _converter.Parse(livro);
            livroEntity = _repository.Update(livroEntity);
            return _converter.Parse(livroEntity);
        }

        public bool Delete(int ID)
        {
            return _repository.Delete(ID);
        }

        public LivroVO FindById(int ID)
        {
            return _converter.Parse(_repository.FindById(ID));
        }

        public List<LivroVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }
    }
}
