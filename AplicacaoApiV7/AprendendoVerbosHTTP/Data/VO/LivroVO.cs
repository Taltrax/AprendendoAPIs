using System;
using System.Runtime.Serialization;

namespace AprendendoVerbosHTTP.Data.VO
{
    [DataContract]
    public class LivroVO
    {
        [DataMember(Order = 1, Name = "codigo")]
        public int ID { get; set; }
        [DataMember(Order = 2)]
        public string Titulo { get; set; }
        [DataMember(Order = 3)]
        public string Autor { get; set; }
        [DataMember(Order = 5)]
        public decimal Preco { get; set; }
        [DataMember(Order = 4)]
        public DateTime DataLancamento { get; set; }
    }
}
