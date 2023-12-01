import React from 'react'
import ''
import { Avatar, Button } from '@material-ui/core';
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
import LockOpenOutlinedIcon from '@material-ui/icons/LockOpenOutlined';
import CancelOutlinedIcon from '@material-ui/icons/CancelOutlined';
import BadgeOutlinedIcon from '@material-ui/icons/BadgeOutlinedIcon';

const AdminClassroom = () => {
  return (
    <div>
        <div className='admin_classroom'>
            <h1>Quản lý lớp học</h1>
            <div className='classroom_quantity'>0 lớp học</div>
        </div>     
        <ul className='list_classroom'>
            <li className='classroom_info'>
                <div className='infor'>
                    <Avatar style={{m:1, backgroundColor: 'rgb(204, 204, 55)'}}>
                        <BadgeOutlinedIcon />
                    </Avatar>
                    <div className='classroom_name'> Tên lớp học </div>
                </div>
                <div>
                <Button startIcon={<LockOpenOutlinedIcon/>} style={{marginRight: '10px'}}>
                    Mở khóa
                </Button>
                <Button startIcon={<LockOutlinedIcon/>} style={{marginRight: '10px'}}>
                    Khóa
                </Button>
                <Button startIcon={<CancelOutlinedIcon/>} style={{marginRight: '10px'}}>
                    Xóa
                </Button>
                </div>
            </li>
        </ul>     
    </div>
  )
}

export default AdminClassroom

