using System;
using System.Collections.Generic;
using System.IO;
using Windows.ApplicationModel;
using Windows.Storage.Pickers;
using Windows.Storage;
using Constants;

namespace FileSystemHelper
{
    public class OpenFileDialogHelper
    {
        public OpenFileDialogHelper()
        {
            CheckFolderHelper.CheckMusicStorageFolder();    
        }
        public async void PickFiles()
        {
            FileOpenPicker fop = new FileOpenPicker();
            fop.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            fop.FileTypeFilter.Add(".mid");
            fop.SuggestedStartLocation = PickerLocationId.MusicLibrary;
            IReadOnlyList<StorageFile> files = await fop.PickMultipleFilesAsync();
            CopyFiles(files);
        }
        private async void CopyFiles(IReadOnlyList<StorageFile> files)
        {
            StorageFolder musicLibrary = await KnownFolders.MusicLibrary.GetFolderAsync(FileSystemConstants.MusicStorageFolder);
            foreach (StorageFile file in files)
            {
                await file.CopyAsync(musicLibrary, file.Name, NameCollisionOption.GenerateUniqueName);
            }
        }
    }
}
