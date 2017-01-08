using BussinessLogic.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace BussinessLogic.Interface.Services
{
    public interface IMusicService
    {
        Task<MusicEntity> AddFile(StorageFile file);
        void RemoveFile(int fileId);
        IEnumerable<MusicEntity> GetFiles();
    }
}
