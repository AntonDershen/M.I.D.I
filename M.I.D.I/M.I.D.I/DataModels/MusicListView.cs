using BussinessLogic.Interface.Services;
using System.Collections.Generic;
using System.Linq;
using M.I.D.I.Infrastructure.Mappers;
using Windows.UI.Xaml.Controls;
using System.Collections.ObjectModel;

namespace M.I.D.I.DataModels
{
    public class MusicListView
    {
        private IMusicService musicService;
        private ListView listView;
        private ObservableCollection<MusicModel> MusicModelList { get; set; }

        public MusicListView(IMusicService musicService, ListView listView)
        {
            this.musicService = musicService;
            this.listView = listView;
            Update();
        }
        public void Update()
        {
            var musicModelList = musicService.GetFiles().Select(x => x.ToMusicEntity()).ToList();
            MusicModelList = new ObservableCollection<MusicModel>();
            foreach (var MusicModel in musicModelList)
            {
                MusicModelList.Add(MusicModel);
            }
            listView.ItemsSource = MusicModelList;
        }
        public void Add(MusicModel musicModel)
        {
            MusicModelList.Add(musicModel);
            listView.ItemsSource = MusicModelList;
        }
        public void Remove(int musicEntityId)
        {
            MusicModelList.Remove(MusicModelList.FirstOrDefault(x => x.MusicEntityId == musicEntityId));
            listView.ItemsSource = MusicModelList;
        }
    }
}
