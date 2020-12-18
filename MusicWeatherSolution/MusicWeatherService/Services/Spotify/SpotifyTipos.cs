using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeatherService.Services.Spotify
{
    public class SpotifyRock : IMusicaTipo
    {
        public string GetPlayListID()
        {
            return "2nJNtGzmkQfktp5Dra6zyX";
        }
    }

    public class SpotifyClassica : IMusicaTipo
    {
        public string GetPlayListID()
        {
            return "37i9dQZF1DZ06evO1qAOEE";
        }
    }

    public class SpotifyPop : IMusicaTipo
    {
        public string GetPlayListID()
        {
            return "37i9dQZF1DX1ngEVM0lKrb";
        }
    }

    public class SpotifyFesta : IMusicaTipo
    {
        public string GetPlayListID()
        {
            return "6bbapY8Y7nJen3xLzPFwnZ";
        }
    }
}
