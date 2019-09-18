using LyricsFinder.PlayerIntegrityManager.Models;
using LyricsFinder.SpotifyIntegrity.Factories;
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
    class SongChangedNotifier : INotifier
    {
        public SongChangedNotifier(SpotifyWebAPI api)
        {
            _api = api;
        }

        readonly SpotifyWebAPI _api;
        string currentTrackId = string.Empty;

        public void Refresh(PlaybackContext playback)
        {
            if (playback?.HasError() == false && playback.Item?.HasError() == false &&
                playback.Item.Id != currentTrackId)
            {
                var trackInfo = TrackInfoFactory.Create(playback.Item);

                currentTrackId = playback.Item.Id;

                TrackChanged?.Invoke(trackInfo);
            }
        }

        public void Reset()
        {
            currentTrackId = string.Empty;
        }        

        public event Action<TrackInfo> TrackChanged;
    }
}
