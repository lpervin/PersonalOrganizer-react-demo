import axios, { AxiosResponse } from 'axios';

axios.defaults.baseURL = process.env.REACT_APP_API_URL;

axios.interceptors.request.use(
        (config) => {
          const token = window.localStorage.getItem('jwt');
          console.log('token', token);
          if (token) config.headers.Authorization = `Bearer ${token}`;
          return config;
        },
        error => {
          return Promise.reject(error);
        }
 );

const responseBody = (response: AxiosResponse) => response.data;

const requests = {
    get: (url: string) =>
    axios
      .get(url)
      .then(responseBody),
  post: (url: string, body?: {}|null) =>
    axios
      .post(url, body)
      .then(responseBody),
  put: (url: string, body: {}) =>
    axios
      .put(url, body)
      .then(responseBody),
  del: (url: string) =>
    axios
      .delete(url)
      .then(responseBody),
  postForm: (url: string, file: Blob) => {
    let formData = new FormData();
    formData.append('File', file);
    return axios
      .post(url, formData, {
        headers: { 'Content-type': 'multipart/form-data' }
      })
      .then(responseBody);
  }
};
export {requests, responseBody};

