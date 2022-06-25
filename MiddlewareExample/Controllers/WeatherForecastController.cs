using Microsoft.AspNetCore.Mvc;

namespace MiddlewareExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public WeatherForecastController()
        {
        }

        [Permission("Admin")]
        [HttpGet("Get")]
        public IActionResult Get()
        {
            try
            {
                var model = new WeatherForecast();
                model.Date = DateTime.Now;

                return Ok(model);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [Permission("Admin")]
        [HttpPost("Post")]
        public IActionResult Post([FromBody]WeatherForecast model)
        {
            try
            {
                return Ok(model);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}