using AprendendoVerbosHTTP.Data.Converter;
using AprendendoVerbosHTTP.Data.VO;
using AprendendoVerbosHTTP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AprendendoVerbosHTTP.Data.Converters
{
    public class LivroConverter : IParser<LivroVO, Livro>, IParser<Livro, LivroVO>
    {
        public Livro Parse(LivroVO origin)
        {
            if (origin == null) return new Livro();
            return new Livro
            {
                ID = origin.ID,
                Titulo = origin.Titulo,
                Autor = origin.Autor,
                Preco = origin.Preco,
                DataLancamento = origin.DataLancamento   
            };
        }

        public LivroVO Parse(Livro origin)
        {
            if (origin == null) return new LivroVO();
            return new LivroVO
            {
                ID = origin.ID,
                Titulo = origin.Titulo,
                Autor = origin.Autor,
                Preco = origin.Preco,
                DataLancamento = origin.DataLancamento
            };
        }

        public List<Livro> ParseList(List<LivroVO> origin)
        {
            if (origin == null) return new List<Livro>();
            return origin.Select(data => Parse(data)).ToList();
        }

        public List<LivroVO> ParseList(List<Livro> origin)
        {
            if (origin == null) return new List<LivroVO>();
            return origin.Select(data => Parse(data)).ToList();
        }
    }
}
