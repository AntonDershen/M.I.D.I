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
                ConvertedContent = musicEntity.ConvertedContent,
                Name = musicEntity.Name
            };
        }
        public static MusicEntity ToMusicEntity(this MusicModel musicModel)
        {
            return new MusicEntity
            {
                MusicEntityId = musicModel.MusicModelId,
                Content = musicModel.Content,
                ConvertedContent = musicModel.ConvertedContent,
                Name = musicModel.Name
            };
        }
    }
}
