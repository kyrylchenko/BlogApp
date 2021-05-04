using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BLL.DTO;
using System.Configuration;

namespace BlogApp.UI.Models
{
    static public class AuthorizationDataManager
    {
        
        static public BlogServiceReference.BlogServiceClient BlogService { get; private set; }
        static public UserDTO CurrentUser { set; get; }
       
        static public string UserLogin
        {
            set => ConfigurationManager.AppSettings.Set("UserLogin", value);
            get => ConfigurationManager.AppSettings.Get("UserLogin");
            
        }
        static public string UserPasswordHash
        {
          set => ConfigurationManager.AppSettings.Set("UserPassword", value);
          get => ConfigurationManager.AppSettings.Get("UserPassword");
        }
        static AuthorizationDataManager()
        {
            BlogService = new BlogServiceReference.BlogServiceClient();        
        }
     
      
       
    }
}
