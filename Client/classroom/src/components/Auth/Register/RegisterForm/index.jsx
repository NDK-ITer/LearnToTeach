import { yupResolver } from '@hookform/resolvers/yup';
import { Avatar, Button, LinearProgress, makeStyles, Typography } from '@material-ui/core';
import LockOpenOutlinedIcon from '@material-ui/icons/LockOpenOutlined';
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
        backgroundColor: 'rgb(4, 214, 46)',
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
            .required('Họ không được bỏ trống.'),
        LastName: yup
            .string()
            .required('Tên không được bỏ trống.'),

        Email: yup.string().required('Địa chỉ email không được bỏ trống.').email('Địa chỉ email không hợp lệ.'),
        PhoneNumber: yup.string()
            .required('Số điện thoại không được bỏ trống.')
            .matches(Common.phoneRegExp, 'Số điện thoại không hợp lệ'),
        Password: yup.string().required('Mật khẩu không được bỏ trống').min(6, 'Mật khẩu phải có ít nhất 6 ký tự.'),
        PasswordIsConfirmed: yup
            .string()
            .required('Nhập lại mất khẩu không được bỏ trống.')
            .oneOf([yup.ref('Password')], 'Mật khẩu không trùng khớp'),
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
                <LockOpenOutlinedIcon/>
            </Avatar>

            <Typography className={classes.title} component="h3" variant="h5">
                Đăng Ký
            </Typography>

            <form onSubmit={form.handleSubmit(handleSubmit)}>
                <InputField name="FirstName" label="Họ" form={form} />
                <InputField name="LastName" label="Tên" form={form} />
                <InputField name="Email" label="Địa chỉ email" form={form} />
                <InputField name="PhoneNumber" label="Số điện thoại" form={form} />
                <PasswordField name="Password" label="Mật khẩu" form={form} />
                <PasswordField name="PasswordIsConfirmed" label="Nhập lại mật khẩu" form={form} />

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
