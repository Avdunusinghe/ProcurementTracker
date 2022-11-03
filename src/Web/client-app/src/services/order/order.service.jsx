import axios from "axios";
import environment from "./../../environments/enviroment.prod";

class OrderService {
  getAllOrders(filter) {
    return axios.post(`${environment.apiUrl}Order/getOrders`, filter);
  }

  saveOrder(order) {
    return axios.post(`${environment.apiUrl}Order/saveOrder`, order);
  }

  saveRequest(request) {
    return axios.post(
      `${environment.apiUrl}Order/savePurchaseRequest`,
      request
    );
  }
}

export default new OrderService();
