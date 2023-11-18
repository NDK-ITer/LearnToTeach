import axiosClient from './axiosClient';

const userApi = {
  register(data) {
    const url = '/account/register';
    return axiosClient.post(url, data);
  },

  login(data) {
    const url = '/account/login';
    return axiosClient.post(url, data);
  },
};

export default userApi;
