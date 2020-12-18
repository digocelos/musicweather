using Microsoft.AspNetCore.Components;
using SpotifyApi.NetCore.Authorization;
using SpotifyApi.NetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MusicWeatherService.Services.Spotify
{

    public class SpotifyService : IMusicaService
    {
        private const int _limit = 30;
        private IMusicaTipo _musicaTipo;

        [Inject]
        private IHttpClientFactory _clientFactory { get; set; }

        public SpotifyService(IHttpClientFactory httpClientFactory, IMusicaTipo musicaTipo)
        {
            _clientFactory = httpClientFactory;
            _musicaTipo = musicaTipo;
        }

        public string SugerirMusica()
        {
            return GetMusica().GetAwaiter().GetResult();
        }

        private async Task<string> GetMusica()
        {
            var client = _clientFactory.CreateClient("Spotify");
            var accounts = new AccountsService(client);
            var playlists = new PlaylistsApi(client, accounts);

            PlaylistPaged playlist = await playlists.GetTracks(_musicaTipo.GetPlayListID(), limit: _limit);

            //Excolhe uma música aleatória da playlist
            Random rand = new Random();
            return playlist.Items[rand.Next(playlist.Items.Count())].Track.Name;
        }
    }
}
