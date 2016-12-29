using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Constants;
using Windows.Storage;
using Windows.Storage.Search;
using Windows.Storage.FileProperties;

namespace FileSystemHelper
{
    public static class CheckFolderHelper
    {
        public static async void CheckMusicStorageFolder()
        {
            StorageFolder musicLibrary = KnownFolders.MusicLibrary;
            await musicLibrary.CreateFolderAsync(FileSystemConstants.MusicStorageFolder, CreationCollisionOption.OpenIfExists);
        }
        public static async Task<List<string[]>> GetFilesInFolder()
        {
            List<string[]> info = new List<string[]>();
            StorageFolder musicLibrary = await KnownFolders.MusicLibrary.GetFolderAsync(FileSystemConstants.MusicStorageFolder);
            IReadOnlyList<StorageFile> files = await musicLibrary.GetFilesAsync(CommonFileQuery.OrderByTitle);
            foreach (StorageFile file in files)
            {
                string[] data = await FilesToInfo(file);
                info.Add(data);                 
            }
            return info;
        }
        private static async Task<string[]> FilesToInfo(StorageFile file)
        {
            string[] info = new string[4];
            info[0] = file.DisplayName;
            BasicProperties basicProperties = await file.GetBasicPropertiesAsync();
            info[1] = basicProperties.Size.ToString() + " байт";
            return info;
        }
    }
}
