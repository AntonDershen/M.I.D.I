using DataAccess.Interface.EntityFramework;
using System;
using DataAccess.Interface.Repositories;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class MusicRepository : IMusicRepository
    {
        private Context context;
        public MusicRepository(Context context)
        {
            this.context = context;
        }
        public MusicModel AddFile(MusicModel musicModel)
        {
            try
            {
                context.Set<MusicModel>().Add(musicModel);
                context.SaveChanges();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return musicModel;
        }
        public IEnumerable<MusicModel> GetFiles()
        {
            try
            {
                return context.MusicModel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void RemoveFile(int fileId)
        {
            context.MusicModel.Remove(context.MusicModel.Find(fileId));
        }
    }
}
