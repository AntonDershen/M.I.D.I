using BussinessLogic.Interface.Services;
using M.I.D.I.DataModels;
using Ninject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace M.I.D.I
{
    public sealed partial class MainPage : Page
    {
        private MusicListView MusicListView { get; set; }
        private void listView_Loading(Windows.UI.Xaml.FrameworkElement sender, object args)
        {
            IMusicService musicService = dependencyResolver.kernel.Get<IMusicService>();
            MusicListView = new MusicListView(musicService,listView);
            MusicListView.Update();
        }
        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            buttonRemove.IsEnabled = listView.SelectedItems.Count > 0;
        }
    }
}
