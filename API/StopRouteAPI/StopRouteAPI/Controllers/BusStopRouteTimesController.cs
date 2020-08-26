using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositoty;

namespace StopRouteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusStopRouteTimesController : ControllerBase
    {
        private readonly IBusStopRouteTimingRepository _busStopRouteTimingRepository;

        public BusStopRouteTimesController(IBusStopRouteTimingRepository busStopRouteTimingRepository)
        {
            _busStopRouteTimingRepository = busStopRouteTimingRepository;
        }

        //// GET: api/BusStopRouteTimes
        //[HttpGet]
        //public IEnumerable<BusStopRouteTimes> Get()
        //{
        //    return _busStopRouteTimingRepository.getAllRoutesBasedonBusStops();
        //}

        // GET: api/mm/5
        [HttpGet("{id}", Name = "Get")]
        public IEnumerable<BusStopRouteTimes> Get(int id)
        {
            return _busStopRouteTimingRepository.getAllRoutesBasedonBusStops(id);
        }

    }
}
