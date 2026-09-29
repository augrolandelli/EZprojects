using api.Common;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        [HttpGet("error-app")]
        public void Geterror()
        {
            throw new AppException(404, "Proyecto no encontrado");
        }

        [HttpGet("error-bug")]
        public void Getbug()
        {
            throw new InvalidOperationException("detalle secreto interno");
        }
    }
}
