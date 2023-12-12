import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import userApi from 'api/userApi';
import StorageKeys from 'constants/storage-keys';

export const register = createAsyncThunk('account/register', async (payload) => {

    const formData = new FormData()
    formData.append('FirstName', payload.FirstName);
    formData.append('LastName', payload.LastName);
    formData.append('Email', payload.Email);
    formData.append('PhoneNumber', payload.PhoneNumber);
    formData.append('Password', payload.Password);
    formData.append('PasswordIsConfirmed', payload.PasswordIsConfirmed);
    const data = await userApi.register(formData);
    return data;
});

export const login = createAsyncThunk('account/login', async (payload) => {

    const formData = new FormData()
    formData.append('Email', payload.Email);
    formData.append('Password', payload.Password);
    const data = await userApi.login(formData);
    console.log("form" + formData);
    // save data to local storage
    localStorage.setItem(StorageKeys.TOKEN, data.jwtToken);
    localStorage.setItem(StorageKeys.USER, JSON.stringify(data));
    return data;
});
export const forgetpassword = createAsyncThunk('account/forget-password', async (payload) => {

    const formData = new FormData()
    formData.append('Email', payload.Email);
    const data = await userApi.forgetpassword(formData);
    console.log(data);
    return data;
});
export const editinfor = createAsyncThunk('account/editinfor', async (payload) => {

    const formData = new FormData()
    formData.append('IdUser', payload.IdUser);
    formData.append('FirstName', payload.FirstName);
    formData.append('LastName', payload.LastName);
    formData.append('Avatar', payload.Avatar);
    // formData.append('Email', payload.Email);
    formData.append('PhoneNumber', payload.PhoneNumber);
    const data = await userApi.editinfor(formData);
    console.log(data);
    return data;
});

export const verifyotp = createAsyncThunk('account/verify-otp', async (payload) => {

    const formData = new FormData()
    formData.append('Email', payload.Email);
    formData.append('OTP', payload.OTP);
    const data = await userApi.verifyotp(formData);
    console.log(data);
    return data;
});

export const resetpassword = createAsyncThunk('account/reset-password', async (payload) => {

    const formData = new FormData()
    formData.append('Email', payload.Email);
    formData.append('NewPassword', payload.NewPassword);
    formData.append('ConfirmPassword', payload.ConfirmPassword);
    const data = await userApi.resetpassword(formData);
    console.log(data);
    return data;
});


const userSlice = createSlice({
    name: 'user',
    initialState: {
        current: JSON.parse(localStorage.getItem(StorageKeys.USER)) || {},
        settings: {},
    },
    reducers: {
        logout(state) {
            // clear local storage
            localStorage.removeItem(StorageKeys.USER);
            localStorage.removeItem(StorageKeys.TOKEN);

            state.current = {};
        },
    },
    extraReducers: {
        [register.fulfilled]: (state, action) => {
            state.current = action.payload;
        },

        [login.fulfilled]: (state, action) => {
            state.current = action.payload;
        },
    },
});

const { actions, reducer } = userSlice;
export const { logout } = actions;
export default reducer;
