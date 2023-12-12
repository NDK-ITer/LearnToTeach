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

CreateClassForm.propTypes = {
    onSubmit: PropTypes.func,
};

function CreateClassForm(props) {
    const classes = useStyles();

    const schema = yup.object().shape({
        name: yup
            .string()
            .required('Tên lớp học không được bỏ trống.'),
        description: yup.string().required('Hãy nhập mô tả cho lớp học.'),
        isPrivate: yup.boolean(),
        key: yup.string().when('isPrivate', {
            is: true,
            then: yup.string().required('Hãy nhập mã lớp cho lớp học'),
            otherwise: yup.string()
        })
    });
    const form = useForm({
        defaultValues: {
            name: '',
            description: '',
            idUserHost: '',
            key: '',
            isPrivate: false
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
                Tạo lớp
            </Typography>

            <form onSubmit={form.handleSubmit(handleSubmit)}>
                <InputField name="name" label="Tên Lớp" form={form} />
                <InputField name="description" label="Mô tả" form={form} />
                <InputField name="key" label="Mã lớp (nếu là lớp 'Riêng tư')" form={form} />
                <CheckBoxField name='isPrivate' form={form} /><span>Riêng tư</span>
                <Button
                    disabled={isSubmitting}
                    type="submit"
                    className={classes.submit}
                    variant="contained"
                    color="primary"
                    fullWidth
                    size="large"
                >
                    Tạo ngay
                </Button>
            </form>
        </div>
    );
}

export default CreateClassForm;
