import { yupResolver } from '@hookform/resolvers/yup';
import { Avatar, Button, LinearProgress, makeStyles, Typography } from '@material-ui/core';
import VpnKeyOutlinedIcon from '@material-ui/icons/VpnKeyOutlined';
import InputField from 'components/form-controls/InputField';
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
        backgroundColor: 'rgb(227, 227, 0)',
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

RestorePasswordFrom.propTypes = {
    onSubmit: PropTypes.func,
};

function RestorePasswordFrom(props) {
    const classes = useStyles();

    const schema = yup.object().shape({
        Email: yup.string().required('Địa chỉ email không được bỏ trống.').email('Địa chỉ email không hợp lệ.'),
    });
    const form = useForm({
        defaultValues: {
            Email: '',
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
                <VpnKeyOutlinedIcon/>
            </Avatar>

            <Typography className={classes.title} component="h3" variant="h5">
                Khôi Phục Mật Khẩu
            </Typography>

            <form onSubmit={form.handleSubmit(handleSubmit)}>
                <InputField name="Email" label="Địa chỉ email" form={form} />
                <p>Chúng tôi sẽ gửi một mã OTP đến địa chỉ email bạn đã đăng ký</p>
                <Button
                    disabled={isSubmitting}
                    type="submit"
                    className={classes.submit}
                    variant="contained"
                    color="primary"
                    fullWidth
                    size="large"
                >
                    Khôi Phục
                </Button>
            </form>
        </div>
    );
}

export default RestorePasswordFrom;
