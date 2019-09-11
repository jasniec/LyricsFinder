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

        string songName = "";

        private void _playerBroker_TrackChanged(TrackInfo track)
        {
            songName = track.Name;
        }

        private void _playerBroker_TrackTimeChanged(PlayerIntegrityManager.Models.TrackTimeInfo obj)
        {
            ProgressPercentage = $"{songName} - {obj.Actual} / {obj.Duration}";
        }

        readonly IPlayerBroker _playerBroker;
        string _progressPercentage;

        public string ProgressPercentage { get => _progressPercentage; set { SetProperty(ref _progressPercentage, value); } }

    }
}