using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using FileSystemHelper;
using System.Collections.Generic;
using Windows.Storage;
using System.Linq;

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
            Add.IsEnabled = false;
            OpenFileDialogHelper openFileDialog = new OpenFileDialogHelper();
            IReadOnlyList<StorageFile> files = await openFileDialog.PickFiles();
            foreach(StorageFile file in files)
            {
                await openFileDialog.CopyFile(file);
                string[] fileInfo = await CheckFolderHelper.FilesToInfo(file);
                MainModel.UpdateMusicModelList(fileInfo);
            }
            Add.IsEnabled = true;
        }
        private void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckRemoveButton();
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            Remove.IsEnabled = false;
            var selectedItems = GridView.SelectedItems.ToList();
            OpenFileDialogHelper openFileDialog = new OpenFileDialogHelper();
            foreach (MusicModel selectedItem in selectedItems)
            {
                openFileDialog.RemoveFile(selectedItem.Title);
                MainModel.RemoveFromMusicModelList(selectedItem.Title);
            }
            CheckRemoveButton();

        }
        private void CheckRemoveButton()
        {
            if (GridView.SelectedItems.Count > 0)
            {
                Remove.IsEnabled = true;
            }
            else
            {
                Remove.IsEnabled = false;
            }
        }
    }
}
