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

  getPurchesById(id) {
    return axios.get(`${environment.apiUrl}Order/getPurchaseRequestById/` + id);
  }

  savepurchaseRequest(model) {
    return axios.post(`${environment.apiUrl}Order/savePurchaseRequest`, model);
  }
}

export default new OrderService();
