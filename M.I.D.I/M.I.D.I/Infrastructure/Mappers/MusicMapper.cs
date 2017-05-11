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
        public static MusicEntity ToMusicEntity(this MusicModel musicEntity)
        {
            return new MusicEntity
            {
                MusicEntityId = musicEntity.MusicEntityId,
                Name = musicEntity.Name,
                NewPath = musicEntity.NewPath
            };
        }
        public static MusicModel ToMusicModel(this MusicEntity musicModel)
        {
            return new MusicModel
            {
                MusicEntityId = musicModel.MusicEntityId,
                Name = musicModel.Name,
                NewPath = musicModel.NewPath
            };
        }
    }
}
