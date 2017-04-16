using BussinessLogic.Interface.Entities;
using DataAccess.Interface.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Interface.Converters
{
    public static class ConvertEntityToConvertModel
    {
        public static ConvertedMusicModel ToConvertedMusicModel(this ConvertedMusicEntity convertMusicEntity)
        {
            return new ConvertedMusicModel
            {
                ConvertedMusicModelId = convertMusicEntity.ConvertedMusicEntityId,
                ConvertedDate = convertMusicEntity.ConvertedDate,
                Notes = convertMusicEntity.Notes.Select(x=>x.ToNoteModel())
            };
        }
        public static ConvertedMusicEntity ToConvertedMusicEntity(this ConvertedMusicModel convertedMusicModel)
        {
            return new ConvertedMusicEntity
            {
               ConvertedMusicEntityId = convertedMusicModel.ConvertedMusicModelId,
               ConvertedDate = convertedMusicModel.ConvertedDate,
               Notes = convertedMusicModel.Notes.Select(x=>x.ToNoteEntity())
            };
        }
    }
}
