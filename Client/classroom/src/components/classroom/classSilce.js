import { createAsyncThunk } from '@reduxjs/toolkit';
import classApi from 'api/classApi';
import formatDate from 'constants/formatdate';


export const createClassroom = createAsyncThunk('classroom/create', async (payload) => {

    const formData = new FormData()
    console.log(payload);
    formData.append('idUserHost', payload.idUserHost);
    formData.append('name', payload.name);
    formData.append('description', payload.description);
    formData.append('isPrivate', payload.isPrivate);
    formData.append('key', payload.key);
    const data = await classApi.createclassroom(formData);

    return data;
});
export const joinClassroom = createAsyncThunk('classroom/join', async (payload) => {

    const formData = new FormData()
    console.log(payload);
    formData.append('idClassroom', payload.idClassroom);
    formData.append('idMember', payload.idMember);
    formData.append('key', payload.key);
    const data = await classApi.joinclassroom(formData);
    return data;
});
export const uploadexercise = createAsyncThunk('classroom/uploadexercise', async (payload) => {

    const formData = new FormData()
    console.log(payload);
    formData.append('IdClassroom', payload.IdClassroom);
    formData.append('IdMember', payload.IdMember);
    formData.append('Name', payload.Name);
    formData.append('Description', payload.Description);
    formData.append('Deadline', formatDate(payload.Deadline));
    formData.append('FileUpload', payload.FileUpload);
    const data = await classApi.uploadexercise(formData);
    return data;
});
export const editexercise = createAsyncThunk('classroom/editexercise', async (payload) => {

    const formData = new FormData()
    console.log(payload);
    formData.append('IdClassroom', payload.IdClassroom);
    formData.append('IdMember', payload.IdMember);
    formData.append('IdExercise', payload.IdExercise);
    formData.append('Name', payload.Name);
    formData.append('Description', payload.Description);
    formData.append('Deadline', formatDate(payload.Deadline));
    formData.append('FileUpload', payload.FileUpload);
    const data = await classApi.updateexercise(formData);
    return data;
});
export const uploadnotify = createAsyncThunk('classroom/uploadnotify', async (payload) => {

    const formData = new FormData()
    console.log(payload);
    formData.append('IdClassroom', payload.IdClassroom);
    formData.append('IdMember', payload.IdMember);
    formData.append('NameNotify', payload.NameNotify);
    formData.append('Decription', payload.Description);
    const data = await classApi.uploadnotify(formData);
    return data;
});
export const uploaddoc = createAsyncThunk('classroom/uploaddoc', async (payload) => {

    const formData = new FormData()
    console.log(payload);
    formData.append('IdClassroom', payload.IdClassroom);
    formData.append('IdMember', payload.IdMember);
    formData.append('FileUpload', payload.FileUploadDocument);
    formData.append('Decription', payload.Decription);
    const data = await classApi.uploaddoc(formData);
    return data;
});
export const uploadAnswer = createAsyncThunk('classroom/uploadAnswer', async (payload) => {

    const formData = new FormData()
    console.log(payload);
    formData.append('IdClassroom', payload.IdClassroom);
    formData.append('IdMember', payload.IdMember);
    formData.append('IdExercise', payload.IdExercise);
    formData.append('FileUpload', payload.FileUploadAnswer);
    formData.append('Content', payload.Content);
    const data = await classApi.uploadanswer(formData);
    return data;
});
export const editAnswer = createAsyncThunk('classroom/editAnswer', async (payload) => {

    const formData = new FormData()
    console.log(payload);
    formData.append('IdClassroom', payload.IdClassroom);
    formData.append('IdMember', payload.IdMember);
    formData.append('IdExercise', payload.IdExercise);
    formData.append('FileUpload', payload.FileUploadAnswer);
    formData.append('Content', payload.Content);
    const data = await classApi.updateanswer(formData);
    return data;
});
export const setpointanswer = createAsyncThunk('classroom/setpointanswer', async (payload) => {

    const formData = new FormData()
    console.log(payload);
    formData.append('IdClassroom', payload.IdClassroom);
    formData.append('IdMember', payload.IdMember);
    formData.append('IdExercise', payload.IdExercise);
    formData.append('IdUserHost', payload.IdUserHost);
    formData.append('point', payload.point);
    const data = await classApi.setpointanswer(formData);
    return data;
});