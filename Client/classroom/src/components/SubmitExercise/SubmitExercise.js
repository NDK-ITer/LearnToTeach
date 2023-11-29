import React from 'react'
import "./style.css"
import { Avatar } from '@material-ui/core';
import EditNoteOutlinedIcon from '@material-ui/icons/EditAttributesOutlined';
import Button from '@material-ui/core/Button';
import formatdate from 'constants/formatdate';

const SubmitExercise = ({ exercises, classData, userHost }) => {

  console.log(classData)
  console.log(exercises)
  console.log(userHost)
  return (
    <div className='submit_exercise'>
      <div className='main_area'>
        <Avatar style={{ backgroundColor: 'grey' }}>
          <EditNoteOutlinedIcon />
        </Avatar>
        <div className='upload_detail'>
          <h1 className='title_text1'>{exercises.name}</h1>
          <p>--- {userHost.nameMember} --- Thời gian giao {formatdate(exercises.createDate)}</p>
          <div className='content1'>
            <div className='content_text1'>
              <div className='deadline1'> Thời hạn {formatdate(exercises.deadline)} </div>
            </div>
            <div className='content_detail1'>
              <p>
                {exercises.description}
              </p>
              
            </div>
          </div>
        </div>
      </div>
      <div className='upload_area'>
        <div className='upload_exercise'>
          <div className='your_exercise'>
            <p>Bài tập của bạn</p>
          </div>
          <div className='group_button'>
            <Button
              fullWidth
              style={{ mb: 2, borderRadius: 10 }}
              variant="outlined"
              component="label"
            >
              + Thêm hoặc tạo
              <input
                type="file"
                hidden
              />
            </Button>
            <Button
              onclick={'#'}
              type="submit"
              variant="contained"
              fullWidth
              style={{ mb: 2, borderRadius: 10 }}
            >
              Nộp bài
            </Button>
          </div>

        </div>
      </div>

    </div>

  )
}

export default SubmitExercise
