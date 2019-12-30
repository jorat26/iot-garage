using System;
using IoT.RaspberryPi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IoT.Garage.Backend.Controllers
{
    [ApiController]
    [Route("[controller]/{pinNumber}/[action]")]
    public class GpioController : ControllerBase
    {
        private readonly IRaspberryPi _raspberry;
        private readonly ILogger<GpioController> _logger;

        public GpioController(IRaspberryPi raspberry, ILogger<GpioController> logger)
        {
            _raspberry = raspberry;
            _logger = logger;
        }

        [HttpPost]
        public void Open([FromRoute] int pinNumber)
        {
            _raspberry.Gpio[pinNumber].Open();
        }

        [HttpPost]
        public void Close([FromRoute] int pinNumber)
        {
            _raspberry.Gpio[pinNumber].Close();
        }

        [HttpPost]
        public void SetMode([FromRoute] int pinNumber, [FromBody] GpioModes mode)
        {
            _raspberry.Gpio[pinNumber].SetMode(mode);
        }

        [HttpPost]
        public void Pulse([FromRoute] int pinNumber, [FromBody] PulseSettings settings = null)
        {
            settings = settings ?? new PulseSettings();
            _raspberry.Gpio[pinNumber].Pulse(settings.Value, (int)settings.Duration.TotalMilliseconds);
        }

        public class PulseSettings
        {
            public GpioValues Value { get; set; } = GpioValues.High;

            public TimeSpan Duration { get; set; } = TimeSpan.FromSeconds(1);
        }
    }
}
