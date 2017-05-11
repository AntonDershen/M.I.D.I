using BussinessLogic.Interface.Entities;
using DataAccess.Interface.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Interface.Converters
{
    public static class MusicEntityToMusicModel
    {
        public static MusicModel ToMusicModel(this MusicEntity musicEntity)
        {
            return new MusicModel
            {
                MusicModelId = musicEntity.MusicEntityId,
                Name = musicEntity.Name,
                Date = musicEntity.Date,
                NewPath = musicEntity.NewPath,
                Extension = musicEntity.Extension
            };
        }
        public static MusicEntity ToMusicEntity(this MusicModel musicModel)
        {
            return new MusicEntity
            {
                MusicEntityId = musicModel.MusicModelId,
                Name = musicModel.Name,
                Date = musicModel.Date,
                Extension = musicModel.Extension,
                NewPath = musicModel.NewPath
            };
        }
    }
}
