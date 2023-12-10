import { unwrapResult } from '@reduxjs/toolkit';
import { useSnackbar } from 'notistack';
import PropTypes from 'prop-types';
import React from 'react';
import { useDispatch } from 'react-redux';
import { useLocalContext } from 'context';
import ResetPasswordForm from '../ResetPassword/ResetPasswordForm';
import { useHistory } from 'react-router-dom';
import { resetpassword } from '../userSlice';
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
            const action = resetpassword(values);
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
            <ResetPasswordForm onSubmit={handleSubmit} />
        </div>
    );
}

export default ChangePassword;
