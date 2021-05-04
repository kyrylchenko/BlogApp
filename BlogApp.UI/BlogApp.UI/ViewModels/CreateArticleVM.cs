using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.UI.Infrastructure;
using BLL.DTO;
using System.Windows.Input;
using Microsoft.Win32;
using System.Windows;
using System.IO;
using BlogApp.UI.Models;
using System.Collections.ObjectModel;


namespace BlogApp.UI.ViewModels
{
    class CreateArticleVM : BaseNotifyPropertyChanged
    {

        private HashTagDTO hashtag;
        Random random = new Random();
      
        public HashTagDTO Hashtag
        {
            set
            {
                hashtag = value;
                NotifyOfPopertyChanged();
            }
            get
            {
                return hashtag;

            }
        }
        private string filePath;
        public string FilePath

        { 
            set
            {
                filePath = value;
                NotifyOfPopertyChanged();
            }
            get
            {
                return filePath;
            }
        }
        public ObservableCollection<HashTagDTO> HashTags { set; get; }
        public ArticleDTO CreatedArticle { get; set; }      
        public ICommand CreateCommand { get; set; }
        public ICommand CancleCommand { get; set; }
        public ICommand BrowserCommand { get; set; }
        public ICommand AddHashTagCommand { get; set; }
        public CreateArticleVM()
        {
            CreatedArticle = new ArticleDTO();
         
            hashtag = new HashTagDTO();
            HashTags = new ObservableCollection<HashTagDTO>();
            InitCommands();

        }
      
        string createdTag;
        public string CreatedTag
        {
            get => createdTag;
            set
            {
                createdTag = value;
                NotifyOfPopertyChanged();
            }
        }

   
       
        private void InitCommands()
        {
            CreateCommand = new RelayCommand( x =>
            {

                try
                {
                    CreatedArticle.FilePath = "tempname" + random.Next(100000, 999999).ToString();
                    List<ArticleDTO> userArticles = AuthorizationDataManager.BlogService.GetMyArticles();
                    userArticles.Add(CreatedArticle);
                    AuthorizationDataManager.BlogService.SetMyArticles(userArticles);

                    userArticles = AuthorizationDataManager.BlogService.GetMyArticles();
                    ArticleDTO currentArticle = userArticles.
                         FirstOrDefault((a) => a.FilePath == CreatedArticle.FilePath);
                    currentArticle.FilePath = currentArticle.ArticleId.ToString();



                    AuthorizationDataManager.BlogService.SetMyArticles(userArticles);
                    foreach (var hashTag in HashTags)
                    {
                        HashTagDTO cHashTag;
                        if ((cHashTag = AuthorizationDataManager.BlogService.GetHashTag(hashTag.Tag)) != null)
                            hashTag.HashTagId = cHashTag.HashTagId;
                    }
                    AuthorizationDataManager.BlogService.SetArticleHashTags(currentArticle, HashTags.ToList());
                    AuthorizationDataManager.BlogService.UploadFile(currentArticle.FilePath, File.OpenRead(FilePath));
                    ((Window)x).DialogResult = true;
                    ((Window)x).Close();
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
               
                     
               

              
            });
            CancleCommand = new RelayCommand(x =>
            {
                ((Window)x).DialogResult = false;
               ((Window)x).Close();
            });
            BrowserCommand = new RelayCommand(x =>
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "PDF files (*.pdf)|*.pdf";
                if (dlg.ShowDialog() == true)
                    FilePath = dlg.FileName;

            });
         
            AddHashTagCommand = new RelayCommand( x =>
            {


                HashTags.Add(Hashtag);
                    Hashtag = new HashTagDTO();
                

            });
        }
     
    }
}
