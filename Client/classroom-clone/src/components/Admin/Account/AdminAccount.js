import React from 'react'
import ''
import { Button } from '@material-ui/core'
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
import LockOpenOutlinedIcon from '@material-ui/icons/LockOpenOutlined';
import CancelOutlinedIcon from '@material-ui/icons/CancelOutlined';
import BadgeOutlinedIcon from '@material-ui/icons/BadgeOutlinedIcon';

const AdminClassroom = () => {
  return (
    <div>
        <div className='admin_lecturer_account'>
            <h1>Quản lý tài khoản giảng viên</h1>
            {/* <div className='classroom_quantity'>0 lớp học</div> */}
        </div>     
        <ul className='list_lecturers'>
            <li className='lecturer_infomation'>
                <div className='infor_'>
                    <Avatar style={{m:1, backgroundColor: 'rgb(204, 204, 55)'}}>
                        <BadgeOutlinedIcon />
                    </Avatar>
                    <div className='lecturer_name'> Tên giảng viên </div>
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
        <div className='admin_student_account'>
            <h1>Quản lý tài khoản sinh viên</h1>
            <div className='student_quantity'>0 sinh viên</div>
        </div>
        <ul className='list_students'>
            <li key={index} className='student_information'>
                <div className='infor'>
                <Avatar style={{ m: 1, backgroundColor: 'rgb(219, 127, 52)',color: 'black' }}>
                    <BadgeOutlinedIcon />
                </Avatar>
                <div className='student_name'>{item.nameMember}</div>
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

