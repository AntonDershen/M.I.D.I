using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Storage.Pickers;
using Windows.Storage;
using BussinessLogic.Interface.Services;
using M.I.D.I.DataModels;
using M.I.D.I.Infrastructure.Mappers;
using Ninject;
using System.Linq;

namespace M.I.D.I
{
    public sealed partial class MainPage : Page
    {
        private async void Add_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker fop = new FileOpenPicker();
            fop.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            fop.FileTypeFilter.Add(".mid");
            fop.SuggestedStartLocation = PickerLocationId.MusicLibrary;
            IReadOnlyList<StorageFile> files = await fop.PickMultipleFilesAsync();
            foreach(StorageFile file in files)
            {
                IMusicService musicService = dependencyResolver.kernel.Get<IMusicService>();
                MusicModel musicModel = (await musicService.AddFile(file)).ToMusicEntity();
                MusicListView.Add(musicModel);
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
                musicService.RemoveFile(model.MusicEntityId);
                MusicListView.Remove(model.MusicEntityId);
            }
        }
    }

}
