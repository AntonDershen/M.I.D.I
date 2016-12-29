using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Constants;

namespace FileHelper
{
    public static class FileSystemCheck
    {
        public static void Check()
        {

        }
        public static void FindMusicStorageFolder()
        {
            if(!Directory.Exists(FileSystem.MusicStorageFolder))
            {
                Directory.CreateDirectory(FileSystem.MusicStorageFolder);
            }
        }
    }
}
