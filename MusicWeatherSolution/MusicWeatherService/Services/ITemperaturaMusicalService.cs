using MusicWeatherService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeatherService.Services
{
    public interface ITemperaturaMusicalService
    {
        Musica SugerirMusica(Parametro parametro);
    }
}
