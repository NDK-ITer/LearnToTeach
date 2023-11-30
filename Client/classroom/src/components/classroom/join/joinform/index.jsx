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

JoinClassForm.propTypes = {
    onSubmit: PropTypes.func,
};

function JoinClassForm(props) {
    const classes = useStyles();

    const schema = yup.object().shape({
        idClassroom: yup
            .string()
            .required('Please enter your class room.'),
    });
    const form = useForm({
        defaultValues: {
            idClassroom: '',
            idMember: '',
            key: '',
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
                Tham gia lớp học
            </Typography>

            <form onSubmit={form.handleSubmit(handleSubmit)}>
                <InputField name="idClassroom" label="Lớp" form={form} />
                <InputField name="key" label="Mã lớp" form={form} />
                <span>Hãy nhập mã lớp nếu đó là lớp 'Riêng tư'</span>
                <Button
                    disabled={isSubmitting}
                    type="submit"
                    className={classes.submit}
                    variant="contained"
                    color="primary"
                    fullWidth
                    size="large"
                >
                    Tham gia gia
                </Button>
            </form>
        </div>
    );
}

export default JoinClassForm;
