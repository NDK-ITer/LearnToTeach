import React, { useState, useEffect } from 'react'
import { Avatar } from '@material-ui/core';
import "./style.css";
import CancelOutlinedIcon from '@material-ui/icons/CancelOutlined';
import CheckCircleOutlinedIcon from '@material-ui/icons/CheckCircleOutline';
import { useLocalContext } from 'context';
import classApi from 'api/classApi';
import Role from 'constants/role';
const Grade = ({ classData }) => {
  const { user } = useLocalContext();
  const [isUserHost, setisUserHost] = useState(false);
  const [isUserMember, setisUserMember] = useState(false);
  const [exercisesGradeExpired, setexercisesGradeExpired] = useState([]);
  const [exercisesGrade, setexercisesGrade] = useState([]);
  const [exercisesNotGrade, setexercisesNotGrade] = useState([]);
  const [countuser, setcountUser] = useState([]);
  const [exercisesGrading, setexercisesGrading] = useState([]);
  const currentDate = new Date();
  useEffect(() => {
    const fetchData = async () => {
      const params = new URLSearchParams([['idClassroom', classData.idClassroom]]);
      const result = await classApi.getClassById(params);
      setisUserHost(result.listMembers.filter(x => x.role == Role.HOST && user.id == x.idMember).length > 0 ? true : false);
      setisUserMember(result.listMembers.filter(x => x.role == Role.MEMBER && user.id == x.idMember).length > 0 ? true : false);
      let isUserHost = result.listMembers.filter(x => x.role == Role.HOST && user.id == x.idMember).length > 0 ? true : false
      if (isUserHost) {
        const exercisesWithNullPoint = result.listExercises.filter(exercise => {
          return exercise.listAnswer.some(answer => answer.point === null);
        }).sort((a, b) => new Date(b.deadline) - new Date(a.deadline));
        const exercisesWithNotNullPoint = result.listExercises.filter(exercise => {
          return exercise.listAnswer.length > 0 && exercise.listAnswer.every(answer => answer.point !== null);
        }).sort((a, b) => new Date(b.deadline) - new Date(a.deadline));
        setexercisesGrading(exercisesWithNullPoint)
        setexercisesGrade(exercisesWithNotNullPoint)
        setcountUser(result.listMembers.filter(x => x.role == Role.MEMBER).length)
      } else {
        setexercisesGrade(result.listExercises.filter(x => x.listAnswer.filter(c => c.idMember == user.id && c.point != null).length > 0).sort((a, b) => new Date(b.deadline) - new Date(a.deadline)));
        setexercisesNotGrade(result.listExercises.filter(x => x.listAnswer.filter(c => c.idMember == user.id && c.point == null).length > 0).sort((a, b) => new Date(b.deadline) - new Date(a.deadline)));
        setexercisesGradeExpired(result.listExercises.filter(x => new Date(x.deadline) < currentDate && x.listAnswer.filter(c => c.idMember == user.id).length <= 0).sort((a, b) => new Date(b.deadline) - new Date(a.deadline)));

      }
    };
    fetchData();
  }, []);
  return (
    <div>
      {isUserHost && <div>
        <div className='status'>
          <h1>Đang chấm</h1>
        </div>
        <ul className='list_results'>
          {exercisesGrading.map((item, index) => (
            <li key={index} className='result'>
              <a href={`/${classData.idClassroom}/grades/${item.idExercise}`}>
                <Avatar style={{ m: 1, backgroundColor: 'rgb(4, 214, 46)' }}>
                  <CheckCircleOutlinedIcon />
                </Avatar>
              </a>
              <div className='name'>{item.name}</div>
              <div className='grade'> đã chấm {item.listAnswer.filter(c => c.point !== null).length}/đã nộp {item.listAnswer.length}/sinh viên {countuser}</div>
            </li>
          ))}
        </ul>
        <div className='status'>
          <h1>Đã chấm xong</h1>
        </div>
        <ul className='list_results'>
          {exercisesGrade.map((item, index) => (
            <li key={index} className='result'>
              <a href={`/${classData.idClassroom}/grades/${item.idExercise}`}>
                <Avatar style={{ m: 1, backgroundColor: 'rgb(4, 214, 46)' }}>
                  <CheckCircleOutlinedIcon />
                </Avatar>
              </a>
              <div className='name'>{item.name}</div>
              <div className='grade'> đã chấm {item.listAnswer.filter(c => c.point !== null).length}/đã nộp {item.listAnswer.length}/sinh viên {countuser}</div>

            </li>
          ))}
        </ul>
      </div>}
      {isUserMember && <div>
        <div className='status'>
          <h1>Đã chấm</h1>
        </div>
        <ul className='list_results'>
          {exercisesGrade.map((item, index) => (
            <li key={index} className='result'>
              <a href={`/${classData.idClassroom}/exercises/${item.idExercise}/answer`}>
                <Avatar style={{ m: 1, backgroundColor: 'rgb(4, 214, 46)' }}>
                  <CheckCircleOutlinedIcon />
                </Avatar>
              </a>
              <div className='name'>{item.name}</div>
              <div className='grade'>Điểm số:{item.listAnswer.find(x => x.idMember == user.id).point} </div>
            </li>
          ))}

        </ul>
        <div className='status'>
          <h1>Chưa chấm</h1>
        </div>
        <ul className='list_results'>
          {exercisesNotGrade.map((item, index) => (
            <li key={index} className='result'>
              <a href={`/${classData.idClassroom}/exercises/${item.idExercise}/answer`}>
                <Avatar style={{ m: 1, backgroundColor: 'rgb (255,255,0)' }}>
                  <CheckCircleOutlinedIcon />
                </Avatar>
              </a>
              <div className='name'> {item.name} </div>
              <div className='grade'>Đang chờ chấm</div>
            </li>
          ))}

        </ul>
        <div className='status'>
          <h1>Hết hạn</h1>
        </div>
        <ul className='list_results'>

          {exercisesGradeExpired.map((item, index) => (
            <li key={index} className='result'>
              <a href={`/${classData.idClassroom}/exercises/${item.idExercise}/answer`}>
                <Avatar style={{ m: 1, backgroundColor: 'rgb(233, 0, 0)' }}>
                  <CancelOutlinedIcon />
                </Avatar>
              </a>
              <div className='name'>{item.name}</div>
              <div className='grade'>Điểm số: 0 </div>
            </li>
          ))}
        </ul>
      </div>}
    </div>

  )
}

export default Grade
