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

ChangePasswordForm.propTypes = {
    onSubmit: PropTypes.func,
};

function ChangePasswordForm(props) {
    const classes = useStyles();

    const schema = yup.object().shape({
        Password: yup.string().required('Mật khẩu không được bỏ trống').min(6, 'Mật khẩu phải có ít nhất 6 ký tự.'),
        NewPassword: yup.string().required('Mật khẩu không được bỏ trống').min(6, 'Mật khẩu phải có ít nhất 6 ký tự.'),
        ConfirmPassword: yup
            .string()
            .required('Nhập lại mật khẩu không được bỏ trống.')
            .oneOf([yup.ref('NewPassword')], 'Mật khẩu không trùng khớp'),
    });
    const form = useForm({
        defaultValues: {
            Email: '',
            NewPassword: '',
            ConfirmPassword: '',
            Password: ''
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
                <PasswordField name="Password" label="Mật khẩu cũ" form={form} />
                <PasswordField name="NewPassword" label="Mật khẩu mới" form={form} />
                <PasswordField name="ConfirmPassword" label="Nhập lại mật khẩu mới" form={form} />
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

export default ChangePasswordForm;
