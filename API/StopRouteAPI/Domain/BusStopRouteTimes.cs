using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class BusStopRouteTimes
    {
        public int Id { get; set; }
        public int StopId { get; set; }
        public int RouteId { get; set; }

        public string BusStop { get; set; }
        public string Route { get; set; }
        public string StartTime { get; set; }
    }
}
