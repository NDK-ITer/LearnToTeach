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
  changepassword(data) {
    const url = '/account/change-password';
    return axiosClient.post(url, data);
  },
  forgetpassword(data) {
    const url = '/account/forget-password';
    return axiosClient.post(url, data);
  },
  editinfor(data) {
    const url = '/account/edit-infor';
    return axiosClient.post(url, data);
  },
  verifyotp(data) {
    const url = '/account/verify-otp';
    return axiosClient.post(url, data);
  },
  resetpassword(data) {
    const url = '/account/reset-password';
    return axiosClient.post(url, data);
  },
  getclassroom(data) {
    const url = '/account/user-data';
    return axiosClient.post(url, data);
  },
};

export default userApi;
