using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeatherService.Services.OpenWeatherMap
{
    public class OpenWeatherMapResponse
    {
        public OpenWeatherResponseMain main { get; set; }
    }

    public class OpenWeatherResponseMain
    {
        public float temp { get; set; }
    }
}
