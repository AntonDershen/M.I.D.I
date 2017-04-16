using BussinessLogic.Interface.Entities;
using DataAccess.Interface.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Interface.Converters
{
    public static class AlbumEntityToAlbumModel
    {
        public static AlbumModel ToAlbumModel(this AlbumEntity albumEntity)
        {
            return new AlbumModel
            {
               AlbumModelId = albumEntity.AlbumEntityId,
               Date = albumEntity.Date,
               Name = albumEntity.Name,
               MusicModels = albumEntity.MusicEntities.Select(x=>x.ToMusicModel())
            };
        }
        public static AlbumEntity ToAlbumEntity(this AlbumModel albumModel)
        {
            return new AlbumEntity
            {
                AlbumEntityId = albumModel.AlbumModelId,
                Date = albumModel.Date,
                Name = albumModel.Name,
                MusicEntities = albumModel.MusicModels.Select(x => x.ToMusicEntity())
            };
        }
    }
}
