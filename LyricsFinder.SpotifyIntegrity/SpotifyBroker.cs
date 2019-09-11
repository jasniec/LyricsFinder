using LyricsFinder.PlayerIntegrityManager;
using LyricsFinder.PlayerIntegrityManager.Models;
using LyricsFinder.SpotifyIntegrity.Notifiers;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace LyricsFinder.SpotifyIntegrity
{
    public class SpotifyBroker : IPlayerBroker
    {
        public SpotifyBroker()
        {
            notifiers = new List<INotifier>();

            TrackTimeNotifier ttn = new TrackTimeNotifier(_api);
            ttn.TrackTimeChanged += t => TrackTimeChanged?.Invoke(t);

            SongChangedNotifier scn = new SongChangedNotifier(_api);
            scn.TrackChanged += s => TrackChanged?.Invoke(s);

            notifiers.Add(ttn);
            notifiers.Add(scn);

            _clientId = string.IsNullOrEmpty(_clientId)
                ? Environment.GetEnvironmentVariable("SPOTIFY_CLIENT_ID")
                : _clientId;

            _secretId = string.IsNullOrEmpty(_secretId)
                ? Environment.GetEnvironmentVariable("SPOTIFY_SECRET_ID")
                : _secretId;
        }

        public string Name => "Spotify";

        const string _localAddress = "http://localhost:4002";

        readonly string _clientId = "";
        readonly string _secretId = "";
        readonly List<INotifier> notifiers;
        Token _token;
        SpotifyWebAPI _api;
        AuthorizationCodeAuth auth;
        Timer refreshTimer;

        public void Connect()
        {
            auth = new AuthorizationCodeAuth(_clientId, _secretId, _localAddress, _localAddress, Scope.UserReadPlaybackState);
            auth.AuthReceived += Auth_AuthReceived;
            auth.Start();
            //string uri = auth.GetUri();
            auth.OpenBrowser();
        }

        private async void Auth_AuthReceived(object sender, AuthorizationCode payload)
        {
            AuthorizationCodeAuth auth = (AuthorizationCodeAuth)sender;
            auth.Stop();

            _token = await auth.ExchangeCode(payload.Code);
            _api = new SpotifyWebAPI
            {
                AccessToken = _token.AccessToken,
                TokenType = _token.TokenType
            };

            RunSpotifyApi();
        }

        private void RunSpotifyApi()
        {
            refreshTimer = new Timer(100);
            refreshTimer.Elapsed += OnRefresh;
            refreshTimer.Start();
        }

        private async void OnRefresh(object sender, ElapsedEventArgs e)
        {
            PlaybackContext playback = await _api.GetPlaybackAsync();

            Parallel.ForEach(notifiers, n => { n.Refresh(playback); });
        }


        //public event Action<bool> PlaybackStateChanged;
        public event Action<TrackTimeInfo> TrackTimeChanged;
        public event Action<TrackInfo> TrackChanged;

    }
}
