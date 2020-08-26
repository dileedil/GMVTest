import http from "./httpbase";

class BusStopRouteTimeDataService {
    get(id: number) {
        return http.get(`/BusStopRouteTimes/${id}`);
    }
}

  

export default new BusStopRouteTimeDataService();