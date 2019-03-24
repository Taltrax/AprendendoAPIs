using AprendendoVerbosHTTP.Data.Converters;
using AprendendoVerbosHTTP.Data.VO;
using AprendendoVerbosHTTP.Model;
using AprendendoVerbosHTTP.Repository;
using AprendendoVerbosHTTP.Repository.Implementations;
using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;

namespace AprendendoVerbosHTTP.Business.Implementations
{
    public class PessoaBusinessImpl : IPessoaBusiness
    {
        private IPessoaRepository _repository;
        private readonly PessoaConverter _converter;

        public PessoaBusinessImpl(IPessoaRepository repository)
        {
            _repository = repository;
            _converter = new PessoaConverter();
        }

        public PessoaVO Create(PessoaVO pessoa)
        {
            var pessoaEntity = _converter.Parse(pessoa);
            pessoaEntity = _repository.Create(pessoaEntity);
            return _converter.Parse(pessoaEntity);
        }

        public PessoaVO Update(PessoaVO pessoa)
        {
            var pessoaEntity = _converter.Parse(pessoa);
            pessoaEntity = _repository.Update(pessoaEntity);
            return _converter.Parse(pessoaEntity);
        }

        public bool Delete(int ID)
        {
            return _repository.Delete(ID);
        }

        public PessoaVO FindById(int ID)
        {
            return _converter.Parse(_repository.FindById(ID));
        }

        public List<PessoaVO> FindByName(string nome, string sobrenome)
        {
            return _converter.ParseList(_repository.FindByName(nome, sobrenome));
        }

        public List<PessoaVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public PagedSearchDTO<PessoaVO> FindWithPagedSearch(string nome, string ordenacao, int tamPagina, int pagina)
        {
            pagina = pagina > 0 ? pagina - 1 : 0;

            string query = "SELECT * FROM pessoas AS p WHERE 1 = 1";
            if (!string.IsNullOrEmpty(nome)) query += $" AND p.nome LIKE '%{nome}%'";
            query += $" ORDER BY p.nome {ordenacao} LIMIT {tamPagina} OFFSET {pagina}";

            string queryCount = "SELECT COUNT(*) FROM pessoas AS p WHERE 1 = 1";
            if (!string.IsNullOrEmpty(nome)) queryCount += $" AND p.nome LIKE '%{nome}%'";

            var pessoas = _converter.ParseList(_repository.FindWithPagedSearch(query));

            if (pessoas == null || pessoas.Count == 0) return null;

            int totalRegistros = _repository.GetCount(queryCount);

            return new PagedSearchDTO<PessoaVO>
            {
                CurrentPage = pagina,
                List = pessoas,
                PageSize = tamPagina,
                SortDirections = ordenacao,
                TotalResults = totalRegistros
            };
        }
    }
}
