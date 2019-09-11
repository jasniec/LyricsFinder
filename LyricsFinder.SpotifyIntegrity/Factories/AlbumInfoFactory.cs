using LyricsFinder.PlayerIntegrityManager.Models;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricsFinder.SpotifyIntegrity.Factories
{
    static class AlbumInfoFactory
    {
        public static AlbumInfo Create(SimpleAlbum album)
        {
            return new AlbumInfo()
            {
                Id = album.Id,
                Name = album.Name,
                ReleaseDate = album.ReleaseDate,
                Artists = album.Artists.Select(a => ArtistInfoFactory.Create(a))
            };
        }

    }
}
