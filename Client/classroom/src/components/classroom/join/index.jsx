import { unwrapResult } from '@reduxjs/toolkit';
import { joinClassroom } from '../classSilce';
import { useSnackbar } from 'notistack';
import PropTypes from 'prop-types';
import React from 'react';
import { useDispatch } from 'react-redux';
import JoinClassForm from './joinform'
import StorageKeys from 'constants/storage-keys';
JoinClass.propTypes = {
    closeDialog: PropTypes.func,
};

function JoinClass(props) {
    const dispatch = useDispatch();
    const { enqueueSnackbar } = useSnackbar();
    const user = JSON.parse(localStorage.getItem(StorageKeys.USER));

    const handleSubmit = async (values) => {
        try {
            // auto set username = email
            values.idMember = user.id;

            const action = joinClassroom(values);
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

            }
            // close dialog
            const { closeDialog } = props;
            if (closeDialog) {
                closeDialog();
            }
        } catch (error) {
            console.log('Failed to register:', error);
            enqueueSnackbar(error.message, { variant: 'error' });
        }
    };

    return (
        <div>
            <JoinClassForm onSubmit={handleSubmit} />
        </div>
    );
}
export default JoinClass;
