using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeatherService.Models
{
    public class Parametro
    {
        public string cidade { get; set; }
        public GeoPoint geo { get; set; }

        public Boolean valida()
        {
            return ( (!cidade.Trim().Equals("")) || (geo.valida()) );
        }
    }

    public class GeoPoint
    {
        public double latitude { get; set; }
        public double longitude { get; set; }

        public Boolean valida()
        {
            if (latitude < -90 || latitude > 90)
            {
                return false;
            }
            else if (longitude < -180 || longitude > 180)
            {
                return false;
            }
            return true;
        }
    }
}
