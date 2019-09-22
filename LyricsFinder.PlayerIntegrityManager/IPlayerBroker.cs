using LyricsFinder.PlayerIntegrityManager.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricsFinder.PlayerIntegrityManager
{
    public interface IPlayerBroker
    {
        string Name { get; }

        void Connect();
        Task<Bitmap> GetImageAsync();

        event Action<TrackInfo> TrackChanged;
        event Action<TrackTimeInfo> TrackTimeChanged;
    }
}
