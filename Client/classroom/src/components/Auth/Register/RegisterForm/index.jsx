import { yupResolver } from '@hookform/resolvers/yup';
import { Avatar, Button, LinearProgress, makeStyles, Typography } from '@material-ui/core';
import { LockOutlined } from '@material-ui/icons';
import ImageUpload from 'components/form-controls/UploadField';
import InputField from 'components/form-controls/InputField';
import PasswordField from 'components/form-controls/PasswordField';
import PropTypes from 'prop-types';
import React from 'react';
import { useForm } from 'react-hook-form';
import Common from 'constants/common';
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

RegisterForm.propTypes = {
    onSubmit: PropTypes.func,
};

function RegisterForm(props) {
    const classes = useStyles();

    const schema = yup.object().shape({
        FirstName: yup
            .string()
            .required('Please enter your FirstName name.'),
        LastName: yup
            .string()
            .required('Please enter your LastName name.'),

        Email: yup.string().required('Please enter your email.').email('Please enter a valid email address.'),
        PhoneNumber: yup.string()
            .required('Please enter your phoneNumber.')
            .matches(Common.phoneRegExp, 'Phone number is not valid'),
        Password: yup.string().required('Please enter your password').min(6, 'Please enter at least 6 characters.'),
        PasswordIsConfirmed: yup
            .string()
            .required('Please retype your password.')
            .oneOf([yup.ref('Password')], 'Password does not match'),
    });
    const form = useForm({
        defaultValues: {
            FirstName: '',
            LastName: '',
            Email: '',
            PhoneNumber: '',
            Password: '',
            PasswordIsConfirmed: '',
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
                Đăng Ký
            </Typography>

            <form onSubmit={form.handleSubmit(handleSubmit)}>
                <InputField name="FirstName" label="First Name" form={form} />
                <InputField name="LastName" label="Last Name" form={form} />
                <InputField name="Email" label="Email" form={form} />
                <InputField name="PhoneNumber" label="PhoneNumber" form={form} />
                <PasswordField name="Password" label="Password" form={form} />
                <PasswordField name="PasswordIsConfirmed" label="Retype Password" form={form} />

                <Button
                    disabled={isSubmitting}
                    type="submit"
                    className={classes.submit}
                    variant="contained"
                    color="primary"
                    fullWidth
                    size="large"
                >
                    Đăng Ký
                </Button>
            </form>
        </div>
    );
}

export default RegisterForm;
