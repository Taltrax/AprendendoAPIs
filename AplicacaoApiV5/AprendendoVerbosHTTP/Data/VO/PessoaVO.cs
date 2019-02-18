using System.Collections.Generic;
using Tapioca.HATEOAS;

namespace AprendendoVerbosHTTP.Data.VO
{
    public class PessoaVO : ISupportsHyperMedia
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Endereco { get; set; }
        public string Sexo { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
