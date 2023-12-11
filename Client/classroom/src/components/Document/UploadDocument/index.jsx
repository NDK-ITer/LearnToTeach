import { unwrapResult } from '@reduxjs/toolkit';
import { useSnackbar } from 'notistack';
import PropTypes from 'prop-types';
import React from 'react';
import { useDispatch } from 'react-redux';
import { useLocalContext } from 'context';
import { uploaddoc } from 'components/classroom/classSilce';
import UploadDocumentForm from './UploadDocumentForm';
UploadDocument.propTypes = {
    closeDialog: PropTypes.func,
    classData: PropTypes.object
};

function UploadDocument(props) {
    const dispatch = useDispatch();
    const { enqueueSnackbar } = useSnackbar();
    const { user } = useLocalContext();
    const { classData } = props;
    const handleSubmit = async (values) => {
        try {
            // auto set username = email
            console.log(values)
            values.IdMember = user.id;
            values.IdClassroom = classData.idClassroom;
            const action = uploaddoc(values);
            const resultAction = await dispatch(action);
            unwrapResult(resultAction);

            const check = resultAction.payload
            console.log(resultAction.payload)
            if (typeof check.status != 'undefined') {
                if (check.status === 1) {
                    enqueueSnackbar(check.message, { variant: 'success' });
                    window.location.reload(true);
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
            <UploadDocumentForm onSubmit={handleSubmit} />
        </div>
    );
}

export default UploadDocument;
