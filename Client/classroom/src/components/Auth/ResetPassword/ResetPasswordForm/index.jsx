import { yupResolver } from '@hookform/resolvers/yup';
import { Avatar, Button, LinearProgress, makeStyles, Typography } from '@material-ui/core';
import { LockOutlined } from '@material-ui/icons';
import PasswordField from 'components/form-controls/PasswordField';
import PropTypes from 'prop-types';
import React from 'react';
import { useForm } from 'react-hook-form';
import * as yup from 'yup';


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

ResetPasswordForm.propTypes = {
    onSubmit: PropTypes.func,
};

function ResetPasswordForm(props) {
    const classes = useStyles();

    const schema = yup.object().shape({
        NewPassword: yup.string().required('Please enter your password').min(6, 'Please enter at least 6 characters.'),
        ConfirmPassword: yup
            .string()
            .required('Please retype your password.')
            .oneOf([yup.ref('ConfirmPassword')], 'Password does not match'),
    });
    const form = useForm({
        defaultValues: {
            Email: '',
            NewPassword: '',
            ConfirmPassword: ''
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

            <Avatar className={classes.avatar}>
                <LockOutlined></LockOutlined>
            </Avatar>

            <Typography className={classes.title} component="h3" variant="h5">
                Cập Nhật Mật Khẩu
            </Typography>

            <form onSubmit={form.handleSubmit(handleSubmit)}>
                <PasswordField name="NewPassword" label="Password" form={form} />
                <PasswordField name="ConfirmPassword" label="Retype Password" form={form} />
                <Button
                    disabled={isSubmitting}
                    type="submit"
                    className={classes.submit}
                    variant="contained"
                    color="primary"
                    fullWidth
                    size="large"
                >
                    Cập Nhật
                </Button>
            </form>
        </div>
    );
}

export default ResetPasswordForm;
