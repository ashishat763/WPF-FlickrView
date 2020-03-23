using FlickrView.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlickrView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FlickrViewModel flickrViewModel = new FlickrViewModel();
            DataContext = flickrViewModel;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var dc = (FlickrViewModel)DataContext;
            dc.SearchImages();
        }
    }
}
