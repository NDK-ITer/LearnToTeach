import { createAsyncThunk } from '@reduxjs/toolkit';
import classApi from 'api/classApi';


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