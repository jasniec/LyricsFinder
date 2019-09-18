using LyricsFinder.PlayerIntegrityManager;
using LyricsFinder.PlayerIntegrityManager.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricsFinder.Core.MVVM.Song
{
    class SongViewModel : BindableBase
    {
        public SongViewModel(IPlayerBroker playerBroker)
        {
            _playerBroker = playerBroker;

            _playerBroker.TrackTimeChanged += _playerBroker_TrackTimeChanged;
            _playerBroker.TrackChanged += _playerBroker_TrackChanged;
            _playerBroker.Connect();
        }

        public string SongName { get => _songName; private set { SetProperty(ref _songName, value); /*_songName = value; RaisePropertyChanged(); */} }
        public string AlbumName { get => _albumName; private set => SetProperty(ref _albumName, value); }
        public string ArtistName { get => _artistName; private set => SetProperty(ref _artistName, value); }
        public uint ProgressMax { get => _progressMax; private set => SetProperty(ref _progressMax, value); }
        public uint ProgressActual { get => _progressActual; private set => SetProperty(ref _progressActual, value); }
        public string ProgressText { get => _progressText; private set => SetProperty(ref _progressText, value); }

        string _songName;
        string _albumName;
        string _artistName;
        string _progressText;
        uint _progressMax;
        uint _progressActual;

        private void _playerBroker_TrackChanged(TrackInfo track)
        {
            SongName = track.Name;
        }

        private void _playerBroker_TrackTimeChanged(TrackTimeInfo trackInfo)
        {
            ProgressMax = trackInfo.Duration;
            ProgressActual = trackInfo.Actual;

            TimeSpan actualTs = new TimeSpan((long)ProgressActual);
            TimeSpan maxTs = new TimeSpan((long)ProgressMax);

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