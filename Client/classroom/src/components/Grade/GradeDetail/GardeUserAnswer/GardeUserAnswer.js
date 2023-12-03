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
import GoBackButton from 'components/GoBackButton';
const GardeUserAnswer = ({ classData, userHost, answerItem, exercise }) => {
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
                    <p>--- {userHost.nameMember} --- Thời gian giao {formatdate(exercise.createDate)} <span style={{ marginLeft: "10px" }}>{answerItem.point > 0 ? "đã chấm" : "chưa chấm"}</span> </p>
                    <div className='content1'>
                        <div className='content_text1'>
                            <div className='deadline1'> Thời hạn {formatdate(exercise.deadline)} </div>
                            <div>{answerItem.point}/10 Điểm</div>
                        </div>
                        <div className='content_detail1'>
                            <p>
                                {exercise.description}
                            </p>
                        </div>
                    </div>
                </div>
                <div>
                    <h1>câu trả lời:</h1>
                    <p>ngày trả lời:{formatdate(answerItem.dateAnswer)}</p>
                    <div>
                        <p>{answerItem.content}</p>
                        <a href={answerItem.linkFile} target='_banlk'>file</a>
                    </div>
                </div>
                <Button
                    onClick={handleClickOpen}
                    variant="contained"
                    disabled={answerItem.point > 0}
                    style={{ mb: 2, borderRadius: 10, mt: 5 }}
                >
                    chấm điểm
                </Button>
                <div>
                    <GoBackButton />
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
                    <SetPointUser closeDialog={handleClose} classData={classData} exercise={exercise.idExercise} answerItem={answerItem.idMember} userHost={userHost} />
                </DialogContent>
            </Dialog>
        </div>

    )
}

export default GardeUserAnswer
