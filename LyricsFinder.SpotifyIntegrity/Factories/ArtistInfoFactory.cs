using LyricsFinder.PlayerIntegrityManager.Models;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricsFinder.SpotifyIntegrity.Factories
{
    static class ArtistInfoFactory
    {
        public static ArtistInfo Create(SimpleArtist artist)
        {
            return new ArtistInfo()
            {
                Id = artist.Id,
                Name = artist.Name
            };
        }

    }
}
