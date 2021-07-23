import axios from "axios";

const instance = axios.create({
  baseURL: `${window.location.href}`,
});

axios.interceptors.request.use(function (config) {
  return config;
});

// TODO: Set auth header retrieved after login.
instance.defaults.headers.common["Authorization"] = "AUTH TOKEN FROM INSTANCE";

export default instance;
