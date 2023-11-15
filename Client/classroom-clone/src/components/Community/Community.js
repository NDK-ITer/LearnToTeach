import * as React from 'react'
import { NavigationBar} from "..";
import { Avatar } from '@material-ui/core';
import BadgeOutlinedIcon from '@mui/icons-material/BadgeOutlined';
import PermIdentityOutlinedIcon from '@mui/icons-material/PermIdentityOutlined';
import "./style.css";

const Community = () => {
  return (  
    <div>
      <NavigationBar/>
      <div className='role'>
        <h1>Giảng viên</h1>
      </div>     
      <ul className='list_informations'>
        <li className='information'>
          <Avatar style={{m:1, backgroundColor: 'rgb(204, 204, 55)'}}>
                <BadgeOutlinedIcon />
          </Avatar>
          <div className='name'> Tên giảng viên </div>
        </li>
      </ul>     
      <div className='role'>
        <h1>Sinh viên</h1>
        <div className='quantity'>0 sinh viên</div>
      </div>     
      <ul className='list_informations'>
        <li className='information'>
          <Avatar style={{m:1, backgroundColor: 'rgb(219, 127, 52)'}}>
                <PermIdentityOutlinedIcon />
          </Avatar>
          <div className='name'> Tên sinh viên </div>
        </li>
      </ul>  
    </div>
  )
}

export default Community
