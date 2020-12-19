using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeatherService.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[controller]")]
    [ApiController]
    public class MusicWeatherStatusController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Servidor ok";
        }
    }
}
