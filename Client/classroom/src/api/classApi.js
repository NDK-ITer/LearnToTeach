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
  removemember(params) {
    const url = '/classroom/remove-member';
    return axiosClient.delete(url, { params });
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
  deleteexercise(params) {
    const url = '/Member/delete-exercise';
    return axiosClient.delete(url, { params });
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
  deleteanswer(params) {
    const url = '/Member/delete-answer';
    return axiosClient.delete(url, { params });
  },
  uploaddoc(data) {
    const url = '/Member/upload-doc'
    return axiosClient.post(url, data);
  },
  updatedoc(data) {
    const url = '/Member/update-doc'
    return axiosClient.post(url, data);
  },
  deletedocument(params) {
    const url = '/Member/delete-document';
    return axiosClient.delete(url, { params });
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
