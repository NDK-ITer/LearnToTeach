import React from 'react';
import "./style.css";
import { Avatar } from '@material-ui/core';
import AssignmentOutlinedIcon from '@material-ui/icons/AssessmentOutlined';
import Switch from '@material-ui/core/Switch';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import FactCheckOutlinedIcon from '@material-ui/icons/FaceOutlined';

const ExerciseDetail = ({classDate},{exercises}) => {
  return (
    <div>
        <div className='exercise_detail'>
            <div className='main_detail'>
                <Avatar style={{backgroundColor: 'black'}}>
                    <AssignmentOutlinedIcon />
                </Avatar>
                <div className='upload_detail'>
                    <h1 className='title_text'>Tiêu đề hiển thị ở đây</h1>
                    <p>--- Tên giảng viên --- Thời gian giao ##:## (Đã chỉnh sửa ##:##)</p>
                </div>                  
            </div>
            <div className='content'>
                <div className='content_text'>
                    <div>Điểm tối đa hiển thị ở đây</div>
                    <div className='deadline'> Thời hạn hiển thị ở đây </div>
                </div>
                <div className='content_detail'>
                    <p>Nội dung hiển thị ở đây:</p>
                    <p>Nội dung hiển thị ở đây:</p>
                    <p>Nội dung hiển thị ở đây:</p>
                    <p>Nội dung hiển thị ở đây:</p>
                    <p>Nội dung hiển thị ở đây:</p>
                    <p>Nội dung hiển thị ở đây:</p>
                    <p>Nội dung hiển thị ở đây:</p>
                </div>
            </div>  
            <div className='switch'>
                <FormControlLabel control={<Switch defaultChecked />} label="Nhận bài nộp muộn" />
            </div>       
            <div className='list_submit'>
                <h2 className='submit_quantity'>(số lượng) Đã nộp/(tổng số) Sinh viên</h2>
                <ul className='list_submited'>
                    <li className='student'>
                        <Avatar style={{m:1, backgroundColor: 'rgb(34, 186, 34)'}}>
                            <FactCheckOutlinedIcon />
                        </Avatar>
                        <div className='student_name'> Tên sinh viên 1 </div>
                        <div className='submit_time'> Thời gian nộp </div>
                    </li>
                    <li className='student'>
                        <Avatar style={{m:1, backgroundColor: 'rgb(34, 186, 34)'}}>
                            <FactCheckOutlinedIcon />
                        </Avatar>
                        <div className='student_name'> Tên sinh viên 2 </div>
                        <div className='submit_time'> Thời gian nộp </div>
                    </li>
                </ul>  
            </div>     
        </div>
                         
    </div>
  )
}

export default ExerciseDetail
