using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BlogApp.UI.Infrastructure;
using System.Windows;
using BlogApp.UI.Models;

namespace BlogApp.UI.ViewModels
{
    class RegistrationVM : BaseNotifyPropertyChanged
    {
        public UserDTO User { get; set; }
        public ICommand RegistrateCommand { get; set; }
        public ICommand CancleCommand { get; set; }
        public RegistrationVM()
        {
            User = new UserDTO();
            InitCommand();
        }
        private void InitCommand()
        {
            RegistrateCommand = new RelayCommand(x =>
            {
                AuthorizationDataManager.BlogService.RegisterUser(User);
                ((Window)x).DialogResult = true;
                ((Window)x).Close();
            });
            CancleCommand = new RelayCommand(x =>
            {
                ((Window)x).DialogResult = false;
                ((Window)x).Close();
            });
        }
       
    }
}
