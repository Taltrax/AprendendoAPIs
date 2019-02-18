using AprendendoVerbosHTTP.Data.Converter;
using AprendendoVerbosHTTP.Data.VO;
using AprendendoVerbosHTTP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AprendendoVerbosHTTP.Data.Converters
{
    public class PessoaConverter : IParser<PessoaVO, Pessoa>, IParser<Pessoa, PessoaVO>
    {
        public Pessoa Parse(PessoaVO origin)
        {
            if (origin == null) return new Pessoa();
            return new Pessoa
            {
                ID = origin.ID,
                Nome = origin.Nome,
                Sobrenome = origin.Sobrenome,
                Endereco = origin.Endereco,
                Sexo = origin.Sexo
            };
        }

        public PessoaVO Parse(Pessoa origin)
        {
            if (origin == null) return new PessoaVO();
            return new PessoaVO
            {
                ID = origin.ID,
                Nome = origin.Nome,
                Sobrenome = origin.Sobrenome,
                Endereco = origin.Endereco,
                Sexo = origin.Sexo
            };
        }

        public List<Pessoa> ParseList(List<PessoaVO> origin)
        {
            if (origin == null) return new List<Pessoa>();
            return origin.Select(data => Parse(data)).ToList();
        }

        public List<PessoaVO> ParseList(List<Pessoa> origin)
        {
            if (origin == null) return new List<PessoaVO>();
            return origin.Select(data => Parse(data)).ToList();
        }
    }
}
