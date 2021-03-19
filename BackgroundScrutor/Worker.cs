using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BackgroundScrutor
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IThingRepository _thingRepository;


        public Worker(ILogger<Worker> logger, IThingRepository thingRepository)
        {
            _logger = logger;
            _thingRepository = thingRepository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var result = await _thingRepository.Get("1");

                _logger.LogInformation($"result : {result}");

                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
