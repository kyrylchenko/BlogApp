using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.UI.Infrastructure;
using BLL.DTO;
using System.Windows.Input;
using System.Windows;
using System.IO;
using BlogApp.UI.Models;
using BlogApp.UI.Views;
using System.Windows.Media.Effects;



namespace BlogApp.UI.ViewModels
{
    class ArticlePageVM : BaseNotifyPropertyChanged
    {
        ArticleDTO selectedArticle;
        public ArticleDTO SelectedArticle
        {
            get => selectedArticle;
            set
            {
                selectedArticle = value;
                NotifyOfPopertyChanged();
            }
        }
        ArticleModel ArticleModel { set; get; }
        public void SetSelectedArticle(ArticleDTO article)
        {
            SelectedArticle = article;
            UserDTO user = AuthorizationDataManager.CurrentUser;
            MemoryStream pdfStream = new MemoryStream();
            AuthorizationDataManager.BlogService.DownloadFile(article.FilePath).CopyTo(pdfStream);
            pdfStream.Position = 0;
            PDFSream = pdfStream;
            if (AuthorizationDataManager.BlogService.GetLikedArticles().FirstOrDefault(a=>a.ArticleId == SelectedArticle.ArticleId)!= null)
                LikeIsChecked = true;
            if (AuthorizationDataManager.BlogService.GetFavoriteArticles().FirstOrDefault(a => a.ArticleId == SelectedArticle.ArticleId) != null)
                FavoritesIsChecked = true;
            if (SelectedArticle.Creator == user.UserId)
                EditButtonIsHiden = true;
            if(AuthorizationDataManager.BlogService.GetViewedArticles().FirstOrDefault(a => a.ArticleId == SelectedArticle.ArticleId) == null)
            {
                List<ArticleDTO> viewedArticles = AuthorizationDataManager.BlogService.GetViewedArticles();
                viewedArticles.Add(SelectedArticle);
                AuthorizationDataManager.BlogService.SetViewedArticles(viewedArticles);            
            }
        }
        public ArticlePageVM()
        {
            InitCommands();
            PDFSream = new MemoryStream();
            
            File.OpenRead("default.pdf").CopyTo(PDFSream);
        }
        private Stream pdfStream;
        public Stream PDFSream
        {
            get => pdfStream;
            set
            {
                pdfStream = value;
                NotifyOfPopertyChanged();
            }
        }

        public ICommand BackCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand LikeCommand { get; set; }
        bool likeIsChecked;
        public bool LikeIsChecked
        {
            get => likeIsChecked;
            set
            {
                likeIsChecked = value;
                NotifyOfPopertyChanged();
            }
        }
        public ICommand FavoriteCommand { get; set; }
        bool favoritesIsChecked;
        public bool FavoritesIsChecked
        {
            get => favoritesIsChecked;
            set
            {
                favoritesIsChecked = value;
                NotifyOfPopertyChanged();
            }
        }
        bool editButtonIsHiden;
        public bool EditButtonIsHiden
        {
            get => editButtonIsHiden;
            set
            {
                editButtonIsHiden = value;
                NotifyOfPopertyChanged();
            }
        }
        private void BackMethod()
        {
            MainPageView view = new MainPageView();
            Switcher.Switch(view);
        }
        private void InitCommands()
        {
            BackCommand = new RelayCommand(x =>
            {
                BackMethod();
            });
            DeleteCommand = new RelayCommand(x =>
            {
                List<ArticleDTO> myArticles = AuthorizationDataManager.BlogService.GetMyArticles();

               myArticles.Remove(myArticles.FirstOrDefault(a=>a.ArticleId == SelectedArticle.ArticleId));
                AuthorizationDataManager.BlogService.SetMyArticles(myArticles);
                BackMethod();
            });
            EditCommand = new RelayCommand(x =>
            {
                CreateArticleView view = new CreateArticleView();
                CreateArticleVM vm = view.DataContext as CreateArticleVM;
                vm.CreatedArticle = SelectedArticle;
                Application.Current.MainWindow.Effect = new BlurEffect();
                view.ShowDialog();
                Application.Current.MainWindow.Effect = null;
            });
            FavoriteCommand = new RelayCommand(x =>
            {

                List<ArticleDTO> favoriteArticles = AuthorizationDataManager.BlogService.GetFavoriteArticles();
                if (favoritesIsChecked == true)
                    favoriteArticles.Add(SelectedArticle);
                else
                    favoriteArticles.Remove(SelectedArticle);
                AuthorizationDataManager.BlogService.SetFavoriteArticles(favoriteArticles);


            });
            LikeCommand = new RelayCommand(x =>
            {

                List<ArticleDTO> likedArticles = AuthorizationDataManager.BlogService.GetLikedArticles();
                if (likeIsChecked == true)
                    likedArticles.Add(SelectedArticle);
                else
                  likedArticles.Remove(SelectedArticle);
                AuthorizationDataManager.BlogService.SetLikedArticles(likedArticles);
            });
        }
    }
}
