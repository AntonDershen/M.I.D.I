using BussinessLogic.Interface.Entities;
using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Streams;

namespace BussinessLogic.Interface.Converters
{
    public static class StorageFileToMusicEntity
    {
        public static async Task<MusicEntity> ConvertStorageFile(this StorageFile file)
        {
            string name = file.DisplayName;
            byte[] fileContent = await GetFileBytes(file);
            return new MusicEntity()
            {
                Name = name,
                Content = fileContent
            };
        }
        private static async Task<byte[]> GetFileBytes(StorageFile file)
        {
            ulong fileSize = await GetFileSize(file);
            IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.Read);
            var reader = new DataReader(stream.GetInputStreamAt(0));
            byte[] fileContent = new byte[fileSize];
            await reader.LoadAsync((uint)fileSize);
            reader.ReadBytes(fileContent);
            return fileContent;
        }
        private static async Task<ulong> GetFileSize(StorageFile file)
        {
            ulong fileSize;
            BasicProperties basicProperties = await file.GetBasicPropertiesAsync();
            fileSize = basicProperties.Size;
            return fileSize;
        }
    }
}
