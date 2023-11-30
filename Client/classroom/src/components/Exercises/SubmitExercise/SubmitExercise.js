import React from 'react'
import "./style.css"
import { Avatar } from '@material-ui/core';
import EditNoteOutlinedIcon from '@material-ui/icons/EditAttributesOutlined';
import Button from '@material-ui/core/Button';
import formatdate from 'constants/formatdate';

const SubmitExercise = ({ exercise, classData, userHost, user }) => {

  console.log(classData)
  console.log(exercise)
  console.log(userHost)

  const getPointForIdMember = (idMember) => {
      const answer = exercise.listAnswer.find(answer => answer.idMember === idMember);
      if (answer) {
        return answer.point;
      }
    return null;
  };
  console.log(exercise.listAnswer.find(answer => answer.idMember === user.id))
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
              <div>{getPointForIdMember(user.id)==null?"0":getPointForIdMember(user.id)}/10 Điểm</div>
            </div>
            <div className='content_detail1'>
              <p>
                {exercise.description}
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
