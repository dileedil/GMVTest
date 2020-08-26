using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositoty
{
    public interface IBusStopRouteTimingRepository
    {
        IEnumerable<BusStopRouteTimes> getDetails(int busStopId);
        IEnumerable<BusStops> getBusstopDetails();
        void getBusstopNonEFDetails();
        List<BusStops> getAllBusStops();
        List<BusStopRouteTimes> getAllRoutesBasedonBusStops(int id);
    }
}
