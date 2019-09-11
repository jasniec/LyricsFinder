using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricsFinder.SpotifyIntegrity.Notifiers
{
    interface INotifier
    {
        void Refresh(PlaybackContext playback);
        void Reset();
    }
}
