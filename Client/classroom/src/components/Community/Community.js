import React, { useState, useEffect } from 'react'
import { Avatar, Button, Grid, TextField } from '@material-ui/core';
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
import SearchOutlinedIcon from '@material-ui/icons/SearchOutlined';
import userApi from 'api/userApi';
import Dialog from '@material-ui/core/Dialog';
import DialogContent from '@material-ui/core/DialogContent';
import { Close } from '@material-ui/icons';
import { IconButton } from '@material-ui/core';

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
      settuserHost(result.listMembers.find(x => x.role == Role.HOST));
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
      const params = new URLSearchParams([['idClassroom', classData.idClassroom], ['idMember', idMember], ['idHostMember', userHost.idMember]]);
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

  const [searchTerm, setSearchTerm] = useState('');
  const [searchResults, setSearchResults] = useState([]);
  const handleInputChange = (event) => {
    const term = event.target.value;
    setSearchTerm(term);
    if (term.trim() === '') {
      setSearchResults([]);
    } else {
      const filteredMembers = userMember.filter(member =>
        member.nameMember.toLowerCase().includes(term.toLowerCase())
      );
      setSearchResults(filteredMembers);
    }
  };

  // Display all members if search term is empty
  const displayMembers = searchTerm.trim() === '' ? userMember : searchResults;

  const [selectedUser, setSelectedUser] = useState(null);
  const [isLoading, setIsLoading] = useState(false);
  const [openDialog, setOpenDialog] = useState(false);

  const handleClick = async (idUser) => {
    try {
      setIsLoading(true);
      // Fetch user data from API based on userId
      const params = new URLSearchParams([['idUser', idUser]]);
      const result = await userApi.GetUserById(params);
      setSelectedUser(result);

      setOpenDialog(true);
    } catch (error) {
      console.error('Error fetching user data:', error);
    } finally {
      setIsLoading(false);
    }
  };

  const handleCloseDialog = () => {
    setOpenDialog(false);
    setSelectedUser(null);
  };
  console.log(selectedUser)

  return (
    <div>
      <div className='role'>
        <h1>Giảng viên</h1>
      </div>
      <ul className='list_informations'>
        <li className='information'>
          <div className='lecturer_information'>
            <Avatar style={{ m: 1, backgroundColor: 'rgb(0, 159, 212)' }}
              src={userHost.avatar != null ? userHost.avatar : "https://lh3.googleusercontent.com/-XdUIqdMkCWA/AAAAAAAAAAI/AAAAAAAAAAA/4252rscbv5M/s75-c-fbw=1/photo.jpg"}
            />
            <div className='name'>{userHost.nameMember}</div>
          </div>
        </li>
      </ul>
      <div className='role'>
        <h1>Sinh viên</h1>
        <div className='search_area'>
          <Grid container spacing={1} alignItems="flex-end">
            <Grid item>
              <SearchOutlinedIcon />
            </Grid>
            <Grid item>
              <TextField id="input-with-icon-grid" type="text"
                value={searchTerm}
                onChange={handleInputChange}
                placeholder="tìm kiếm..." />
            </Grid>
          </Grid>
        </div>
        <div className='quantity'>Tổng số: {countuser} sinh viên</div>
      </div>
      <ul className='list_informations'>
        {displayMembers.map((item, index) => (
          <li key={index} className='information'>
            <div className='student_information'>
              {isUserHost && <Avatar style={{ m: 1, backgroundColor: 'deeppink', cursor: 'pointer' }} onClick={() => handleClick(item.idMember)}
                src={item.avatar != null ? item.avatar : "https://lh3.googleusercontent.com/-XdUIqdMkCWA/AAAAAAAAAAI/AAAAAAAAAAA/4252rscbv5M/s75-c-fbw=1/photo.jpg"}
              />}
              {!isUserHost && <Avatar style={{ m: 1, backgroundColor: 'deeppink' }}
                src={item.avatar != null ? item.avatar : "https://lh3.googleusercontent.com/-XdUIqdMkCWA/AAAAAAAAAAI/AAAAAAAAAAA/4252rscbv5M/s75-c-fbw=1/photo.jpg"}
              />}
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
        message="Bạn có chắc muốn xóa sinh viên này ra khỏi lớp?"
      />
      <Dialog
        disableBackdropClick
        disableEscapeKeyDown
        open={openDialog}
        onClose={handleCloseDialog}
        aria-labelledby="form-dialog-title"
      >
        <IconButton onClick={handleCloseDialog}>
          <Close />
        </IconButton>

        <DialogContent>
          <div className="information_area">
            <Avatar
              className="avatar"
              src={selectedUser?.avatar != null ? selectedUser?.avatar : "https://lh3.googleusercontent.com/-XdUIqdMkCWA/AAAAAAAAAAI/AAAAAAAAAAA/4252rscbv5M/s75-c-fbw=1/photo.jpg"}
            />
            <div className="user_information">
              <p>Họ Tên : {selectedUser?.fullName}</p>
              <p>Email : {selectedUser?.email}</p>
              <p>Số điện thoại: {selectedUser?.phoneNumber}</p>
            </div>
          </div>
        </DialogContent>
      </Dialog>
    </div>
  )
}

export default Community
