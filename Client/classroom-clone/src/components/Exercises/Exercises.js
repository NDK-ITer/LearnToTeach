import * as React from 'react';
import { NavigationBar} from "..";
import { Avatar} from "@material-ui/core";
import Button from '@mui/material/Button';
import LibraryBooksOutlinedIcon from '@mui/icons-material/LibraryBooksOutlined';
import "./style.css";
//import { useStyles } from "./style";

const Exercises = () => {
  //const classes = useStyles();
  return (
    <div>
      <NavigationBar />
      <Button
        type="submit"
        variant="contained"
        sx={{ml: 50, mt:2, pl:2, pr:2, borderRadius: 20}}
      >
        + Tạo bài tập
      </Button>
      <div className='status'>
        <h1>Đã giao</h1>
      </div>     
      <ul className='list_tasks'>
        <li className='task'>
          <Avatar style={{m:1 ,backgroundColor: 'rgb(0, 159, 212)'}}>
                <LibraryBooksOutlinedIcon />
          </Avatar>
          <div className='task_name'> Tên bài tập </div>
          <div className='task_deadline'> Thời hạn </div>
        </li>
      </ul>     
      <div className='status'>
        <h1>Đã hoàn thành</h1>
      </div>     
      <ul className='list_tasks'>
        <li className='task'>
          <Avatar style={{m:1 ,backgroundColor: 'rgb(4, 214, 46)'}}>
                <LibraryBooksOutlinedIcon />
          </Avatar>
          <div className='task_name'> Tên bài tập </div>
          <div className='task_deadline'> Đã nộp </div>
        </li>
      </ul>     
      <div className='status'>
        <h1>Chưa hoàn thành</h1>
      </div>     
      <ul className='list_tasks'>
        <li className='task'>
          <Avatar style={{m:1 ,backgroundColor: 'rgb(233, 0, 0)'}}>
                <LibraryBooksOutlinedIcon />
          </Avatar>
          <div className='task_name'> Tên bài tập </div>
          <div className='task_deadline'> Thời hạn </div>
        </li>
      </ul>     
    </div>
  )
}

export default Exercises;
