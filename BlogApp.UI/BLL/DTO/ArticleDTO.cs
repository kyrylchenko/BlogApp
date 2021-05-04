using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    [DataContract]
    public class ArticleDTO
    {
        [DataMember]
        public int ArticleId { get; set; }
        [DataMember]
        public string FilePath { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public int Creator { get; set; }
        [DataMember]
        public int CountViews { get; set; }
        [DataMember]
        public int CountLikes { get; set; }
        [DataMember]
        public int CountUsersWhoAddedToFavorite { get; set; }
        [DataMember]
        public string  CreatorName{get;set;}
    }
}
