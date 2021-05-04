using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BlogApp.UI.Infrastructure;
using BlogApp.UI.Models;
using BlogApp.UI.Views;

namespace BlogApp.UI.ViewModels
{
    class LoginVM : BaseNotifyPropertyChanged
    {
        public ICommand LoginCommand { get; set; }
        public ICommand RegistrateCommand { get; set; }
        public ICommand CancleCommand { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public LoginVM()
        {
            InitCommands();
        }

        private void InitCommands()
        {
            LoginCommand = new RelayCommand(async x =>
            {

                AuthorizationDataManager.CurrentUser = await AuthorizationDataManager.BlogService.ConnectAsync(PasswordHash, Login);
               
                ((Window)x).DialogResult = true;
                ((Window)x).Close();
            });
            RegistrateCommand = new RelayCommand(x =>
            {
                new RegistrationView().ShowDialog();

            });
            CancleCommand = new RelayCommand(x =>
            {
                ((Window)x).DialogResult = false;

                ((Window)x).Close();
            });
        }
       
    }
}
