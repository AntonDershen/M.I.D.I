using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using FileSystemHelper;
using System.Collections.Generic;

namespace M.I.D.I
{
    public sealed partial class MainPage : Page
    {
        public MainPageModel MainModel { get; }

        public MainPage()
        {
            InitializeComponent();
            MainModel = new MainPageModel();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialogHelper openFileDialog = new OpenFileDialogHelper();
            openFileDialog.PickFiles();
        }
        private async void Sync_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
