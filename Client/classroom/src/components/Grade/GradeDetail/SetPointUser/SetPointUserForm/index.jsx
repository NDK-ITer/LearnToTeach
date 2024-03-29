import { yupResolver } from '@hookform/resolvers/yup';
import { Avatar, Button, LinearProgress, makeStyles, Typography } from '@material-ui/core';
import InputField from 'components/form-controls/InputField';
import { Checkbox } from '@material-ui/core';
import PropTypes from 'prop-types';
import React from 'react';
import { useForm } from 'react-hook-form';
import Common from 'constants/common';
import * as yup from 'yup';
import CheckBoxField from 'components/form-controls/CheckBoxField';
import UploadField from 'components/form-controls/UploadField';
import TextAreaField from 'components/form-controls/TextAreaField';


const useStyles = makeStyles((theme) => ({
    root: {
        position: 'relative',
        paddingTop: theme.spacing(4),
    },

    avatar: {
        margin: '0 auto',
        backgroundColor: theme.palette.secondary.main,
    },

    title: {
        margin: theme.spacing(2, 0, 3, 0),
        textAlign: 'center',
    },

    submit: {
        margin: theme.spacing(3, 0, 2, 0),
    },

    progress: {
        position: 'absolute',
        top: theme.spacing(1),
        left: 0,
        right: 0,
    },
}));

SetPointUserForm.propTypes = {
    onSubmit: PropTypes.func,
    point: PropTypes.number
};

function SetPointUserForm(props) {
    const classes = useStyles();
    const { point } = props
    const schema = yup.object().shape({
        point: yup.number()
            .min(0, 'điểm nhập phải lớn hơn hoặc bằng 0')
            .max(10, 'điểm nhập phải bé hơn hoặc bằng 10')
            .required('vui long nhập điểm'),
    });

    const form = useForm({
        defaultValues: {
            IdClassroom: '',
            IdMember: '',
            IdUserHost: '',
            IdExercise: '',
            point: point != null ? point : ''
        },
        resolver: yupResolver(schema),
    });
    const handleSubmit = async (values) => {
        const { onSubmit } = props;
        if (onSubmit) {
            await onSubmit(values);
        }
    };

    const { isSubmitting } = form.formState;

    return (
        <div className={classes.root}>
            {isSubmitting && <LinearProgress className={classes.progress} />}
            <Typography className={classes.title} component="h3" variant="h5">
                Điểm
            </Typography>

            <form onSubmit={form.handleSubmit(handleSubmit)}>
                <InputField name='point' label='Nhập điểm số' form={form} defaultValue={point != null ? point : ''} />
                <Button
                    disabled={isSubmitting}
                    type="submit"
                    className={classes.submit}
                    variant="contained"
                    color="primary"
                    fullWidth
                    size="large"
                >
                    xác nhận
                </Button>
            </form>
        </div>
    );
}

export default SetPointUserForm;
