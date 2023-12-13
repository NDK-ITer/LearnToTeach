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

UploadDocumentForm.propTypes = {
    onSubmit: PropTypes.func,
};

function UploadDocumentForm(props) {
    const classes = useStyles();
    const schema = yup.object().shape({
        Decription: yup.string().required('Vui lòng nhập tiêu đề tài liệu.'),
        // FileUploadDocument: yup.string().required('Please choose file.')
    });

    const form = useForm({
        defaultValues: {
            IdClassroom: '',
            IdMember: '',
            Decription: '',
            FileUploadDocument: '',
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
                Tải tài liệu
            </Typography>

            <form onSubmit={form.handleSubmit(handleSubmit)}>
                <InputField name="Decription" label="Tiêu đề tài liệu" form={form} />
                <UploadField name='FileUploadDocument' form={form} accept='*' />
                <Button
                    disabled={isSubmitting}
                    type="submit"
                    className={classes.submit}
                    variant="contained"
                    color="primary"
                    fullWidth
                    size="large"
                >
                    tải lên
                </Button>
            </form>
        </div>
    );
}

export default UploadDocumentForm;
