using DataAccess.Interface.EntityFramework;
using DataAccess.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Context Context { get; set; }
        private IMusicRepository musicRepository;
        public IMusicRepository MusicRepository
        {
            get
            {
                if (musicRepository == null)
                    musicRepository = new MusicRepository(Context);
                return musicRepository;
            }
        }

        public UnitOfWork(Context context)
        {
            Context = context;
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public void Save()
        {
            if (Context != null)
            {
                Context.SaveChanges();
            }
        }
    }
}
