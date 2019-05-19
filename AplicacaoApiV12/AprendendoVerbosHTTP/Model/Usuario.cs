using System.ComponentModel.DataAnnotations.Schema;

namespace AprendendoVerbosHTTP.Model
{
    [Table("usuarios")]
    public class Usuario
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string AccessKey { get; set; }
    }
}
