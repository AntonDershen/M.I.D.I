using BussinessLogic.Interface.Services;
using M.I.D.I.DataModels;
using Ninject;
using System.Linq;
using System.Windows;

namespace M.I.D.I
{
    public sealed partial class MainWindow : Window
    {
        private MusicListView MusicListView { get; set; }
        private void listView_Selected(object sender, RoutedEventArgs e)
        {

        }
        private void listView_Loaded(object sender, RoutedEventArgs e)
        {
            IMusicService musicService = dependencyResolver.kernel.Get<IMusicService>();
            MusicListView = new MusicListView(musicService, listView);
            MusicListView.Update();
        }
    }
}
