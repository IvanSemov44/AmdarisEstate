using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Estate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private ILoggerManager _logger;

        public WeatherForecastController(ILoggerManager logger)
        {
            this._logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInfo("This is info message from our values controller");
            _logger.LogDebug("This is debug message from our values controller");
            _logger.LogWarn("This is warn message from our values controller");
            _logger.LogError("This is error message from our values controller");

            return new string[] { "value1", "value2" };
        }
    }
}