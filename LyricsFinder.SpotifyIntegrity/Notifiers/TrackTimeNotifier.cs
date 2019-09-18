using LyricsFinder.PlayerIntegrityManager.Models;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace LyricsFinder.SpotifyIntegrity.Notifiers
{
    class TrackTimeNotifier : INotifier
    {
        public TrackTimeNotifier(SpotifyWebAPI api)
        {
            _api = api;

        }

        readonly SpotifyWebAPI _api;
        int currentTime = -1;

        public void Refresh(PlaybackContext playback)
        {
            if (playback?.HasError() == false && playback.Item?.HasError() == false &&
                playback.ProgressMs != currentTime)
            {
                TrackTimeChanged?.Invoke(new TrackTimeInfo((uint)playback.ProgressMs, (uint)playback.Item.DurationMs));
                currentTime = playback.ProgressMs;
            }
        }

        public void Reset()
        {
            currentTime = -1;
        }

        public event Action<TrackTimeInfo> TrackTimeChanged;
    }
}
