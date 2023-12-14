import React, { useState } from 'react'
import "./style.css"
import { Avatar } from '@material-ui/core';
import DescriptionOutlinedIcon from '@material-ui/icons/DescriptionOutlined';
import Button from '@material-ui/core/Button';
import formatdate from 'constants/formatdate';
import UploadAnswer from '../UploadAnswer';
import Dialog from '@material-ui/core/Dialog';
import DialogContent from '@material-ui/core/DialogContent';
import { Close } from '@material-ui/icons';
import { IconButton } from '@material-ui/core';
import classApi from 'api/classApi';
import { useSnackbar } from 'notistack';
import EditAnswer from '../EditAnswer';
import { Link } from 'react-router-dom';
import linkFile from 'constants/LinkFile';
const SubmitExercise = ({ exercise, classData, isUserHost, user, userHost, }) => {
  const { enqueueSnackbar } = useSnackbar();
  const [openUpload, setopenUpload] = useState(false);
  const [openEdit, setopenEdit] = useState(false);
  const currentDate = new Date();
  const handleClickopenUpload = () => {
    setopenUpload(true);
  };
  const handleCloseUpload = () => {
    setopenUpload(false);
  };
  const handleClickopenEdit = () => {
    setopenEdit(true);
  };
  const handleCloseEdit = () => {
    setopenEdit(false);
  };
  const handledeleExercise = async () => {
    try {
      const params = new URLSearchParams([['idExercise', exercise.idExercise], ['idMember', user.id]]);
      const result = await classApi.deleteanswer(params);
      if (result.status == 1) {
        enqueueSnackbar(result.message, { variant: 'success' });
        window.location.reload();
      } else {
        enqueueSnackbar(result.message, { variant: 'error' });
      }

    } catch (error) {
      console.log('Failed to login:', error);
      enqueueSnackbar(error.message, { variant: 'error' });
    }
  }
  const getPointForIdMember = (idMember) => {
    const answer = exercise.listAnswer.find(answer => answer.idMember === idMember);
    if (answer) {
      return answer.point != null ? answer.point : -1;
    }
    return null;
  };
  const answer = exercise.listAnswer.find(answer => answer.idMember === user.id);
  return (
    <div className='submit_exercise'>
      <div className='main_area'>
        <div className='exercise_title'>
          <Avatar style={{ backgroundColor: 'grey', marginTop: '10px' }}>
            <DescriptionOutlinedIcon />
          </Avatar>
          <div className='upload_detail'>
            <h1 className='title_text'>{exercise.name}</h1>
            <p style={{ fontSize: '14px' }}>--- {userHost.nameMember} --- Thời gian giao {formatdate(exercise.createDate)} --- </p>
          </div>
        </div>
        <div className='upload_detail'>
          <div className='content1'>
            <div className='content_text1'>
              <div className='deadline1'> Thời hạn {formatdate(exercise.deadline)} </div>
              <div> {getPointForIdMember(user.id) == null ? "0" : getPointForIdMember(user.id) > 0 ? getPointForIdMember(user.id) : "0"}/10 Điểm</div>
            </div>
            <div className='content_detail1'>
              <p>
                {exercise.description}
              </p>
              {exercise.file != linkFile &&
                <p><a href={exercise.file} target='_blank'> Đính kèm tệp</a></p>}

            </div>
          </div>
        </div>
      </div>
      <div className='upload_area'>
        <div className='upload_exercise'>
          <div className='your_exercise'>
            <p>Bài tập của bạn</p>
            <p className='upload_status'>{getPointForIdMember(user.id) == null ? "Chưa nộp" : getPointForIdMember(user.id) > 0 ? answer.dateUpdatePoint != null ? "Đã chấm lại" : "Đã chấm" : "Đã nộp"}</p>
          </div>
          <div className='group_button'>
            {getPointForIdMember(user.id) == null &&
              <Button
                onClick={handleClickopenUpload}
                variant="contained"
                fullWidth
                disabled={getPointForIdMember(user.id) != null}
                style={{ mb: 2, borderRadius: 10 }}
              >
                Nộp bài tập
              </Button>
            }
            {getPointForIdMember(user.id) != null &&
              <div>
                <Button
                  onClick={handledeleExercise}
                  variant="contained"
                  fullWidth
                  disabled={getPointForIdMember(user.id) > 0 || new Date(exercise.deadline) < currentDate}
                  style={{ mb: 2, borderRadius: 10, marginTop: '12px' }}
                >
                  Hủy nộp
                </Button>
                <Button
                  onClick={handleClickopenEdit}
                  variant="contained"
                  fullWidth
                  disabled={getPointForIdMember(user.id) > 0 || new Date(exercise.deadline) < currentDate}
                  style={{ marginTop: '12px', mb: 2, borderRadius: 10 }}
                >
                  Nộp lại
                </Button>
              </div>
            }
          </div>
          <div className='your_exercise'>
            {getPointForIdMember(user.id) != null && <div>
              <div>
                <p style={{ fontSize: '22px' }}>Câu trả lời:</p>
                <p style={{ fontSize: '13px' }}>Thời gian nộp: {formatdate(answer.dateAnswer)} </p>
                {formatdate(answer.dateUpdateAnswer) > formatdate(answer.dateAnswer) &&
                  <p style={{ fontSize: '13px' }}>Thời gian chỉnh sửa: {formatdate(answer.dateUpdateAnswer)} </p>
                }
              </div>
              <div style={{ fontSize: '16px' }}>
                <p>{answer.content}</p>
                {answer.linkFile != linkFile &&
                  <a to={answer.linkFile} target='_banlk'>Đính kèm tệp</a>
                }

              </div>
            </div>}
          </div>
        </div>
      </div>

      <Dialog
        disableBackdropClick
        disableEscapeKeyDown
        open={openUpload}
        onClose={handleCloseUpload}
        aria-labelledby="form-dialog-title"
      >
        <IconButton onClick={handleCloseUpload}>
          <Close />
        </IconButton>

        <DialogContent>
          <UploadAnswer closeDialog={handleCloseUpload} classData={classData} exercise={exercise.idExercise} />
        </DialogContent>
      </Dialog>


      <Dialog
        disableBackdropClick
        disableEscapeKeyDown
        open={openEdit}
        onClose={handleCloseEdit}
        aria-labelledby="form-dialog-title"
      >
        <IconButton onClick={handleCloseEdit}>
          <Close />
        </IconButton>

        <DialogContent>
          <EditAnswer closeDialog={handleCloseEdit} classData={classData} answer={answer} exercise={exercise.idExercise} />
        </DialogContent>
      </Dialog>
    </div>

  )
}

export default SubmitExercise
