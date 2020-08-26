using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositoty;
using Microsoft.AspNetCore.Cors;

namespace StopRouteAPI.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class BusStopController : ControllerBase
    {

        private readonly IBusStopRouteTimingRepository _busStopRouteTimingRepository;

        public BusStopController(IBusStopRouteTimingRepository busStopRouteTimingRepository)
        {
            _busStopRouteTimingRepository = busStopRouteTimingRepository;
        }
        // GET: api/BusStop
        [HttpGet]
        public IEnumerable<BusStops> Get()
        {
            return _busStopRouteTimingRepository.getAllBusStops();
        }

      
    }
}
