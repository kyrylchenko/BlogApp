
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BlogAppHost
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IBlogService" в коде и файле конфигурации.
    [ServiceContract]
    public interface IBlogService
    {
        [OperationContract]
        void RegisterUser(UserDTO user);
        [OperationContract]
          void UploadFile(UploadFileRequest info);
        [OperationContract]
        Stream DownloadFile(string filePath);     
        [OperationContract]
        UserDTO Connect(string passwordHash, string login );
        [OperationContract(IsOneWay =true)]
        void Disconnect();
       
        [OperationContract]
        List<ArticleDTO> GetArticlesByUserHashTages();
        [OperationContract]
        HashTagDTO GetHashTag(string hashtag);
        [OperationContract]
        List<ArticleDTO> GetArticlesByHashTag(string hashtag);
       
        [OperationContract]
        List<ArticleDTO> GetLikedArticles();
        [OperationContract]
        void SetLikedArticles(List<ArticleDTO> articles);
        [OperationContract]
        List<ArticleDTO> GetMyArticles();
        [OperationContract]
        void SetMyArticles(List<ArticleDTO> articles);
        [OperationContract]
        List<ArticleDTO> GetViewedArticles();
        [OperationContract]
        void SetViewedArticles(List<ArticleDTO> articles);
        [OperationContract]
        List<ArticleDTO> GetFavoriteArticles();
        [OperationContract]
        void SetFavoriteArticles(List<ArticleDTO> articles);
        [OperationContract]
        List<HashTagDTO> GetUserHashTags();
        [OperationContract]
        void SetUserHashTags(List<HashTagDTO> hashTags);
        [OperationContract]
        List<HashTagDTO> GetArticlesHashTags(ArticleDTO article);
        [OperationContract]
        void SetArticleHashTags(ArticleDTO article, List<HashTagDTO> hashTagDTOs);
        [OperationContract]
        string Test(string t);
       
    

    }
    
   
    [MessageContract]
    public class UploadFileRequest : IDisposable
    {
        [MessageHeader(MustUnderstand = true)]
        public string filePath;
        [MessageBodyMember]
        public System.IO.Stream FileByteStream;

        public void Dispose()
        {
            if (FileByteStream != null)
            {
                FileByteStream.Close();
                FileByteStream = null;
            }
        }
    }
}
