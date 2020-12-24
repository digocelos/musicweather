using MusicWeatherService.Models;

namespace MusicWeatherService.Services
{
    //Contrato para obter a temperatura atual baseado nos parâmetros
    public interface ITemperaturaService
    {
        double GetTemperaturaAtual(Parametro parametro);
    }
}
