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
import { useLocalContext } from 'context';
import { ConfirmationNumber } from '@material-ui/icons';
import { useSnackbar } from 'notistack';
import ConfirmationDialog from 'components/ConfirmationDialog';


const Community = ({ classData }) => {

  const { user } = useLocalContext();
  const [userHost, settuserHost] = useState([]);
  const [isUserHost, settIsUserHost] = useState(false);
  const [userMember, setuserMember] = useState([]);
  const [countuser, setcountuser] = useState(0);
  const { enqueueSnackbar } = useSnackbar();
  useEffect(() => {
    const fetchData = async () => {
      const params = new URLSearchParams([['idClassroom', classData.idClassroom]]);
      const result = await classApi.getClassById(params);
      settuserHost(result.listMembers.filter(x => x.role == Role.HOST));
      settIsUserHost(result.listMembers.filter(x => x.role == Role.HOST && x.idMember == user.id).length > 0 ? true : false);
      setuserMember(result.listMembers.filter(x => x.role == Role.MEMBER));
      setcountuser(result.listMembers.filter(x => x.role == Role.MEMBER).length)
    };
    fetchData();
  }, []);
  const [dialogOpenMember, setDialogOpenMember] = useState(false);
  const [idMember, setIdMember] = useState(null);
  const handleIdMenber = (item) => {
    setIdMember(item);
    setDialogOpenMember(true);
  };
  const handleCloseMember = () => {
    setIdMember(null);
    setDialogOpenMember(false);
  };
  const handledeleteMember = async () => {
    try {
      const params = new URLSearchParams([['idClassroom', classData.idClassroom], ['idMember', idMember]]);
      const result = await classApi.removemember(params);
      console.log(result)
      if (result.status == 1) {
        enqueueSnackbar(result.message, { variant: 'success' });
        window.location.reload();
      } else {
        enqueueSnackbar(result.message, { variant: 'error' });
      }

    } catch (error) {
      console.log('Failed to login:', error);
      enqueueSnackbar(error.message, { variant: 'error' });
    }
  };
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
              <Avatar style={{ m: 1, backgroundColor: 'deeppink' }}>
                <PermIdentityOutlinedIcon />
              </Avatar>
              <div className='name'>{item.nameMember}</div>
            </div>
            <div>
              {isUserHost && <Button onClick={() => handleIdMenber(item.idMember)} startIcon={<CancelOutlinedIcon />} style={{ marginRight: '10px' }}>
                Xóa
              </Button>}
            </div>
          </li>
        ))}
      </ul>
      <ConfirmationDialog
        open={dialogOpenMember}
        onClose={handleCloseMember}
        onConfirm={handledeleteMember}
        message="Are you sure you want to Notify?"
      />
    </div>
  )
}

export default Community
