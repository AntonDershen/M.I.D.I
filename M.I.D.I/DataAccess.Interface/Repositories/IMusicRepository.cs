using DataAccess.Interface.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface.Repositories
{
    public interface IMusicRepository
    {
        MusicModel AddFile(MusicModel musicModel);
        void RemoveFile(int fileId);
        IEnumerable<MusicModel> GetFiles();
    }
}
