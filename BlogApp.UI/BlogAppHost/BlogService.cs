using BLL.DTO;
using BLL.Services;
using DAL.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;

namespace BlogAppHost
{

    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "BlogService" в коде и файле конфигурации.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, IncludeExceptionDetailInFaults = true)]
    public class BlogService : IBlogService
    {
        
        UserService userService;
        ArticleService articleService;
        HashTagService hashTagService;

        // Dictionary<string,UserDTO> connectedUsers;

        UserDTO CurrentUser;
        public BlogService()
        {       
            userService = new UserService();
            articleService = new ArticleService();
            hashTagService = new HashTagService();
           // connectedUsers = new Dictionary<string, UserDTO>();
        }
        public Stream DownloadFile(string filePath)
        {
            CheckUserAuthorized();
            return new MemoryStream(File.ReadAllBytes(filePath));                  
        }
      
            public  void UploadFile(UploadFileRequest info)
        {
            CheckUserAuthorized();
          
            try
            {
                using (var fileStream = File.Create(info.filePath))
                {
                    info.FileByteStream.CopyTo(fileStream);
                }
            }
            catch (Exception e)
            {
                throw new FaultException(e.Message);
            }
           
        }
        string GetAdressAndPortByCurrentCliet()
        {
            OperationContext operationContext = OperationContext.Current;
            MessageProperties messageProperties = operationContext.IncomingMessageProperties;
            RemoteEndpointMessageProperty remoteEndpointMessageProperty = (RemoteEndpointMessageProperty)messageProperties[RemoteEndpointMessageProperty.Name];
           return remoteEndpointMessageProperty.Address + remoteEndpointMessageProperty.Port;
        }
        public UserDTO Connect(string passwordHash, string login)
        {
            try
            {
                UserDTO user = userService.GetAll().FirstOrDefault(u => u.Login == login && u.Password == passwordHash);

                if (user != null)
                {
                    CurrentUser = user;
                    return user;
                }
                else
                    throw new FaultException("Incorect password or login");
            }
            catch (Exception e)
            {
                throw new FaultException(e.Message);
            }
        
        }

        public void Disconnect()
        {
            CheckUserAuthorized();
            try
            {
                CurrentUser= null;
            }
            catch (Exception e)
            {
                throw new FaultException(e.Message);
            }
        }

       
      
        
       void  CheckUserAuthorized([CallerMemberName]string callerName = "")
        {
            if (CurrentUser == null)
                throw new FaultException("User not authorized! invoke frome"+callerName);
        }

        public HashTagDTO GetHashTag(string hashtag)
        {
            CheckUserAuthorized();
            return hashTagService.GetAll().FirstOrDefault((h) => h.Tag == hashtag);
           

        }

        public void RegisterUser(UserDTO user)
        {
            try
            {
                if (userService.GetAll().FirstOrDefault((u) => u.Login == user.Login) != null)
                    throw new FaultException("User with this login alredy registered!");
                userService.CreateOrUpdate(user);
            }
            catch(Exception e)
            {
                throw new FaultException(e.Message);
            }
        }

        public List<ArticleDTO> GetArticlesByPredicate(Func<ArticleDTO, bool> predicate) =>
            articleService.GetAll().Where(predicate).ToList();

     
       

        public List<ArticleDTO> GetLikedArticles()
        {
            return articleService.mapper.Map<List<Article>,List<ArticleDTO>>(
                userService.repository.Get(CurrentUser.UserId).LikedArticles.ToList());
        }

        public void SetLikedArticles(List<ArticleDTO> articles)
        {
            SetUserArticles(articles, userService.repository.Get(CurrentUser.UserId).LikedArticles);
          

        }

        public List<ArticleDTO> GetMyArticles()
        {
            return articleService.mapper.Map<List<Article>, List<ArticleDTO>>(
               userService.repository.Get(CurrentUser.UserId).MyArticles.ToList());
        }

        public void SetMyArticles(List<ArticleDTO> articles)
        {
            SetUserArticles(articles,userService.repository.Get(CurrentUser.UserId).MyArticles);
         
        }
        void SetUserArticles(List<ArticleDTO> articles,ICollection<Article> colectionWhichWillBeChenged)
        {
            ICollection<Article> art = colectionWhichWillBeChenged;
            foreach (var a in articleService.mapper.Map<IEnumerable<ArticleDTO>, IEnumerable<Article>>(articles))
            {
                Article foundArticle;
                if ((foundArticle = art.FirstOrDefault(article => article.ArticleId == a.ArticleId)) != null)
                {
                    foundArticle.Title = a.Title;
                    foundArticle.FilePath = a.FilePath;
                }
                else
                    art.Add(a);
            }
            foreach (var a in art)
                if (articles.FirstOrDefault((article) => article.ArticleId == a.ArticleId) == null)
                    art.Remove(art.FirstOrDefault(article => article.ArticleId == a.ArticleId));
            userService.repository.SaveChanges();
        }
        public List<ArticleDTO> GetViewedArticles()
        {
            return articleService.mapper.Map<List<Article>, List<ArticleDTO>>(
              userService.repository.Get(CurrentUser.UserId).ViewedArticles.ToList());
        }

        public void SetViewedArticles(List<ArticleDTO> articles)
        {
            SetUserArticles(articles, userService.repository.Get(CurrentUser.UserId).ViewedArticles);
           
        }

        public List<ArticleDTO> GetFavoriteArticles()
        {
            return articleService.mapper.Map<List<Article>, List<ArticleDTO>>(
                userService.repository.Get(CurrentUser.UserId).FavoriteArticles.ToList());
        }

        public void SetFavoriteArticles(List<ArticleDTO> articles)
        {
            SetUserArticles(articles, userService.repository.Get(CurrentUser.UserId).FavoriteArticles);
      
        }

        public List<HashTagDTO> GetUserHashTags()
        {
            return hashTagService.mapper.Map<List<HashTag>, List<HashTagDTO>>(
               userService.repository.Get(CurrentUser.UserId).HashTags.ToList());
        }

        public void SetUserHashTags(List<HashTagDTO> hashTags)
        {
            ICollection<HashTag> tags = userService.repository.Get(CurrentUser.UserId).HashTags;
            tags.Clear();
            foreach (var a in hashTagService.mapper.Map<IEnumerable<HashTagDTO>, IEnumerable<HashTag>>(hashTags))
                tags.Add(a);
            userService.repository.SaveChanges();
        }

        public List<HashTagDTO> GetArticlesHashTags(ArticleDTO article)
        {

            return hashTagService.mapper.Map<List<HashTag>, List<HashTagDTO>>(
               articleService.repository.Get(article.ArticleId).HashTags.ToList());
        }

        public void SetArticleHashTags(ArticleDTO article, List<HashTagDTO> hashTagDTOs)
        {
            ICollection<HashTag> tags = articleService.repository.Get(article.ArticleId).HashTags;
            tags.Clear();
            foreach (var a in articleService.mapper.Map<IEnumerable<HashTagDTO>, IEnumerable<HashTag>>(hashTagDTOs))
                tags.Add(a);
            articleService.repository.SaveChanges();
        }

        public List<ArticleDTO> GetArticlesByUserHashTages()
        {
            if (userService.repository.Get(CurrentUser.UserId).HashTags.Count == 0)
                return articleService.GetAll().ToList();
            List <Article> userArticless= new List<Article>();

            foreach (var h in userService.repository.Get(CurrentUser.UserId).HashTags)
                userArticless.AddRange(h.Articles.ToList());
            return articleService.mapper.Map<List<Article>, List<ArticleDTO>>( userArticless );
        }

     
       
        [WebGet(UriTemplate = "test/{t}")]
        public string Test(string t)
        {
            throw new NotImplementedException();
        }

        public List<ArticleDTO> GetArticlesByHashTag(string hashtag)
        {
            return articleService.mapper.Map<List<Article>, List<ArticleDTO>>(articleService.repository.GetAll().Where(a => a.HashTags.FirstOrDefault(h => h.Tag.Contains(hashtag)) != null).ToList());
        }

       
    }
}
