import axios from "axios";
import environment from "../environments/enviroment.prod";
function jwtInterceptor() {
  axios.interceptors.request.use((request) => {
    const currentUser = JSON.parse(localStorage.getItem("CSSEcurrentUser"));
    const isApiUrl = request.url.startsWith(environment.apiUrl);
    if (isApiUrl && currentUser != null) {
      request.headers.Authorization = `Bearer ${currentUser.token}`;
      console.log(request);
    }

    return request;
  });
}

export default jwtInterceptor;
