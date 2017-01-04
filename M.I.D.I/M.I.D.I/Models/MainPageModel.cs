using FileSystemHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace M.I.D.I
{
    public class MainPageModel
    {
        public ObservableCollection<MusicModel> MusicModelList { get; set; }

        public MainPageModel()
        {
            LoadMusicModelList();
        }
        public void UpdateMusicModelList(string[] data)
        {
            MusicModelList.Add(Converter(data));
        }
        public void RemoveFromMusicModelList(string title)
        {
            MusicModelList.Remove(MusicModelList.FirstOrDefault(x => x.Title == title));
        }
        private async void LoadMusicModelList()
        {
            MusicModelList = new ObservableCollection<MusicModel>();
            List<string[]> info = await CheckFolderHelper.GetFilesInFolder();
            foreach(string[] data in info)
            {
                MusicModelList.Add(Converter(data));
            }
        }
        private MusicModel Converter(string[] data)
        {
            return new MusicModel()
            {
                Title = data[0],
                Size = data[1]
            };
        }
    }
}
