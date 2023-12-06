import React from "react";
import "./style.css";
import FingerprintOutlinedIcon from '@material-ui/icons/FingerprintOutlined';
import { Avatar, TextField, Button } from "@material-ui/core";
import InfoOutlinedIcon from '@material-ui/icons/InfoOutlined';
import EnhancedEncryptionOutlinedIcon from '@material-ui/icons/EnhancedEncryptionOutlined';
  
  const Info = () => {
    return (
      <div>
        <div className='account_detail'>
            <div className='account_main_detail'>
                <Avatar style={{backgroundColor: 'black'}}>
                    <FingerprintOutlinedIcon />
                </Avatar>
                <div className='personal_detail'>
                    <h1 className='title_text_1'>Thông tin cá nhân</h1>
                    <p style={{paddingBottom: '10px'}}>--- Ngày tạo tài khoản ---</p>
                </div>                  
            </div>
            <div className='account_information'>
              <div className="edit_change_button">
                <Button variant="contained" startIcon={<InfoOutlinedIcon/>} style={{marginRight: '30px'}}>
                  Sửa thông tin
                </Button>
                <Button variant="contained" color="primary" startIcon={<EnhancedEncryptionOutlinedIcon/>} >
                  Đổi mật khẩu
                </Button>
              </div>
              <div className="information_area">
                <TextField
                  disabled
                  label="Họ"
                  defaultValue="Test test"
                  variant="filled"
                  fullWidth
                  style={{margin: '20px 0px'}}
                />
                <TextField
                  disabled
                  label="Tên"
                  defaultValue="Test test"
                  variant="filled"
                  fullWidth
                  style={{margin: '20px 0px'}}
                />
                <TextField
                  disabled
                  label="Số điện thoại"
                  defaultValue="1234567890"
                  variant="filled"
                  fullWidth
                  style={{margin: '20px 0px'}}
                />
                <TextField
                  disabled
                  label="Địa chỉ Email"
                  defaultValue="test@gmail.com"
                  variant="filled"
                  fullWidth
                  style={{margin: '20px 0px'}}
                />
              </div>
            </div>           
        </div>
      </div>
    )
  }
  
  export default Info
  