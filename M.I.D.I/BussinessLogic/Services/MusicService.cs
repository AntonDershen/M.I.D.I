using System.Collections.Generic;
using System.Linq;
using BussinessLogic.Interface.Converters;
using System.Threading.Tasks;
using BussinessLogic.Interface.Entities;
using BussinessLogic.Interface.Services;
using DataAccess.Interface.Repositories;
using System;
using BussinessLogic.ConvertService;
using System.IO;

namespace BussinessLogic.Services
{
    public class MusicService : IMusicService
    {
        private readonly IUnitOfWork unitOfWork;
        public MusicService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public MusicEntity AddFile(FileInfo file)
        {
            MusicEntity musicEntity = file.ConvertFileInfo();
            musicEntity.NewPath = CopyFile(file);
            musicEntity = unitOfWork.MusicRepository.AddFile(musicEntity.ToMusicModel()).ToMusicEntity();
            unitOfWork.Save();
            return musicEntity;
        }
        private string CopyFile(FileInfo fileInfo)
        {
            string path = Directory.GetCurrentDirectory() + "\\music";
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filePath = path + "\\" + fileInfo.Name;
            int i = 0;
            while (true)
            {
                if(!File.Exists(filePath))
                {
                    break;
                }
                filePath = path + "\\" + i.ToString() + fileInfo.Name;
                i++;
            }
            fileInfo.CopyTo(filePath);
            return filePath;
        }
        public IEnumerable<MusicEntity> GetFiles()
        {
            return unitOfWork.MusicRepository.GetFiles().Where(y=>File.Exists(y.NewPath)).Select(x=>x.ToMusicEntity());
        }
        public void RemoveFile(MusicEntity musicEntity)
        {
            if (File.Exists(musicEntity.NewPath))
            {
                FileInfo fileInfo = new FileInfo(musicEntity.NewPath);
                fileInfo.Delete();
            }
            unitOfWork.MusicRepository.RemoveFile(musicEntity.MusicEntityId);
            unitOfWork.Save();
        }
    }
}
