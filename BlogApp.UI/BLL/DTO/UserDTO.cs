using DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    [DataContract]
    public class UserDTO
    {
        [DataMember]
        public int UserId { get; set; }
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Name { get; set; }
       
    
    }
}
