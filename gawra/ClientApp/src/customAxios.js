import axios from "axios";

// Create instance
let instance = axios.create({ baseUrl: "https://localhost:5001/api" });
instance.defaults.baseURL = "https://localhost:5001/api";

// Set the AUTH token for any request
instance.interceptors.request.use(async function (config) {
  let token = "";
  config.headers.Authorization = token ? `Bearer ${token}` : "";
  return config;
});

export default instance;
