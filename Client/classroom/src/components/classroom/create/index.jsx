import { unwrapResult } from '@reduxjs/toolkit';
import { createClassroom } from '../classSilce';
import { useSnackbar } from 'notistack';
import PropTypes from 'prop-types';
import React from 'react';
import { useDispatch } from 'react-redux';
import CreateClassForm from './createform'
import StorageKeys from 'constants/storage-keys';
CreateClass.propTypes = {
    closeDialog: PropTypes.func,
};

function CreateClass(props) {
    const dispatch = useDispatch();
    const { enqueueSnackbar } = useSnackbar();
    const user = JSON.parse(localStorage.getItem(StorageKeys.USER));

    const handleSubmit = async (values) => {
        try {
            // auto set username = email
            values.idUserHost = user.id;

            const action = createClassroom(values);
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
            <CreateClassForm onSubmit={handleSubmit} />
        </div>
    );
}

export default CreateClass;
