using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AprendendoVerbosHTTP.Model.Base
{
    //[DataContract]
    public class BaseEntity
    {
        [Key]
        public int ID { get; set; }
    }
}
