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
    formData.append('FileUpload', payload.FileUpload[0]);
    const data = await classApi.uploadexercise(formData);
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