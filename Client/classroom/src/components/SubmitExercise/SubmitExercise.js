import React from 'react'
import "./style.css"
import { Avatar } from '@material-ui/core';
import EditNoteOutlinedIcon from '@material-ui/icons/EditAttributesOutlined';
import Button from '@material-ui/core/Button';

const SubmitExercise = ({classDate},{exercise}) => {
  return (
    <div className='submit_exercise'>
      <div className='main_area'>
        <Avatar style={{backgroundColor: 'grey'}}>
          <EditNoteOutlinedIcon/>
        </Avatar>
        <div className='upload_detail'>
          <h1 className='title_text1'>Tiêu đề hiển thị ở đây</h1>
          <p>--- Tên giảng viên --- Thời gian giao ##:## (Đã chỉnh sửa ##:##)</p>
          <div className='content1'>
            <div className='content_text1'>
                <div>Điểm tối đa hiển thị ở đây</div>
                <div className='deadline1'> Thời hạn hiển thị ở đây </div>
            </div>
            <div className='content_detail1'>
                <p>Nội dung hiển thị ở đây: Nội dung hiển thị ở đây: Nội dung hiển thị ở đây:Nội dung hiển thị ở đây: </p>
                <p>Nội dung hiển thị ở đây:</p>
                <p>Nội dung hiển thị ở đây:</p>
                <p>Nội dung hiển thị ở đây:</p>
                <p>Nội dung hiển thị ở đây:</p>
                <p>Nội dung hiển thị ở đây:</p>
                <p>Nội dung hiển thị ở đây:</p>
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
              style={{mb: 2,borderRadius: 10}}
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
              style={{mb: 2,borderRadius: 10}}
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
