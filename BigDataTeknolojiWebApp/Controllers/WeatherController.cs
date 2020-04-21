
using BigDataTeknoloji.Business.Model.Model.Response;
using BigDataTeknoloji.Business.Model.Model.Weather;
using BigDataTeknoloji.Business.Services.Services;
using BigDataTeknoloji.Business.Services.WeatherDTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
namespace BigDataTeknolojiWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class WeatherController : ControllerBase
    {

        private readonly IWeatherDTO _weatherDTO;
   
        public WeatherController(IWeatherDTO weatherDTO )
        {
            _weatherDTO = weatherDTO;
          
        }
        [HttpGet]
        [Route("[action]")]
        public ServiceResponse<WeatherModel> Get(string locationName)
        {

            return _weatherDTO.GetWheaterByLocationName(locationName);
        }
    }
}