using AprendendoVerbosHTTP.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AprendendoVerbosHTTP.Model
{
    [Table("livros")]
    public class Livro : BaseEntity
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataLancamento { get; set; }
    }
}
