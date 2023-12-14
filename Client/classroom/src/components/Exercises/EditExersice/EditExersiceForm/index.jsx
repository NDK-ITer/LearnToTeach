import { yupResolver } from '@hookform/resolvers/yup';
import { Avatar, Button, LinearProgress, makeStyles, Typography } from '@material-ui/core';
import InputField from 'components/form-controls/InputField';
import PropTypes from 'prop-types';
import React from 'react';
import { useForm } from 'react-hook-form';
import * as yup from 'yup';
import "./style.css";
import UploadField from 'components/form-controls/UploadField';
import TextAreaField from 'components/form-controls/TextAreaField';
import DateField from 'components/form-controls/DateField';
import BorderColorOutlinedIcon from '@material-ui/icons/BorderColorOutlined';
import formatDate from 'constants/formatdate';
import { Link } from 'react-router-dom';
import linkFile from 'constants/LinkFile';
EditExerciseForm.propTypes = {
    onSubmit: PropTypes.func,
    classData: PropTypes.string,
    exercise: PropTypes.object

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

function EditExerciseForm(props) {
    const { exercise } = props;
    console.log(exercise)
    const classes = useStyles()
    const schema = yup.object().shape({
        Name: yup
            .string()
            .required('Vui lòng nhập tiêu đề bài tập.'),
        Deadline: yup.date().min(new Date(), 'Ngày phải là hôm nay hoặc muộn hơn.').required('Vui lòng nhập thời hạn nộp.'),
    });
    const form = useForm({
        defaultValues: {
            IdClassroom: '',
            IdMember: '',
            IdExercise: '',
            Name: exercise.name != null ? exercise.name : '',
            Description: exercise.description != null ? exercise.description : '',
            Deadline: formatDate(exercise.deadline) != null ? formatDate(exercise.deadline) : '',
            FileUpload: '',
        },
        resolver: yupResolver(schema),
    });
    console.log(form)
    const handleSubmit = async (values) => {
        const { onSubmit } = props;
        if (onSubmit) {
            await onSubmit(values);
        }
    };

    const { isSubmitting } = form.formState;

    return (
        <div >
            {isSubmitting && <LinearProgress className={classes.progress} />}
            <form onSubmit={form.handleSubmit(handleSubmit)}>
                <div>
                    <div className='header'>
                        <Avatar style={{ m: 1, backgroundColor: 'grey' }}>
                            <BorderColorOutlinedIcon />
                        </Avatar>
                        <h1 className='header_text'> Tạo bài tập </h1>

                        <div className='group_btn'>
                            <Button
                                variant="outlined"
                                style={{ margin: 1 }}
                            >
                                <Link to={`/${props.classData}/exercises`}>Hủy</Link>
                            </Button>

                            <Button
                                disabled={isSubmitting}
                                type="submit"
                                variant="contained"
                                color="primary"
                                fullWidth
                                size="medium"
                            >
                                sửa bài
                            </Button>
                        </div>

                    </div>
                    <div className='main_content'>
                        <div className='title'>
                            <InputField name="Name" label="Tiêu đề" form={form} defaultValue={exercise.name} />
                        </div>
                        <div className='content'>
                            <TextAreaField name="Description" label="Nội dung" form={form} defaultValue={exercise.description} />
                        </div>
                        <div className='attachment'>
                            <p className='text'>Đính kèm tệp: </p>
                            <div>
                                <UploadField name='FileUpload' form={form} accept='*' /> {exercise.file != linkFile && <span>tệp đã đăng: <a href={exercise.file} target="_blank" rel="noopener noreferrer">tệp</a></span>}
                            </div>
                        </div>
                        <div className='time'>
                            <p className='text'>Hạn nộp:</p>
                            <div className='picktime'>
                                <DateField name="Deadline" label="Exercise Content" form={form} defaultValue={formatDate(exercise.deadline)} />
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        </div>
    );
}

export default EditExerciseForm;
