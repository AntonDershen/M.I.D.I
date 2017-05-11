using System;
using System.Collections.Generic;
using BussinessLogic.Interface.Services;
using M.I.D.I.DataModels;
using M.I.D.I.Infrastructure.Mappers;
using Ninject;
using System.Linq;
using System.Windows;
using Microsoft.Win32;
using System.IO;

namespace M.I.D.I
{
    public sealed partial class MainWindow : Window
    {
        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fop = new OpenFileDialog();
            fop.Filter= "Midi Files (.mid)|*.mid";
            fop.Multiselect = true;
            Nullable<bool> result = fop.ShowDialog();
            if (result == true)
            {
                foreach (String fileName in fop.FileNames)
                {
                    FileInfo fileInfo = new FileInfo(fileName);
                    IMusicService musicService = dependencyResolver.kernel.Get<IMusicService>();
                    MusicModel musicModel = (musicService.AddFile(fileInfo)).ToMusicModel();
                    MusicListView.Add(musicModel);
                }
            }
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            MusicModel[] musicModel = new MusicModel[listView.SelectedItems.Count];
            listView.SelectedItems.CopyTo(musicModel, 0);
            foreach (var item in musicModel.ToList())
            {
                MusicModel model = item as MusicModel;
                IMusicService musicService = dependencyResolver.kernel.Get<IMusicService>();
                musicService.RemoveFile(model.ToMusicEntity());
                MusicListView.Remove(model.MusicEntityId);
            }
        }
    }

}
