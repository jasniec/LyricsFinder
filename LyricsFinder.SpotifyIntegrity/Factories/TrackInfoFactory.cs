using LyricsFinder.PlayerIntegrityManager.Models;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricsFinder.SpotifyIntegrity.Factories
{
    static class TrackInfoFactory
    {
        public static TrackInfo Create(FullTrack item)
        {
            return new TrackInfo()
            {
                Id = item.Id,
                Name = item.Name,
                Album = AlbumInfoFactory.Create(item.Album),
                Artists = item.Artists.Select(a => ArtistInfoFactory.Create(a))
            };
        }

    }
}
