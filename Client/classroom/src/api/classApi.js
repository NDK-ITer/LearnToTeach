import axiosClient from './axiosClient';

const classApi = {

  createclassroom(data) {
    const url = '/classroom/create';
    return axiosClient.post(url, data);
  },
  joinclassroom(data) {
    const url = '/classroom/join-classroom';
    return axiosClient.post(url, data);
  },
  updateclassroom(data) {
    const url = '/classroom/update';
    return axiosClient.post(url, data);
  },
  deleteclassroom(data) {
    const url = ' /classroom/delete';
    return axiosClient.post(url, data);
  },
  removemember(data) {
    const url = '/classroom/remove-member';
    return axiosClient.post(url, data);
  },
  public() {
    const url = '/classroom/public';
    return axiosClient.get(url);
  },
  getClassById(params) {
    const url = '/classroom/id';
    return axiosClient.get(url, { params});
  },

};

export default classApi;
