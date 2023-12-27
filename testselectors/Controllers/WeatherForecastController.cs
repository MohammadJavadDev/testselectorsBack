using Microsoft.AspNetCore.Mvc;
using TestSectorsApp.Data;
using TestSectorsApp.Domin;
using testselectors.Domin;

namespace testselectors.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class SectorsController : ControllerBase
    {

        private readonly ILogger<SectorsController> _logger;
        private readonly TestSectorsAppContext db;

        public SectorsController(ILogger<SectorsController> logger, TestSectorsAppContext db)
        {
            _logger = logger;
            this.db = db;
        }

        [HttpGet(Name = "GetSectors")]
        public IEnumerable<Sectors> Get()
        {
            return db.Sectors.ToArray();
        }
    }

    
    [ApiController]
    [Route("[controller]")]
    public class AcceptFormController : ControllerBase
    {

        private readonly ILogger<AcceptFormController> _logger;
        private readonly TestSectorsAppContext db;

        public AcceptFormController(ILogger<AcceptFormController> logger, TestSectorsAppContext db)
        {
            _logger = logger;
            this.db = db;
        }

        [HttpGet(Name = "GetAcceptForm")]
        public IEnumerable<AcceptForm> Get()
        {
            return db.AcceptForms.ToArray();
        }

        [HttpPost(Name = "InsertAcceptForm")]
        public IActionResult Post(AcceptForm form)
        {
      db.AcceptForms.Add(form);
            db.SaveChanges();
            return  Ok(form);
        }

        [HttpPut(Name = "UpdateAcceptForm")]
        public IActionResult Put(AcceptForm form)
        {
            db.AcceptForms.Update(form);
            db.SaveChanges();
            return Ok(form);
        }
    }
}
