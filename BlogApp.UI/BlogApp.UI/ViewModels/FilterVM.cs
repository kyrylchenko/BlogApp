using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BLL.DTO;
using BlogApp.UI.Infrastructure;
using BlogApp.UI.Models;

namespace BlogApp.UI.ViewModels
{
    class FilterVM : BaseNotifyPropertyChanged
    {
        public ObservableCollection<HashTagDTO> HashTags { get; set; }
        public List<HashTagDTO> SelectedHashTags { set; get; }
        public ICommand AcceptCommand { get; set; }
        public ICommand CancleCommand { get; set; }
        public FilterVM()
        {
            InitCommands();
        }
        private void InitCommands()
        {
            AcceptCommand = new RelayCommand(x =>
            {
                foreach (var hashTag in HashTags)
                {
                    HashTagDTO cHashTag;
                    if ((cHashTag = AuthorizationDataManager.BlogService.GetHashTag(hashTag.Tag)) != null)
                        hashTag.HashTagId = cHashTag.HashTagId;
                }
                AuthorizationDataManager.BlogService.SetUserHashTags(HashTags.ToList());
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
