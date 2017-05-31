using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using BussinessLogic.Interface.Services;
using M.I.D.I.DataModels;
using Ninject;

namespace M.I.D.I
{
    public sealed partial class MainWindow : Window
    {
        private bool IsPlaying = false;
        private int ComposeId = 0;
        private IPlayMusicService playMusicService;
        private int CurrentComposeNumber = 0;

        private void Initialize()
        {
            if(playMusicService == null)
                playMusicService = dependencyResolver.kernel.Get<IPlayMusicService>();
            MusicModel[] musicModel = new MusicModel[listView.SelectedItems.Count];
            listView.SelectedItems.CopyTo(musicModel, 0);
            if (musicModel.Length > 0)
            {
                int newComposeId = musicModel[0].MusicEntityId;
                if(newComposeId != ComposeId) {
                    playMusicService.SetComposition(newComposeId);
                    ComposeId = newComposeId;
                }
            }
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            Initialize();
            IsPlaying = !IsPlaying;
            if (IsPlaying && ComposeId > 0)
            {
                ButtonPlay.Visibility = Visibility.Hidden;
                ButtonPause.Visibility = Visibility.Visible;
                playMusicService.Play();
            }
            else if (ComposeId > 0)
            {
                ButtonPlay.Visibility = Visibility.Visible;
                ButtonPause.Visibility = Visibility.Hidden;
                playMusicService.Stop();
            }
            else
            {
                IsPlaying = !IsPlaying;
            }
        }
    }
}
