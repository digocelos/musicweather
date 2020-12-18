using MusicWeatherService.Services.Spotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeatherService.Services
{
    
    public interface IMusicaTipo
    {
        string GetPlayListID();
    }

    public interface IMusicaService
    {
        string SugerirMusica();
    }
}
