using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using BLL.DTO;
using BlogApp.UI.Infrastructure;
using BlogApp.UI.Models;
using BlogApp.UI.BlogServiceReference;
using System.ServiceModel;
using BlogApp.UI.Views;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media.Effects;

namespace BlogApp.UI.ViewModels
{
    class MainViewModel : BaseNotifyPropertyChanged, INavigate
    {
        UserControl currentPage;
      
      
        public UserControl CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage = value;
                NotifyOfPopertyChanged();
            }
        }
        private void AutoLogin()=>
            AuthorizationDataManager.BlogService.Connect(AuthorizationDataManager.UserLogin,AuthorizationDataManager.UserPasswordHash);
        public MainViewModel()
        {
            Switcher.ContentArea = this;
            if (AuthorizationDataManager.UserLogin != null)
                AutoLogin();
            else
            {
                LoginView loginView = new LoginView();
                Application.Current.MainWindow.Effect = new BlurEffect();
                if (loginView.ShowDialog() == false)
                    Process.GetCurrentProcess().Kill();
                Application.Current.MainWindow.Effect = null;
            }
            Switcher.Switch(new MainPageView());
     
         

        }
        public void Navigate(UserControl page)
        {
            CurrentPage = page;
        }
    }
}
