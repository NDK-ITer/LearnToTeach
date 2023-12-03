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
  deleteclassroom(params) {
    const url = '/classroom/delete';
    return axiosClient.delete(url, { params });
  },
  removemember(data) {
    const url = '/classroom/remove-member';
    return axiosClient.post(url, data);
  },
  leaveclassroom(data) {
    const url = '/classroom/leave-classroom';
    return axiosClient.post(url, data);
  },
  public() {
    const url = '/classroom/public';
    return axiosClient.get(url);
  },
  getClassById(params) {
    const url = '/classroom/id';
    return axiosClient.get(url, { params });
  },
  uploadexercise(data) {
    const url = '/Member/upload-exercise'
    return axiosClient.post(url, data);
  },
  updateexercise(data) {
    const url = '/Member/update-exercise'
    return axiosClient.put(url, data);
  },
  uploadanswer(data) {
    const url = '/Member/upload-answer'
    return axiosClient.post(url, data);
  },
  setpointanswer(data) {
    const url = '/Member/set-point-answer'
    return axiosClient.post(url, data);
  },
  updateanswer(data) {
    const url = '/Member/update-answer'
    return axiosClient.put(url, data);
  },
  uploaddoc(data) {
    const url = '/Member/upload-doc'
    return axiosClient.post(url, data);
  },
  updatedoc(data) {
    const url = '/Member/update-doc'
    return axiosClient.post(url, data);
  },
  uploadnotify(data) {
    const url = '/Member/upload-notify'
    return axiosClient.post(url, data);
  },
  updatenotify(data) {
    const url = '/Member/update-notify'
    return axiosClient.post(url, data);
  },
  deletenotify(data) {
    const url = '/Member/delete-notify'
    return axiosClient.post(url, data);
  }
};

export default classApi;
