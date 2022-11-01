import axios from "axios";
import environment from "./../../environments/enviroment.prod";

class AuthService {
  login(authenticationModel) {
    return axios.post(
      `${environment.apiUrl}Authentication/login`,
      authenticationModel
    );
  }
}

export default new AuthService();
