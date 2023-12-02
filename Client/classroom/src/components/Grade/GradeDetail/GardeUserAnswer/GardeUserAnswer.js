import React, { useState } from 'react'
import "./style.css"
import { Avatar } from '@material-ui/core';
import EditNoteOutlinedIcon from '@material-ui/icons/EditAttributesOutlined';
import Button from '@material-ui/core/Button';
import formatdate from 'constants/formatdate';
import Dialog from '@material-ui/core/Dialog';
import DialogContent from '@material-ui/core/DialogContent';
import { Close } from '@material-ui/icons';
import { IconButton } from '@material-ui/core';
import SetPointUser from '../SetPointUser';
const GardeUserAnswer = ({ exercise, classData, isUserHost, userAnswer, userHost, }) => {
    const [open, setOpen] = useState(false);
    const handleClickOpen = () => {
        setOpen(true);
    };
    const handleClose = () => {
        setOpen(false);
    };
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
                            <div>/10 Điểm</div>
                        </div>
                        <div className='content_detail1'>
                            <p>
                                {exercise.description}
                            </p>
                        </div>
                    </div>
                </div>
                <div>
                    <h1>Bài tập đã nộp:</h1>
                    <p>Ngày nộp:{formatdate(userAnswer.dateAnswer)}</p>
                    <div>
                        <p>{userAnswer.content}</p>
                        <a href={userAnswer.linkFile} target='_banlk'>Đính kèm</a>
                    </div>
                </div>
                <Button
                    onClick={handleClickOpen}
                    variant="contained"
                    fullWidth

                    style={{ mb: 2, borderRadius: 10 }}
                >
                    Nộp bài tập
                </Button>
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
                    <SetPointUser closeDialog={handleClose} classData={classData} exercise={exercise.idExercise} />
                </DialogContent>
            </Dialog>
        </div>

    )
}

export default GardeUserAnswer
