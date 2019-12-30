using System;
using System.Threading;
using System.Threading.Tasks;
using IoT.RaspberryPi;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IoT.Garage.Backend
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IRaspberryPi _raspberry;

        public Worker(IRaspberryPi raspberry, ILogger<Worker> logger)
        {
            _raspberry = raspberry;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _raspberry.Streamer.Start(null, null, TimeSpan.FromTicks(DateTime.Now.Ticks));
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
            }

            _raspberry.Streamer.Stop();
        }
    }
}