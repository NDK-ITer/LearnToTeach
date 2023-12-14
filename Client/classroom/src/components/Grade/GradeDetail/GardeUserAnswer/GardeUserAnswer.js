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
import getFileExtension from 'constants/extentionfile';
import linkFile from 'constants/LinkFile';
const GardeUserAnswer = ({ classData, userHost, answerItem, exercise }) => {
    const [open, setOpen] = useState(false);
    const handleClickOpen = () => {
        setOpen(true);
    };
    const handleClose = () => {
        setOpen(false);
    };
    const curendate = new Date()
    console.log(answerItem.dateUpdatePoint)
    return (
        <div className='submit_exercise1'>
            <div className='main_area1'>
                <div className='exercise_title1'>
                    <Avatar style={{ backgroundColor: 'grey', marginTop: '10px' }}>
                        <EditNoteOutlinedIcon />
                    </Avatar>
                    <div className='upload_detail1'>
                        <h1 className='title_text2'>{exercise.name}</h1>
                        <p style={{ fontSize: '14px' }}>--- {userHost.nameMember} --- Thời gian giao {formatdate(exercise.createDate)} <span style={{ marginLeft: "15px" }}>{answerItem.point > 0 ? answerItem.dateUpdatePoint !== null ? "đã sửa điểm (" + formatdate(answerItem.dateUpdatePoint) + ")" : "đã chấm (" + formatdate(answerItem.dateSetPoint) + ")" : "Chưa chấm"} </span> </p>
                    </div>
                </div>
                <div className='upload_detail1'>
                    <div className='content2'>
                        <div className='content_text2'>
                            <div className='deadline2'> Thời hạn {formatdate(exercise.deadline)} </div>
                            <div>{answerItem.point}/10 Điểm</div>
                        </div>
                        <div className='content_detail2'>
                            <p>
                                {exercise.description}
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div className='upload_area1'>
                <div className='upload_exercise1'>
                    <div>
                        <p style={{ fontSize: '22px' }}>Câu trả lời:</p>
                        <p style={{ fontSize: '13px' }}>Thời gian trả lời: {formatdate(answerItem.dateAnswer)}</p>
                    </div>
                    <div>
                        <p>{answerItem.content}</p>
                        {answerItem.linkFile != linkFile && <a href={answerItem.linkFile} target='_banlk'>Đính kèm tệp</a>}

                    </div>
                    <div className='group_button1'>
                        <Button
                            onClick={handleClickOpen}
                            variant="contained"
                            disabled={answerItem.dateSetPoint != null ? new Date(exercise.deadline) > curendate ? false : true : false}
                            style={{ marginBottom: "5px", borderRadius: 10, width: '12vw' }}
                        >
                            {answerItem.dateSetPoint == null ? "chấm điểm" : "chấm lại"}
                        </Button>
                        <GoBackButton />
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
                    <SetPointUser closeDialog={handleClose} classData={classData} exercise={exercise.idExercise} answerItem={answerItem} userHost={userHost} />
                </DialogContent>
            </Dialog>
        </div>

    )
}

export default GardeUserAnswer
