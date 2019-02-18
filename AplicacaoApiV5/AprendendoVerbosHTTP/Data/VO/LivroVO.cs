using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Tapioca.HATEOAS;

namespace AprendendoVerbosHTTP.Data.VO
{
    [DataContract]
    public class LivroVO : ISupportsHyperMedia
    {
        [DataMember(Order = 1)]
        public int ID { get; set; }
        [DataMember(Order = 2)]
        public string Titulo { get; set; }
        [DataMember(Order = 3)]
        public string Autor { get; set; }
        [DataMember(Order = 5)]
        public decimal Preco { get; set; }
        [DataMember(Order = 4)]
        public DateTime DataLancamento { get; set; }
        [DataMember(Order = 6)]
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
