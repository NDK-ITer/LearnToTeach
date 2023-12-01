import { yupResolver } from '@hookform/resolvers/yup';
import { Avatar, Button, LinearProgress, makeStyles, Typography } from '@material-ui/core';
import InputField from 'components/form-controls/InputField';
import PropTypes from 'prop-types';
import React, { useState } from 'react';
import { useForm } from 'react-hook-form';
import * as yup from 'yup';
import "./style.css";
import TextAreaField from 'components/form-controls/TextAreaField';

FormNotify.propTypes = {
    onSubmit: PropTypes.func,
    classData: PropTypes.string,
};
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

function FormNotify(props) {
    const [showInput, setShowInput] = useState(false);
    const classes = useStyles()
    const schema = yup.object().shape({
        NameNotify: yup
            .string()
            .required('Please enter your Name Notify.'),
        Description: yup.string()
            .required('Please enter your Description.'),
    });
    const form = useForm({
        defaultValues: {
            IdClassroom: '',
            IdMember: '',
            NameNotify: '',
            Description: '',
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
        <div className="main__announcements">
            <div className="main__announcementsWrapper">
                <div className="main__ancContent">
                    {showInput ? (
                        <div className="main__form">
                            {isSubmitting && <LinearProgress className={classes.progress} />}
                            <form onSubmit={form.handleSubmit(handleSubmit)}>
                                <InputField name='NameNotify' label='Tiêu đề' form={form} />
                                <TextAreaField name='Description' label='Nội dung' form={form} />
                                <div className="main__buttons">
                                    <div>
                                        <Button onClick={() => setShowInput(false)}>
                                            Hủy
                                        </Button>
                                        <Button
                                            disabled={isSubmitting}
                                            type="submit"
                                            color="primary"
                                            variant="contained"
                                        >
                                            Đăng
                                        </Button>
                                    </div>
                                </div>
                            </form>
                        </div>
                    ) : (
                        <div
                            className="main__wrapper100"
                            onClick={() => setShowInput(true)}
                        >
                            <Avatar />
                            <div>Thông báo với lớp học</div>
                        </div>
                    )}
                </div>
            </div>
        </div>
    );
}

export default FormNotify;
