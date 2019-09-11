using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricsFinder.PlayerIntegrityManager.Models
{
    public class TrackInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ArtistInfo> Artists { get; set; }
        public AlbumInfo Album { get; set; }
    }
}
