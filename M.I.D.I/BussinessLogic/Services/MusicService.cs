using System.Collections.Generic;
using System.Linq;
using Windows.Storage;
using BussinessLogic.Interface.Converters;
using System.Threading.Tasks;
using BussinessLogic.Interface.Entities;
using BussinessLogic.Interface.Services;
using DataAccess.Interface.Repositories;
using System;
using BussinessLogic.ConvertService;

namespace BussinessLogic.Services
{
    public class MusicService : IMusicService
    {
        private readonly IUnitOfWork unitOfWork;
        public MusicService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<MusicEntity> AddFile(StorageFile file)
        {
            MusicEntity musicEntity = await file.ConvertStorageFile();
            ConvertedMusicEntity convertedMusicEntity = GetConvertedMusicEntity(musicEntity, file);
            musicEntity = unitOfWork.MusicRepository.AddFile(musicEntity.ToMusicModel()).ToMusicEntity();
            unitOfWork.Save();
            return musicEntity;
        }
        private ConvertedMusicEntity GetConvertedMusicEntity(MusicEntity musicEntity,StorageFile storageFile)
        {
            ConvertMIDI convertMIDI = new ConvertMIDI(storageFile.Path);
            ConvertedMusicEntity convertedMusicEntity = new ConvertedMusicEntity();
            convertedMusicEntity.ConvertedDate = DateTime.Now;
            convertedMusicEntity.Notes = convertMIDI.GetNotes();
            return convertedMusicEntity;
        }
        public IEnumerable<MusicEntity> GetFiles()
        {
            return unitOfWork.MusicRepository.GetFiles().Select(x=>x.ToMusicEntity());
        }
        public void RemoveFile(int fileId)
        {
            unitOfWork.MusicRepository.RemoveFile(fileId);
            unitOfWork.Save();
        }
    }
}
