import React, { useState } from 'react'
import "./style.css"
import { Avatar } from '@material-ui/core';
import EditNoteOutlinedIcon from '@material-ui/icons/EditAttributesOutlined';
import Button from '@material-ui/core/Button';
import formatdate from 'constants/formatdate';
import UploadAnswer from '../UploadAnswer';
import Dialog from '@material-ui/core/Dialog';
import DialogContent from '@material-ui/core/DialogContent';
import { Close } from '@material-ui/icons';
import { IconButton } from '@material-ui/core';
const SubmitExercise = ({ exercise, classData, isUserHost, user,userHost, }) => {

  const [open, setOpen] = useState(false);
  const handleClickOpen = () => {
    setOpen(true);
  };
  const handleClose = () => {
    setOpen(false);
  };
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
        <Avatar style={{ backgroundColor: 'grey' }}>
          <EditNoteOutlinedIcon />
        </Avatar>
        <div className='upload_detail'>
          <h1 className='title_text1'>{exercise.name}</h1>
          <p>--- {userHost.nameMember} --- Thời gian giao {formatdate(exercise.createDate)}</p>
          <div className='content1'>
            <div className='content_text1'>
              <div className='deadline1'> Thời hạn {formatdate(exercise.deadline)} </div>
              <div>{getPointForIdMember(user.id) == null ? "null" : getPointForIdMember(user.id) > 0 ? getPointForIdMember(user.id) : "null"}/10 Điểm</div>
            </div>
            <div className='content_detail1'>
              <p>
                {exercise.description}
              </p>
            </div>
          </div>
        </div>
        <div>
          {getPointForIdMember(user.id) != null && <div>
            <h1>câu trả lời:</h1>
            <div>
              <p>{answer.content}</p>
              <a href={answer.linkFile} target='_banlk'>file</a>
            </div>
          </div>}
        </div>
      </div>
      <div className='upload_area'>
        <div className='upload_exercise'>
          <div className='your_exercise'>
            <p>Bài tập của bạn</p>
            <p>{getPointForIdMember(user.id) == null ? "chưa nộp" : getPointForIdMember(user.id) > 0 ? "đã chấm" : "đã nộp"}</p>
          </div>
          <div className='group_button'>
            <Button
              onClick={handleClickOpen}
              variant="contained"
              fullWidth
              disabled={getPointForIdMember(user.id) != null}
              style={{ mb: 2, borderRadius: 10 }}
            >
              Nộp bài tập
            </Button>
          </div>

        </div>
      </div>

      <Dialog
        disableBackdropClick
        disableEscapeKeyDown
        open={open}
        onClose={handleClose}
        aria-labelledby="form-dialog-title"
      >
        <IconButton onClick={handleClose}>
          <Close />
        </IconButton>

        <DialogContent>
          <UploadAnswer closeDialog={handleClose} classData={classData} exercise={exercise.idExercise} />
        </DialogContent>
      </Dialog>
    </div>

  )
}

export default SubmitExercise
