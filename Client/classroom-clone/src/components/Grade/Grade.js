import React from 'react'
import { NavigationBar} from "..";
import { Avatar } from '@material-ui/core';
import "./style.css";
import CancelOutlinedIcon from '@mui/icons-material/CancelOutlined';
import CheckCircleOutlinedIcon from '@mui/icons-material/CheckCircleOutlined';

const Grade = () => {
  return (
    <div>
      <NavigationBar/>
      <div className='status'>
        <h1>Đã chấm</h1>
      </div>     
      <ul className='list_results'>
        <li className='result'>
          <Avatar style={{m:1, backgroundColor: 'rgb(4, 214, 46)'}}>
                <CheckCircleOutlinedIcon />
          </Avatar>
          <div className='name'>Tên bài tập </div>
          <div className='grade'>Điểm số: </div>
        </li>
      </ul>     
      <div className='status'>
        <h1>Chưa chấm</h1>
      </div>     
      <ul className='list_results'>
        <li className='result'>
          <Avatar style={{m:1, backgroundColor: 'rgb(233, 0, 0)'}}>
                <CancelOutlinedIcon />
          </Avatar>
          <div className='name'> Tên bài tập </div>
          <div className='grade'>Đang chờ chấm</div>
        </li>
      </ul>  
    </div>
  )
}

export default Grade
