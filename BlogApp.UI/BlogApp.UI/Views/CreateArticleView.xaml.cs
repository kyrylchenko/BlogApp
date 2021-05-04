using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BlogApp.UI.Models;


namespace BlogApp.UI.Views
{
    /// <summary>
    /// Interaction logic for CreateArticleView.xaml
    /// </summary>
    public partial class CreateArticleView : Window
    {
        public CreateArticleView()
        {
            Owner = Application.Current.MainWindow;
            InitializeComponent();
        }

        private void Button_Click()
        {

        }
    }
}
