using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricsFinder.PlayerIntegrityManager.Models
{
    public class TrackTimeInfo
    {
        public TrackTimeInfo(int actual, int duration)
        {
            Actual = actual;
            Duration = duration;
        }

        public int Actual { get; private set; }
        public int Duration { get; private set; }
    }
}
