import React, { useEffect, useState } from 'react';
import { Avatar } from "@material-ui/core";
import Button from '@material-ui/core/Button';
import LibraryBooksOutlinedIcon from '@material-ui/icons/LibraryBooksOutlined';
import classApi from 'api/classApi';
import Role from 'constants/role';
import { useLocalContext } from 'context';
import "./style.css";
import formatDate from 'constants/formatdate';
import { ExitToAppOutlined } from '@material-ui/icons';
import ConfirmationDialog from 'components/ConfirmationDialog';
import { useSnackbar } from 'notistack';


const Exercises = ({ classData }) => {
  const { user } = useLocalContext();
  const { enqueueSnackbar } = useSnackbar();
  const [isUserHost, setisUserHost] = useState(false);
  const [UserHost, setUserHost] = useState(false);
  const [isUserMember, setisUserMember] = useState(false);
  const [exercisesExpired, setexercisesExpired] = useState([]);
  const [exercisesActive, setexercisesActive] = useState([]);
  const [exercisesCompleted, setexercisesCompleted] = useState([]);
  const [exercisesNotCompleted, setexercisesNotCompleted] = useState([]);
  const [exercisesAssigned, setexercisesAssigned] = useState([]);
  const currentDate = new Date();
  useEffect(() => {
    const fetchData = async () => {
      const params = new URLSearchParams([['idClassroom', classData.idClassroom]]);
      const result = await classApi.getClassById(params);
      setUserHost(result.listMembers.find(x => x.role == Role.HOST))
      setisUserHost(result.listMembers.filter(x => x.role == Role.HOST && user.id == x.idMember).length > 0 ? true : false);
      setisUserMember(result.listMembers.filter(x => x.role == Role.MEMBER && user.id == x.idMember).length > 0 ? true : false);
      let isUserHost = result.listMembers.filter(x => x.role == Role.HOST && user.id == x.idMember).length > 0 ? true : false
      if (isUserHost) {
        setexercisesActive(result.listExercises.filter(x => new Date(x.deadline) >= currentDate).sort((a, b) => new Date(b.deadline) - new Date(a.deadline)));
        setexercisesExpired(result.listExercises.filter(x => new Date(x.deadline) < currentDate).sort((a, b) => new Date(b.deadline) - new Date(a.deadline)));

      } else {
        setexercisesCompleted(result.listExercises.filter(x => x.listAnswer.filter(c => c.idMember == user.id).length > 0).sort((a, b) => new Date(b.deadline) - new Date(a.deadline)));
        setexercisesNotCompleted(result.listExercises.filter(x => new Date(x.deadline) < currentDate && x.listAnswer.filter(c => c.idMember == user.id).length <= 0).sort((a, b) => new Date(b.deadline) - new Date(a.deadline)));
        setexercisesAssigned(result.listExercises.filter(x => new Date(x.deadline) >= currentDate && x.listAnswer.filter(c => c.idMember == user.id).length <= 0).sort((a, b) => new Date(b.deadline) - new Date(a.deadline)));
      }
    };
    fetchData();
  }, []);

  const [dialogOpenExercise, setDialogOpenExercise] = useState(false);
  const [idExercise, setIdExercise] = useState(null);
  const handleIdExercise = (item) => {
    console.log(item)
    setIdExercise(item);
    setDialogOpenExercise(true);
  };
  const handleCloseExercise = () => {
    setIdExercise(null);
    setDialogOpenExercise(false);
  };
  const handledeleteExercise = async () => {
    try {
      const params = new URLSearchParams([['idExercise', idExercise], ['idMember', UserHost.idMember], ['idClassroom', classData.idClassroom]]);
      const result = await classApi.deleteexercise(params);
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
  }
  return (
    <div>
      {isUserHost && <div>
        <Button
          type="submit"
          variant="contained"
          className='btn_create'
          style={{ marginLeft: 400, marginTop: 20, borderRadius: 20, backgroundColor: "rgb(25, 118, 210)", color: "#fff" }}
        >
          <a href={`/${classData.idClassroom}/exercises/create`} style={{ color: "#fff", textDecoration: 'none' }}>
            + Tạo bài tập
          </a>
        </Button>
        <div className='exercise_status'>
          <h1>Còn hạn</h1>
        </div>
        <ul className='list_tasks'>
          {exercisesActive.map((item, index) => (
            <li key={index} className='task'>
              <a href={`/${classData.idClassroom}/exercises/${item.idExercise}`}>
                <Avatar style={{ m: 1, backgroundColor: 'rgb(4, 214, 46)' }}>
                  <LibraryBooksOutlinedIcon />
                </Avatar>
              </a>
              <div className='task_information'>
                <div className='task_name'>{item.name}</div>
                <div className='task_deadline'>thời hạn: {formatDate(item.deadline)} </div>
                <Button variant="contained" onClick={() => handleIdExercise(item.idExercise)} color="secondary" startIcon={<ExitToAppOutlined />}>
                  xóa
                </Button>
              </div>
            </li>
          ))}
        </ul>
        <div className='exercise_status'>
          <h1>Hết hạn</h1>
        </div>
        <ul className='list_tasks'>
          {exercisesExpired.map((item, index) => (
            <li key={index} className='task'>
              <a href={`/${classData.idClassroom}/exercises/${item.idExercise}`}>
                <Avatar style={{ m: 1, backgroundColor: 'rgb(233, 0, 0)' }}>
                  <LibraryBooksOutlinedIcon />
                </Avatar>
              </a>
              <div className='task_information'>
                <div className='task_name'>{item.name}</div>
                <div className='task_deadline'>{formatDate(item.deadline)} </div>
                <Button variant="contained" onClick={() => handleIdExercise(item.idExercise)} color="secondary" startIcon={<ExitToAppOutlined />}>
                  xóa
                </Button>
              </div>
            </li>
          ))}
        </ul>
      </div>}
      {isUserMember && <div>

        <div className='exercise_status'>
          <h1 style={{ paddingTop: 12 }}>Đã giao</h1>
        </div>
        <ul className='list_tasks'>
          {exercisesAssigned.map((item, index) => (
            <li key={index} className='task'>
              <a href={`/${classData.idClassroom}/exercises/${item.idExercise}/answer`}>
                <Avatar style={{ margin: 1, backgroundColor: 'rgb(0, 159, 212)' }}>
                  <LibraryBooksOutlinedIcon />
                </Avatar>
              </a>
              <div className='task_information'>
                <div className='task_name'>{item.name}</div>
                <div className='task_deadline'>{formatDate(item.deadline)} </div>
              </div>
            </li>
          ))}
        </ul>
        <div className='exercise_status'>
          <h1 style={{ paddingTop: 12 }}>Đã hoàn thành</h1>
        </div>
        <ul className='list_tasks'>
          {exercisesCompleted.map((item, index) => (
            <li key={index} className='task'>
              <a href={`/${classData.idClassroom}/exercises/${item.idExercise}/answer`}>
                <Avatar style={{ m: 1, backgroundColor: 'rgb(4, 214, 46)' }}>
                  <LibraryBooksOutlinedIcon />
                </Avatar>
              </a>
              <div className='task_information'>
                <div className='task_name'>{item.name}</div>
                <div className='task_deadline'>{formatDate(item.deadline)} </div>
              </div>
            </li>
          ))}
        </ul>
        <div className='exercise_status'>
          <h1 style={{ paddingTop: 12 }}>Chưa hoàn thành</h1>
        </div>
        <ul className='list_tasks'>
          {exercisesNotCompleted.map((item, index) => (
            <li key={index} className='task'>
              <a href={`/${classData.idClassroom}/exercises/${item.idExercise}/answer`}>
                <Avatar style={{ m: 1, backgroundColor: 'rgb(233, 0, 0)' }}>
                  <LibraryBooksOutlinedIcon />
                </Avatar>
              </a>
              <div className='task_information'>
                <div className='task_name'>{item.name}</div>
                <div className='task_deadline'>{formatDate(item.deadline)} </div>
              </div>
            </li>
          ))}
        </ul>
      </div>}
      <ConfirmationDialog
        open={dialogOpenExercise}
        onClose={handleCloseExercise}
        onConfirm={handledeleteExercise}
        message="Bạn có chắc muốn xóa bài tập này không?"
      />
    </div>

  )
}

export default Exercises;
