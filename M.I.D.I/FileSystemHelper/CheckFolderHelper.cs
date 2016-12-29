using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Constants;
using Windows.Storage;
using Windows.Storage.Search;
namespace FileSystemHelper
{
    public static class CheckFolderHelper
    {
        public static async void CheckMusicStorageFolder()
        {
            StorageFolder musicLibrary = KnownFolders.MusicLibrary;
            await musicLibrary.CreateFolderAsync(FileSystemConstants.MusicStorageFolder, CreationCollisionOption.OpenIfExists);
        }
        public static async Task<List<string>> GetFilesInFolder()
        {
            StorageFolder musicLibrary = await KnownFolders.MusicLibrary.GetFolderAsync(FileSystemConstants.MusicStorageFolder);
            IReadOnlyList<StorageFile> files = await musicLibrary.GetFilesAsync(CommonFileQuery.OrderByTitle);
            List<string> names = files.Select(x => x.Name).ToList();
            return names;
        }
    }
}
