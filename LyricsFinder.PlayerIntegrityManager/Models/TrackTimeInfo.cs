using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricsFinder.PlayerIntegrityManager.Models
{
    public class TrackTimeInfo
    {
        public TrackTimeInfo(uint actual, uint duration)
        {
            Actual = actual;
            Duration = duration;
        }

        public uint Actual { get; private set; }
        public uint Duration { get; private set; }
    }
}
