using LyricsFinder.Core.Extensions;
using LyricsFinder.PlayerIntegrityManager;
using LyricsFinder.PlayerIntegrityManager.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace LyricsFinder.Core.MVVM.Song
{
    class SongViewModel : BindableBase
    {
        public SongViewModel(IPlayerBroker playerBroker)
        {
            _playerBroker = playerBroker;

            AlbumArt = Properties.Resources.brokenImage.ToBitmapSource();

            _playerBroker.TrackTimeChanged += _playerBroker_TrackTimeChanged;
            _playerBroker.TrackChanged += _playerBroker_TrackChanged;
            _playerBroker.Connect();
        }

        public string SongName { get => _songName; private set => SetProperty(ref _songName, value); }
        public string AlbumName { get => _albumName; private set => SetProperty(ref _albumName, value); }
        public string ArtistName { get => _artistName; private set => SetProperty(ref _artistName, value); }
        public uint ProgressMax { get => _progressMax; private set => SetProperty(ref _progressMax, value); }
        public uint ProgressActual { get => _progressActual; private set => SetProperty(ref _progressActual, value); }
        public string ProgressText { get => _progressText; private set => SetProperty(ref _progressText, value); }
        public BitmapSource AlbumArt { get => _albumArt; private set => SetProperty(ref _albumArt, value); }

        string _songName;
        string _albumName;
        string _artistName;
        string _progressText;
        uint _progressMax;
        uint _progressActual;
        BitmapSource _albumArt;

        private async void _playerBroker_TrackChanged(TrackInfo track)
        {
            SongName = track.Name;
            AlbumName = track.Album.Name;
            ArtistName = string.Join(", ", track.Artists.Select(a => a.Name));

            var image = await _playerBroker.GetImageAsync();

            if (image != null)
                Dispatcher.CurrentDispatcher.Invoke(() => { AlbumArt = image.ToBitmapSource(); });
            else
                AlbumArt = Properties.Resources.brokenImage.ToBitmapSource();
        }

        private void _playerBroker_TrackTimeChanged(TrackTimeInfo trackInfo)
        {
            ProgressMax = trackInfo.Duration;
            ProgressActual = trackInfo.Actual;

            TimeSpan actualTs = new TimeSpan(ProgressActual);
            TimeSpan maxTs = new TimeSpan(ProgressMax);

            string textPt1 = actualTs.TotalHours > 0 ? $"{actualTs.TotalHours}:{actualTs.Minutes}:{actualTs.Seconds}" :
                                                       $"{actualTs.Minutes}:{actualTs.Seconds}";
            string textPt2 = maxTs.TotalHours > 0 ? $"{maxTs.TotalHours}:{maxTs.Minutes}:{maxTs.Seconds}" :
                                                    $"{maxTs.Minutes}:{maxTs.Seconds}";

            ProgressText = $"{textPt1} / {textPt2}";
        }

        readonly IPlayerBroker _playerBroker;
        string _progressPercentage;

        public string ProgressPercentage { get => _progressPercentage; set { SetProperty(ref _progressPercentage, value); } }

    }
}