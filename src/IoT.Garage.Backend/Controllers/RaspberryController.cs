using System;
using System.Collections.Generic;
using System.Linq;
using IoT.RaspberryPi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IoT.Garage.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RaspberryController : ControllerBase
    {
        private readonly IRaspberryPi _raspberry;
        private readonly ILogger<RaspberryController> _logger;

        public RaspberryController(IRaspberryPi raspberry, ILogger<RaspberryController> logger)
        {
            _raspberry = raspberry;
            _logger = logger;
        }

    }
}
