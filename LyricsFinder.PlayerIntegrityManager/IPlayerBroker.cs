using LyricsFinder.PlayerIntegrityManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricsFinder.PlayerIntegrityManager
{
    public interface IPlayerBroker
    {
        string Name { get; }

        void Connect();

        //event Action<bool> PlaybackStateChanged;
        event Action<TrackInfo> TrackChanged;
        event Action<TrackTimeInfo> TrackTimeChanged;
    }
}
