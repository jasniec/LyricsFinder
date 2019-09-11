using System.Collections.Generic;

namespace LyricsFinder.PlayerIntegrityManager.Models
{
    public class AlbumInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public IEnumerable<ArtistInfo> Artists { get; set; }
    }
}