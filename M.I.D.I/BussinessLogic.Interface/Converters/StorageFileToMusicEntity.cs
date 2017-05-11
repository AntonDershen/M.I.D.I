using BussinessLogic.Interface.Entities;
using System;
using System.IO;
using System.Threading.Tasks;


namespace BussinessLogic.Interface.Converters
{
    public static class StorageFileToMusicEntity
    {
        public static MusicEntity ConvertFileInfo(this FileInfo file)
        {
            string name = file.Name;
            return new MusicEntity()
            {
                Name = name,
                Extension = file.Extension,
                Date = DateTime.Now
            };
        }
    }
}
