using AprendendoVerbosHTTP.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AprendendoVerbosHTTP.Model
{
    public class Pessoa : BaseEntity
    { 
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Endereco { get; set; }
        public string Sexo { get; set; }
    }
}
