using AprendendoVerbosHTTP.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AprendendoVerbosHTTP.Model
{
    [Table("pessoas")]
    public class Pessoa : BaseEntity
    { 
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Endereco { get; set; }
        public string Sexo { get; set; }
    }
}
