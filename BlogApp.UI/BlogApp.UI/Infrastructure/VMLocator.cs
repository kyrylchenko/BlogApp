
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.UI.ViewModels;

namespace BlogApp.UI.Infrastructure
{
    class VMLocator
    {
      
        public VMLocator()
        {
           
        }
        MainPageVM mainPageVM;
        public MainPageVM MainPageVM
        {
            get
            {
                if (mainPageVM == null)
                    mainPageVM = new MainPageVM();
                return mainPageVM;
            }
        }
        public ArticlePageVM ArticlePageVM => new ArticlePageVM();
        public CreateArticleVM CreateArticleVM => new CreateArticleVM();
        public FilterVM FilterVM => new FilterVM();
        public RegistrationVM RegistrationVM => new RegistrationVM();
        public LoginVM LoginVM => new LoginVM();
    }
}
