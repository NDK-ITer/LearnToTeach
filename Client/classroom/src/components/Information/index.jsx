import React, { useEffect, useState } from "react";
import { StorageKeys } from "constants/storage-keys";
import userApi from "api/userApi";
import "./style.css";
import FingerprintOutlinedIcon from '@material-ui/icons/FingerprintOutlined';
import { Avatar, Button } from "@material-ui/core";
import Dialog from '@material-ui/core/Dialog';
import DialogContent from '@material-ui/core/DialogContent';
import { Close } from '@material-ui/icons';
import { IconButton } from '@material-ui/core';
import InfoOutlinedIcon from '@material-ui/icons/InfoOutlined';
import EnhancedEncryptionOutlinedIcon from '@material-ui/icons/EnhancedEncryptionOutlined';
import UpdateInfor from "./UpdateInfor";
import formatDate from "constants/formatdate";
import ChangePassword from "components/Auth/ChangePassword";

const Information = () => {
  const user = JSON.parse(localStorage.getItem(StorageKeys.USER))
  const [userInfor, setUserInfor] = useState('');
  useEffect(() => {
    const fetchData = async () => {
      const formData = new FormData()
      formData.append('idUser', user.id);
      const result = await userApi.getclassroom(formData);
      setUserInfor(result);

    };
    fetchData();
  }, []);

  const [openEdit, setopenEdit] = useState(false);
  const handleClickopenEdit = () => {
    setopenEdit(true);
  };
  const handleCloseEdit = () => {
    setopenEdit(false);
  };
  const [openChangePassword, setopenChangePassword] = useState(false);
  const handleClickopenChangePassword = () => {
    setopenChangePassword(true);
  };
  const handleCloseChangePassword = () => {
    setopenChangePassword(false);
  };
  return (
    <div>
      <div className='account_detail'>
        <div className='account_main_detail'>
          <Avatar style={{ backgroundColor: 'black' }}>
            <FingerprintOutlinedIcon />
          </Avatar>
          <div className='personal_detail'>
            <h1 className='title_text_1'>Thông tin cá nhân</h1>
            <p style={{ paddingBottom: '10px' }}>--- Ngày tạo tài khoản: {formatDate(userInfor.createDate)} ---</p>
          </div>
        </div>
        <div className='account_information'>
          <div className="edit_change_button">
            <Button variant="contained" onClick={handleClickopenEdit} startIcon={<InfoOutlinedIcon />} style={{ marginRight: '30px' }}>
              Sửa thông tin
            </Button>
            <Button variant="contained" onClick={handleClickopenChangePassword} color="primary" startIcon={<EnhancedEncryptionOutlinedIcon />} >
              Đổi mật khẩu
            </Button>
          </div>
          <div className="information_area">
            <Avatar
              className="avatar"
              src={userInfor.avatar != null ? userInfor.avatar : "https://lh3.googleusercontent.com/-XdUIqdMkCWA/AAAAAAAAAAI/AAAAAAAAAAA/4252rscbv5M/s75-c-fbw=1/photo.jpg"}
            />
            <div className="user_information">
              <p>Họ Tên : {userInfor.fullName}</p>
              <p>Email : {userInfor.email}</p>
              <p>Số điện thoại: {userInfor.phoneNumber}</p>
            </div>
          </div>
        </div>
      </div>
      <Dialog
        disableBackdropClick
        disableEscapeKeyDown
        open={openEdit}
        onClose={handleCloseEdit}
        aria-labelledby="form-dialog-title"
      >
        <IconButton onClick={handleCloseEdit}>
          <Close />
        </IconButton>

        <DialogContent>
          <UpdateInfor closeDialog={handleCloseEdit} userInfor={userInfor} />
        </DialogContent>
      </Dialog>
      <Dialog
        disableBackdropClick
        disableEscapeKeyDown
        open={openChangePassword}
        onClose={handleCloseChangePassword}
        aria-labelledby="form-dialog-title"
      >
        <IconButton onClick={handleCloseChangePassword}>
          <Close />
        </IconButton>

        <DialogContent>
          <ChangePassword closeDialog={handleCloseChangePassword} />
        </DialogContent>
      </Dialog>
    </div>
  )
}

export default Information
