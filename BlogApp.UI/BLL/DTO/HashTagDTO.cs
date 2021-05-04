using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    [DataContract]
    public class HashTagDTO
    {
        [DataMember]
        public int HashTagId { get; set; }
        [DataMember]
        public string Tag { get; set; }
      

    }
}
