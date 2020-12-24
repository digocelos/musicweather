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

        private readonly IHttpClientFactory _clientFactory;

        public SpotifyService(IHttpClientFactory httpClientFactory)
        {
            _clientFactory = httpClientFactory;
        }

        public string SugerirMusica(IMusicaTipo musicaTipo)
        {
            return GetMusica(musicaTipo).GetAwaiter().GetResult();
        }

        private async Task<string> GetMusica(IMusicaTipo musicaTipo)
        {
            var client = _clientFactory.CreateClient("Spotify");
            var accounts = new AccountsService(client);
            var playlists = new PlaylistsApi(client, accounts);

            PlaylistPaged playlist = await playlists.GetTracks(musicaTipo.GetPlayListID(), limit: _limit);

            //Excolhe uma música aleatória da playlist
            Random rand = new Random();
            return playlist.Items[rand.Next(playlist.Items.Count())].Track.Name;
        }
    }
}
