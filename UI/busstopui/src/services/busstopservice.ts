import http from "./httpbase";

class BusStopDataService {
  getAll() {
    return http.get("/BusStop");
  }
}

  

export default new BusStopDataService();