import React, { useState, useEffect } from 'react'
import { Avatar, Button } from '@material-ui/core';
import PermIdentityOutlinedIcon from '@material-ui/icons/PermIdentityOutlined';
import PermContactCalendarOutlinedIcon from '@material-ui/icons/PermContactCalendarOutlined';
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
import LockOpenOutlinedIcon from '@material-ui/icons/LockOpenOutlined';
import CancelOutlinedIcon from '@material-ui/icons/CancelOutlined';
import classApi from 'api/classApi';
import Role from 'constants/role';
import "./style.css";


const Community = ({ classData }) => {

  const [userHost, settuserHost] = useState([]);
  const [userMember, setuserMember] = useState([]);
  const [countuser, setcountuser] = useState(0);
  useEffect(() => {
    const fetchData = async () => {
      const params = new URLSearchParams([['idClassroom', classData.idClassroom]]);
      const result = await classApi.getClassById(params);
      settuserHost(result.listMembers.filter(x => x.role == Role.HOST));
      setuserMember(result.listMembers.filter(x => x.role == Role.MEMBER));
      setcountuser(result.listMembers.filter(x => x.role == Role.MEMBER).length)
    };
    fetchData();
  }, []);

  return (
    <div>
      <div className='role'>
        <h1>Giảng viên</h1>
      </div>
      <ul className='list_informations'>
        {userHost.map((item, index) => (
          <li key={index} className='information'>
            <div className='lecturer_information'>
              <Avatar style={{ m: 1, backgroundColor: 'rgb(0, 159, 212)' }}>
                <PermContactCalendarOutlinedIcon />
              </Avatar>
              <div className='name'>{item.nameMember}</div>
            </div>           
          </li>
        ))}

      </ul>
      <div className='role'>
        <h1>Sinh viên</h1>
        <div className='quantity'>{countuser} sinh viên</div>
      </div>
      <ul className='list_informations'>
        {userMember.map((item, index) => (
          <li key={index} className='information'>
            <div className='student_information'>
              <Avatar style={{ m: 1, backgroundColor: 'deeppink'}}>
                <PermIdentityOutlinedIcon />
              </Avatar>
              <div className='name'>{item.nameMember}</div>
            </div>           
            <div>
              <Button startIcon={<CancelOutlinedIcon/>} style={{marginRight: '10px'}}>
                Xóa
              </Button>
            </div>
          </li>
        ))}

      </ul>
    </div>
  )
}

export default Community
