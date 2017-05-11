using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface.EntityFramework
{
    public class Context : DbContext
    {
        public DbSet<MusicModel> MusicModel { get; set; }
        public DbSet<AlbumModel> AlbumModel { get; set; }
        public Context() : base("name=DefaultConnection")
        {
        }
    }
}
