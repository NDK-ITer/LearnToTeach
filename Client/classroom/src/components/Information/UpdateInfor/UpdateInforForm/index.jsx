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
import UploadField from 'components/form-controls/UploadField';


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

UpdateInforForm.propTypes = {
    onSubmit: PropTypes.func,
    userInfor:PropTypes.object
};

function UpdateInforForm(props) {
    const classes = useStyles();
    const {userInfor}=props;
    const schema = yup.object().shape({
        FirstName: yup
            .string()
            .required('Họ không được bỏ trống.'),
        LastName: yup
            .string()
            .required('Tên không được bỏ trống.'),
    });
    const form = useForm({
        defaultValues: {
            FirstName: '',
            LastName: '',
            Avatar: '',
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
                <LockOpenOutlinedIcon />
            </Avatar>

            <Typography className={classes.title} component="h3" variant="h5">
                thông tin
            </Typography>

            <form onSubmit={form.handleSubmit(handleSubmit)}>
                <Button>Avatar<UploadField name='Avatar' form={form} /></Button>
                <InputField name="FirstName" label="Họ" form={form} defaultValue={userInfor.firstName} />
                <InputField name="LastName" label="Tên" form={form} defaultValue={userInfor.lastName}  />
                <Button
                    disabled={isSubmitting}
                    type="submit"
                    className={classes.submit}
                    variant="contained"
                    color="primary"
                    fullWidth
                    size="large"
                >
                    cập nhật
                </Button>
            </form>
        </div>
    );
}

export default UpdateInforForm;
