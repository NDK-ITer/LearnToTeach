import { unwrapResult } from '@reduxjs/toolkit';
import { useSnackbar } from 'notistack';
import PropTypes from 'prop-types';
import React from 'react';
import { useDispatch } from 'react-redux';
import { useLocalContext } from 'context';
import { setpointanswer, uploadAnswer } from 'components/classroom/classSilce';
import SetPointUserForm from './SetPointUserForm';
SetPointUser.propTypes = {
    closeDialog: PropTypes.func,
    classData: PropTypes.object,
    exercise: PropTypes.string,
    answerItem: PropTypes.string,
    userHost: PropTypes.object,
    
};

function SetPointUser(props) {
    const dispatch = useDispatch();
    const { enqueueSnackbar } = useSnackbar();
    const { user } = useLocalContext();
    const { classData, exercise, answerItem, userHost } = props;
    console.log(userHost)
    const handleSubmit = async (values) => {
        try {
            // auto set username = email
            values.IdMember = answerItem;
            values.IdClassroom = classData.idClassroom;
            values.IdExercise = exercise;
            values.IdUserHost = userHost.idMember;
            const action = setpointanswer(values);
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
            <SetPointUserForm onSubmit={handleSubmit} />
        </div>
    );
}

export default SetPointUser;
