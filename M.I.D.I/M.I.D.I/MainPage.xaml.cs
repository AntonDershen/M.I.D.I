using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using FileSystemHelper;
using System.Collections.Generic;
using Windows.Storage;

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
        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialogHelper openFileDialog = new OpenFileDialogHelper();
            IReadOnlyList<StorageFile> files = await openFileDialog.PickFiles();
            foreach(StorageFile file in files)
            {
                await openFileDialog.CopyFiles(file);
                string[] fileInfo = await CheckFolderHelper.FilesToInfo(file);
                MainModel.UpdateMusicModelList(fileInfo);
            }
        }
    }
}
