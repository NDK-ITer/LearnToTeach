import React, { useEffect, useState } from 'react';
import { Avatar } from "@material-ui/core";
import Button from '@material-ui/core/Button';
import LibraryBooksOutlinedIcon from '@material-ui/icons/LibraryBooksOutlined';
import classApi from 'api/classApi';
import Role from 'constants/role';
import { useLocalContext } from 'context';
import "./style.css";

function formatDateToDDMMYYYY(date) {
  const day = String(date.getDate()).padStart(2, '0');
  const month = String(date.getMonth() + 1).padStart(2, '0'); // Months are zero-based
  const year = date.getFullYear();

  return `${day}-${month}-${year}`;
}
const Exercises = ({ classData }) => {
  const { user } = useLocalContext();
  const [isUserHost, setisUserHost] = useState(false);
  const [isUserMember, setisUserMember] = useState(false);
  const [exercisesExpired, setexercisesExpired] = useState([]);
  const [exercisesActive, setexercisesActive] = useState([]);
  const userid = JSON.parse(user);
  const currentDate = new Date();
  useEffect(() => {
    const fetchData = async () => {
      const params = new URLSearchParams([['idClassroom', classData.idClassroom]]);
      const result = await classApi.getClassById(params);
      setisUserHost(result.listMembers.filter(x => x.role == Role.HOST && userid.id == x.idMember).length > 0 ? true : false);
      setisUserMember(result.listMembers.filter(x => x.role == Role.MEMBER && userid.id == x.idMember).length > 0 ? true : false);
      setexercisesActive(result.listExercises.filter(x => new Date(x.deadline) >= currentDate).sort((a, b) => new Date(b.deadline) - new Date(a.deadline)));
      setexercisesExpired(result.listExercises.filter(x => new Date(x.deadline) < currentDate).sort((a, b) => new Date(b.deadline) - new Date(a.deadline)));

    };
    fetchData();
  }, []);
  
  return (
    <div>
      {isUserHost && <div>
        <Button
          type="submit"
          variant="contained"
          className='btn_create'
          style={{ marginLeft: 250, borderRadius: 20, backgroundColor: "rgb(25, 118, 210)", color: "#fff" }}
        >
          <a href={`/${classData.idClassroom}/exercises/create`} style={{ color: "#fff", textDecoration: 'none' }}>
            + Tạo bài tập
          </a>
        </Button>
        <div className='status'>
          <h1 style={{ paddingTop: 12 }}>còn hạn</h1>
        </div>
        <ul className='list_tasks'>
          {exercisesActive.map((item, index) => (
            <li key={index} className='task'>
              <a href={`/${classData.idClassroom}/exercises/${item.idExercise}`}>
              <Avatar style={{ m: 1, backgroundColor: 'rgb(4, 214, 46)' }}>
                <LibraryBooksOutlinedIcon />
              </Avatar>
              </a>
              <div className='task_name'>{item.name}</div>
              <div className='task_deadline'>{formatDateToDDMMYYYY(new Date(item.deadline))} </div>
            </li>
          ))}
        </ul>
        <div className='status'>
          <h1 style={{ paddingTop: 12 }}>hết hạn</h1>
        </div>
        <ul className='list_tasks'>
          {exercisesExpired.map((item, index) => (
            <li key={index} className='task'>
               <a href={`/${classData.idClassroom}/exercises/${item.idExercise}`}>
               <Avatar style={{ m: 1, backgroundColor: 'rgb(233, 0, 0)' }}>
                <LibraryBooksOutlinedIcon />
              </Avatar>
              </a>            
              <div className='task_name'> {item.name} </div>
              <div className='task_deadline'>{formatDateToDDMMYYYY(new Date(item.deadline))} </div>
            </li>
          ))}
        </ul>
      </div>}
      {isUserMember && <div>
       
        <div className='status'>
          <h1 style={{ paddingTop: 12 }}>Đã giao</h1>
        </div>
        <ul className='list_tasks'>
          <li className='task'>
            <Avatar style={{ margin: 1, backgroundColor: 'rgb(0, 159, 212)' }}>
              <LibraryBooksOutlinedIcon />
            </Avatar>
            <div className='task_name'> Tên bài tập </div>
            <div className='task_deadline'> Thời hạn </div>
          </li>
        </ul>
        <div className='status'>
          <h1 style={{ paddingTop: 12 }}>Đã hoàn thành</h1>
        </div>
        <ul className='list_tasks'>
          <li className='task'>
            <Avatar style={{ m: 1, backgroundColor: 'rgb(4, 214, 46)' }}>
              <LibraryBooksOutlinedIcon />
            </Avatar>
            <div className='task_name'> Tên bài tập </div>
            <div className='task_deadline'> Đã nộp </div>
          </li>
        </ul>
        <div className='status'>
          <h1 style={{ paddingTop: 12 }}>Chưa hoàn thành</h1>
        </div>
        <ul className='list_tasks'>
          <li className='task'>
            <Avatar style={{ m: 1, backgroundColor: 'rgb(233, 0, 0)' }}>
              <LibraryBooksOutlinedIcon />
            </Avatar>
            <div className='task_name'> Tên bài tập </div>
            <div className='task_deadline'> Thời hạn </div>
          </li>
        </ul>
      </div>}
    </div>

  )
}

export default Exercises;
