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
                Content = musicEntity.Content,
                Name = musicEntity.Name,
                Date = musicEntity.Date,
                Extension = musicEntity.Extension,
                ConvertedMusicModel = musicEntity.ConvertedMusicEntity.ToConvertedMusicModel()
            };
        }
        public static MusicEntity ToMusicEntity(this MusicModel musicModel)
        {
            return new MusicEntity
            {
                MusicEntityId = musicModel.MusicModelId,
                Content = musicModel.Content,
                Name = musicModel.Name,
                Date = musicModel.Date,
                Extension = musicModel.Extension,
                ConvertedMusicEntity = musicModel.ConvertedMusicModel.ToConvertedMusicEntity()
            };
        }
    }
}
