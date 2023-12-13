import { unwrapResult } from '@reduxjs/toolkit';
import { useSnackbar } from 'notistack';
import PropTypes from 'prop-types';
import React from 'react';
import { useDispatch } from 'react-redux';
import { useLocalContext } from 'context';
import { useHistory } from 'react-router-dom';
import { changepassword, resetpassword } from '../userSlice';
import ChangePasswordForm from './ChangePasswordForm';
ChangePassword.propTypes = {
    closeDialog: PropTypes.func,
};

function ChangePassword(props) {
    const dispatch = useDispatch();
    const { enqueueSnackbar } = useSnackbar();
    const { user } = useLocalContext();
    const history = useHistory();
    const { classData } = props;
    const handleSubmit = async (values) => {

        try {
            values.Email = user.email;
            const action = changepassword(values);
            const resultAction = await dispatch(action);
            unwrapResult(resultAction);
            const check = resultAction.payload
            console.log(resultAction.payload)
            if (typeof check.status != 'undefined') {
                if (check.status === 1) {
                    enqueueSnackbar(check.message, { variant: 'success' });
                } else {
                    enqueueSnackbar(check.message, { variant: 'error' });
                }
                // close dialog
                const { closeDialog } = props;
                if (closeDialog) {
                    closeDialog();
                }
            }

        } catch (error) {
            console.log('Failed', error);
            enqueueSnackbar(error.message, { variant: 'error' });
        }
    };

    return (
        <div>
            <ChangePasswordForm onSubmit={handleSubmit} />
        </div>
    );
}

export default ChangePassword;
