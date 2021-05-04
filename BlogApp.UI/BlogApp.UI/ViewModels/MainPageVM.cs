using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.UI.Models;
using BlogApp.UI.Infrastructure;
using System.Windows.Input;
using BLL.DTO;
using BlogApp.UI.Views;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media.Effects;

namespace BlogApp.UI.ViewModels
{
    class MainPageVM
    {
        public ObservableCollection<ArticleModel> ArticleModels { get; set; } = new ObservableCollection<ArticleModel>();
        ArticleModel selectedArticle;
        public ArticleModel SelecteArticle
        {
            get => selectedArticle;
            set
            {
                selectedArticle = value;
                if(selectedArticle!= null)
                OpenArticlePage();
            }
        }
        private void OpenArticlePage()
        {
            ArticlePageView view = new ArticlePageView();
            ArticlePageVM vm = view.DataContext as ArticlePageVM;
            vm.SetSelectedArticle(SelecteArticle.Article);
            Switcher.Switch(view);
        }
        private void FillArticlesModels(IEnumerable<ArticleDTO> articles)
        {
            foreach (var article in articles)
                ArticleModels.Add(new ArticleModel(article));
        }
        public MainPageVM()
        {
       
                FillArticlesModels(AuthorizationDataManager.BlogService.GetArticlesByUserHashTages());
       
            InitCommnads();
        }
        public string SearchText { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand FavoritesCommand { get; set; }
        public ICommand OpenCreateViewCommand { get; set; }
        public ICommand OpenFilterViewCommand { get; set; }
        public ICommand LikedCommand { get; set; }
        public ICommand MyArticlesCommand { get; set; }
        public ICommand RenewCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
      
        private void InitCommnads()
        {
            SearchCommand = new RelayCommand(x =>
            {
                IEnumerable<ArticleDTO> articles;
                if (SearchText.StartsWith("#"))
                    articles = AuthorizationDataManager.BlogService.GetArticlesByHashTag(SearchText);
                else
                    articles = AuthorizationDataManager.BlogService.GetArticlesByUserHashTages().Where(a=>a.Title.Contains(SearchText));
                ArticleModels.Clear();
                FillArticlesModels(articles);
            });
            FavoritesCommand = new RelayCommand(x =>
            {
                var res = AuthorizationDataManager.BlogService.GetFavoriteArticles();
                ArticleModels.Clear();
                FillArticlesModels(res);
            });
            OpenCreateViewCommand = new RelayCommand(x =>
            {
                CreateArticleView view = new CreateArticleView();
                view.ShowDialog();
            });
            OpenFilterViewCommand = new RelayCommand(x =>
            {
                FilterWindowView filterWindow = new FilterWindowView() { Owner=App.Current.MainWindow,WindowStartupLocation = WindowStartupLocation.CenterOwner};
                Application.Current.MainWindow.Effect = new BlurEffect();
                if(filterWindow.ShowDialog() == true)
                {
                    var res = AuthorizationDataManager.BlogService.GetArticlesByUserHashTages();
                    ArticleModels.Clear();
                    FillArticlesModels(res);
                }
                Application.Current.MainWindow.Effect = null;
            });
            LikedCommand = new RelayCommand(x =>
            {
                var res = AuthorizationDataManager.BlogService.GetLikedArticles();
                ArticleModels.Clear();
                FillArticlesModels(res);
            });
            MyArticlesCommand = new RelayCommand(x =>
            {
                var res = AuthorizationDataManager.BlogService.GetMyArticles();
                ArticleModels.Clear();
                FillArticlesModels(res);
            });
            RenewCommand = new RelayCommand(x =>
            {

            });
            LogoutCommand = new RelayCommand(x =>
            {
                LoginView view = new LoginView();
                Application.Current.MainWindow.Effect = new BlurEffect();
                if (view.ShowDialog() == false)
                 App.Current.Shutdown();
                Application.Current.MainWindow.Effect = null;
            });
        }
    }
}
