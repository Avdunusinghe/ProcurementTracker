import axios from "axios";
import environment from "./../../environments/enviroment.prod";

class OrderService {
  login(filter) {
    return axios.post(`${environment.apiUrl}Order/getOrders`, filter);
  }
}

export default new OrderService();
