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
    public class RouteController : ControllerBase
    {
        private readonly IBusStopRouteTimingRepository _busStopRouteTimingRepository;

        public RouteController(IBusStopRouteTimingRepository busStopRouteTimingRepository)
        {
            _busStopRouteTimingRepository = busStopRouteTimingRepository;
        }

        //[HttpGet]
        //[Route("api/[controller]/RouteDetails")]
        //public IEnumerable<BusStopRouteTimes> RouteDetails(int busStopId)
        //{
        //    return null;
        //}

        //[HttpGet]
        //public IEnumerable<BusStopRouteTimes> Get(int Id)
        //{
        //   return _busStopRouteTimingRepository.getDetails(Id);
        //}

        [HttpGet]
        public IEnumerable<BusStops> Get()
        {
            

            _busStopRouteTimingRepository.getBusstopNonEFDetails();

            return _busStopRouteTimingRepository.getBusstopDetails();
            return null;
        }

    }
}