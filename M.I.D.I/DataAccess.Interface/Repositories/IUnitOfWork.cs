using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IMusicRepository MusicRepository { get; }
        void Save();
    }
}
