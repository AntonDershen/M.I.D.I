using BussinessLogic.Interface.Entities;
using M.I.D.I.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M.I.D.I.Infrastructure.Mappers
{
    public  static class MusicMapper
    {
        public static MusicEntity ToMusicModel(this MusicModel musicEntity)
        {
            return new MusicEntity
            {
                MusicEntityId = musicEntity.MusicEntityId,
                Name = musicEntity.Name
            };
        }
        public static MusicModel ToMusicEntity(this MusicEntity musicModel)
        {
            return new MusicModel
            {
                MusicEntityId = musicModel.MusicEntityId,
                Name = musicModel.Name
            };
        }
    }
}
