using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using FileSystemHelper;
using System.Collections.Generic;

namespace M.I.D.I
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            Windows.UI.ViewManagement.ApplicationView appView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
            appView.SetDesiredBoundsMode(Windows.UI.ViewManagement.ApplicationViewBoundsMode.UseVisible);
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialogHelper openFileDialog = new OpenFileDialogHelper();
            openFileDialog.PickFiles();
        }

        private async void Sync_Click(object sender, RoutedEventArgs e)
        {
            List<string> names = await CheckFolderHelper.GetFilesInFolder();
            MusicFiles.Items.Clear();
            foreach(string name in names)
            {
                MusicFiles.Items.Add(name);
            }
            
        }
    }
}
