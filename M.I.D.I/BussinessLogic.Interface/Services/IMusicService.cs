using BussinessLogic.Interface.Entities;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BussinessLogic.Interface.Services
{
    public interface IMusicService
    {
        MusicEntity AddFile(FileInfo file);
        void RemoveFile(MusicEntity musicEntity);
        IEnumerable<MusicEntity> GetFiles();
    }
}
