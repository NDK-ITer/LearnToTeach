import { unwrapResult } from '@reduxjs/toolkit';
import { useSnackbar } from 'notistack';
import React, { useEffect, useState } from 'react';
import PropTypes from 'prop-types';
import { useDispatch } from 'react-redux';
import { useHistory } from 'react-router-dom';
import { useLocalContext } from 'context';
import { editinfor } from 'components/Auth/userSlice';
import UpdateInforForm from './UpdateInforForm';

UpdateInfor.propTypes = {
    closeDialog: PropTypes.func,
    userInfor: PropTypes.object
};

function UpdateInfor(props) {
    const { userInfor } = props;
    console.log("test")
    console.log(userInfor)
    const dispatch = useDispatch();
    const { enqueueSnackbar } = useSnackbar();
    const history = useHistory();
    const handleSubmit = async (values) => {
        try {
            values.IdUser = userInfor.id
            const action = editinfor(values);
            const resultAction = await dispatch(action);
            unwrapResult(resultAction);
            const check = resultAction.payload
            console.log(resultAction.payload)
            if (check.status == 1) {
                enqueueSnackbar(check.message, { variant: 'success' });
                window.location.reload()
            } else {
                enqueueSnackbar(check.message, { variant: 'error' });
            }
            // close dialog
            const { closeDialog } = props;
            if (closeDialog) {
                closeDialog();
            }
        } catch (error) {
            console.log('Failed to login:', error);
            enqueueSnackbar(error.message, { variant: 'error' });
        }
    };

    return (
        <div>
            <UpdateInforForm onSubmit={handleSubmit} userInfor={userInfor} />
        </div>
    )
}

export default UpdateInfor;
