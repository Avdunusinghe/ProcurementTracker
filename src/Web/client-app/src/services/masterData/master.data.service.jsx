import axios from "axios";
import environment from "./../../environments/enviroment.prod";

class MasterDataService {
  getSupplierMasterData() {
    return axios.get(`${environment.apiUrl}MasterData/getSupplierMasterData`);
  }

  getProductMasterData() {
    return axios.get(`${environment.apiUrl}MasterData/getProductMasterData`);
  }

  getOrderStatusMasterData() {
    return axios.get(
      `${environment.apiUrl}MasterData/getOrderStatusMasterData`
    );
  }
}

export default new MasterDataService();
