using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private const int DelayMilliseconds = 1000;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("Async")]
        public async Task<IEnumerable<WeatherForecast>> TaskDelayThenGet(CancellationToken cancellationToken)
        {
            await Task.Delay(DelayMilliseconds, cancellationToken);
            return Get();
        }

        [HttpGet("Sleep")]
        public IEnumerable<WeatherForecast> SleepThenGet(CancellationToken cancellationToken)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(DelayMilliseconds / 10);
                cancellationToken.ThrowIfCancellationRequested();
            }

            return Get();
        }

        private IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }
    }
}
