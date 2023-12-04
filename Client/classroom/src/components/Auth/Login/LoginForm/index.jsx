import { yupResolver } from '@hookform/resolvers/yup';
import { Avatar, Button, LinearProgress, makeStyles, Typography } from '@material-ui/core';
import MenuBookOutlinedIcon from '@material-ui/icons/MenuBookOutlined';
import InputField from 'components/form-controls/InputField';
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
        backgroundColor: 'rgb(0, 159, 212)',
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

LoginForm.propTypes = {
    onSubmit: PropTypes.func,
};

function LoginForm(props) {
    const classes = useStyles();

    const schema = yup.object().shape({
        Email: yup.string().required('Please enter your email.').email('Please enter a valid email address.'),
        Password: yup.string().required('Please enter your password'),
    });
    const form = useForm({
        defaultValues: {
            Email: '',
            Password: '',
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
                <MenuBookOutlinedIcon/>
            </Avatar>

            <Typography className={classes.title} component="h3" variant="h5">
                Đăng nhập
            </Typography>

            <form onSubmit={form.handleSubmit(handleSubmit)}>
                <InputField name="Email" label="Địa chỉ email" form={form} />
                <PasswordField name="Password" label="Mật khẩu" form={form} />
                <Button
                    disabled={isSubmitting}
                    type="submit"
                    className={classes.submit}
                    variant="contained"
                    color="primary"
                    fullWidth
                    size="large"
                >
                    Đăng nhập
                </Button>
            </form>
        </div>
    );
}

export default LoginForm;
