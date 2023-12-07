import { unwrapResult } from '@reduxjs/toolkit';
import { useSnackbar } from 'notistack';
import React, { useEffect, useState } from 'react';
import { useDispatch } from 'react-redux';
import { useHistory } from 'react-router-dom';
import { editexercise } from 'components/classroom/classSilce';
import { useLocalContext } from 'context';
import EditExerciseForm from './EditExersiceForm';
function EditExercise({ classData, exercise }) {
    const { user } = useLocalContext();
    const dispatch = useDispatch();
    const { enqueueSnackbar } = useSnackbar();
    const history = useHistory();
    const handleSubmit = async (values) => {
        try {
            values.IdClassroom = classData.idClassroom;
            values.IdMember = user.id;
            values.IdExercise = exercise.idExercise;
            const action = editexercise(values);
            const resultAction = await dispatch(action);
            unwrapResult(resultAction);
            const check = resultAction.payload
            console.log(resultAction.payload)
            if (check.status == 1) {
                enqueueSnackbar(check.message, { variant: 'success' });
                history.push(`/${classData.idClassroom}/exercises`)
                window.location.reload()
            } else {
                enqueueSnackbar(check.message, { variant: 'error' });
            }

        } catch (error) {
            console.log('Failed to login:', error);
            enqueueSnackbar(error.message, { variant: 'error' });
        }
    };

    return (
        <div>
            <EditExerciseForm onSubmit={handleSubmit} classData={classData.idClassroom} exercise={exercise} />
        </div>
    )
}

export default EditExercise;
