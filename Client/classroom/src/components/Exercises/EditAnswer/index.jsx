import { unwrapResult } from '@reduxjs/toolkit';
import { useSnackbar } from 'notistack';
import PropTypes from 'prop-types';
import React from 'react';
import { useDispatch } from 'react-redux';
import { useLocalContext } from 'context';
import { editAnswer } from 'components/classroom/classSilce';
import EditAnswerForm from './EditAnswerForm';
EditAnswer.propTypes = {
    closeDialog: PropTypes.func,
    classData: PropTypes.object,
    exercise: PropTypes.string,
    answer: PropTypes.object
};

function EditAnswer(props) {
    const dispatch = useDispatch();
    const { enqueueSnackbar } = useSnackbar();
    const { user } = useLocalContext();
    const { classData, exercise,answer } = props;
    const handleSubmit = async (values) => {
        try {
            // auto set username = email
            values.IdMember = user.id;
            values.IdClassroom = classData.idClassroom;
            values.IdExercise = exercise;
            const action = editAnswer(values);
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
            <EditAnswerForm onSubmit={handleSubmit} answer={answer} />
        </div>
    );
}

export default EditAnswer;
