import React, { useState, useEffect } from 'react'
import { Avatar } from '@material-ui/core';
import "./style.css";
import CancelOutlinedIcon from '@material-ui/icons/CancelOutlined';
import CheckCircleOutlinedIcon from '@material-ui/icons/CheckCircleOutline';
import ErrorOutlineOutlinedIcon from '@material-ui/icons/ErrorOutlineOutlined';
import { useLocalContext } from 'context';
import classApi from 'api/classApi';
import Role from 'constants/role';
import formatDate from 'constants/formatdate';
import { Link } from 'react-router-dom';
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
        const exercisesWithNullOrNotNullPoint = result.listExercises.filter(exercise => {
          return (exercise.listAnswer.some(answer => answer.point === null) || exercise.listAnswer.some(answer => answer.point !== null)) && exercise.listAnswer.filter(x => x.point !== null).length > 0 && (exercise.listAnswer.filter(x => x.point !== null).length < exercise.listAnswer.length || (exercise.listAnswer.filter(x => x.point !== null).length == exercise.listAnswer.length && new Date(exercise.deadline) > currentDate))
        }).sort((a, b) => new Date(a.deadline) - new Date(b.deadline));

        const exercisesWithNullPoint = result.listExercises.filter(exercise => {
          return exercise.listAnswer.every(answer => answer.point === null) && new Date(exercise.deadline) > currentDate;
        }).sort((a, b) => new Date(a.deadline) - new Date(b.deadline));

        const exercisesWithNotNullPoint = result.listExercises.filter(exercise => {
          return exercise.listAnswer.length > 0 && exercise.listAnswer.every(answer => answer.point !== null);
        }).sort((a, b) => new Date(a.deadline) - new Date(b.deadline));
        setexercisesGrading(exercisesWithNullOrNotNullPoint)
        setexercisesGrade(exercisesWithNotNullPoint.filter(x => new Date(x.deadline) < currentDate))
        setexercisesNotGrade(exercisesWithNullPoint)
        setcountUser(result.listMembers.filter(x => x.role == Role.MEMBER).length)
      } else {
        setexercisesGrade(result.listExercises.filter(x => x.listAnswer.filter(c => c.idMember == user.id && c.point != null).length > 0).sort((a, b) => new Date(a.deadline) - new Date(b.deadline)));
        setexercisesNotGrade(result.listExercises.filter(x => x.listAnswer.filter(c => c.idMember == user.id && c.point == null).length > 0).sort((a, b) => new Date(a.deadline) - new Date(b.deadline)));
        setexercisesGradeExpired(result.listExercises.filter(x => new Date(x.deadline) < currentDate && x.listAnswer.filter(c => c.idMember == user.id).length <= 0).sort((a, b) => new Date(a.deadline) - new Date(b.deadline)));

      }
    };
    fetchData();
  }, []);
  console.log(exercisesGrade.filter(x => new Date(x.deadline) < currentDate))
  return (
    <div>
      {isUserHost && <div>
        <div className='status'>
          <h1>Chưa chấm</h1>
        </div>
        <ul className='list_results'>
          {exercisesNotGrade.map((item, index) => (
            <li key={index} className='result'>
              <Link to={`/${classData.idClassroom}/grades/${item.idExercise}`}>
                <Avatar style={{ m: 1, backgroundColor: 'rgb(227, 227, 0)' }}>
                  <ErrorOutlineOutlinedIcon />
                </Avatar>
              </Link>
              <div className='grade_information'>
                <div className='name_1'>{item.name}</div>
                <div>
                  <div className='grade'>Thời hạn {formatDate(item.deadline)}</div>
                  <div className='grade'> đã chấm {item.listAnswer.filter(c => c.point !== null).length}/đã nộp {item.listAnswer.length}/tổng số {countuser} sinh viên</div>
                </div>
              </div>
            </li>
          ))}
        </ul>
        {exercisesNotGrade.length == 0 &&
          <div>
            <p style={{ textAlign: 'center', fontSize: '18px' }}> Chưa có bài tập</p>
          </div>}
        <div className='status'>
          <h1>Đang chấm</h1>
        </div>
        <ul className='list_results'>
          {exercisesGrading.map((item, index) => (
            <li key={index} className='result'>
              <Link to={`/${classData.idClassroom}/grades/${item.idExercise}`}>
                <Avatar style={{ m: 1, backgroundColor: 'rgb(227, 227, 0)' }}>
                  <ErrorOutlineOutlinedIcon />
                </Avatar>
              </Link>
              <div className='grade_information'>
                <div className='name_1'>{item.name}</div>
                <div>
                  <div className='grade'>Thời hạn {formatDate(item.deadline)}</div>
                  <div className='grade'> đã chấm {item.listAnswer.filter(c => c.point !== null).length}/đã nộp {item.listAnswer.length}/tổng số {countuser} sinh viên</div>
                </div>
              </div>
            </li>
          ))}
        </ul>
        {exercisesGrading.length == 0 &&
          <div>
            <p style={{ textAlign: 'center', fontSize: '18px' }}> Chưa có bài tập</p>
          </div>}
        <div className='status'>
          <h1>Đã chấm xong</h1>
        </div>
        <ul className='list_results'>
          {exercisesGrade.map((item, index) => (
            <li key={index} className='result'>
              <Link to={`/${classData.idClassroom}/grades/${item.idExercise}`}>
                <Avatar style={{ m: 1, backgroundColor: 'rgb(4, 214, 46)' }}>
                  <CheckCircleOutlinedIcon />
                </Avatar>
              </Link>
              <div className='grade_information'>
                <div className='name_1'>{item.name}</div>
                <div>
                  <div className='grade'>Thời hạn {formatDate(item.deadline)}</div>
                  <div className='grade'> đã chấm {item.listAnswer.filter(c => c.point !== null).length}/đã nộp {item.listAnswer.length}/tổng số {countuser} sinh viên</div>
                </div>
              </div>

            </li>
          ))}
        </ul>
        {exercisesGrade.length == 0 &&
          <div>
            <p style={{ textAlign: 'center', fontSize: '18px' }}> Chưa có bài tập</p>
          </div>}
      </div>}
      {isUserMember && <div>
        <div className='status'>
          <h1>Đã chấm</h1>
        </div>
        <ul className='list_results'>
          {exercisesGrade.map((item, index) => (
            <li key={index} className='result'>
              <Link to={`/${classData.idClassroom}/exercises/${item.idExercise}/answer`}>
                <Avatar style={{ m: 1, backgroundColor: 'rgb(4, 214, 46)' }}>
                  <CheckCircleOutlinedIcon />
                </Avatar>
              </Link>
              <div className='grade_information'>
                <div className='name_1'>{item.name}</div>
                <div>
                  {item.listAnswer.find(x => x.idMember == user.id).dateUpdatePoint == null &&
                    <div className='grade'>Thời gian chấm {formatDate(item.listAnswer.find(x => x.idMember == user.id).dateSetPoint)}</div>
                  }
                  {item.listAnswer.find(x => x.idMember == user.id).dateUpdatePoint != null &&
                    <div className='grade'>Thời gian chấm lại {formatDate(item.listAnswer.find(x => x.idMember == user.id).dateUpdatePoint)}</div>
                  }

                  <div className='grade'>Điểm số: {item.listAnswer.find(x => x.idMember == user.id).point}</div>
                </div>
              </div>
            </li>
          ))}

        </ul>
        {exercisesGrade.length == 0 &&
          <div>
            <p style={{ textAlign: 'center', fontSize: '18px' }}> Chưa có bài tập</p>
          </div>}
        <div className='status'>
          <h1>Chưa chấm</h1>
        </div>
        <ul className='list_results'>
          {exercisesNotGrade.map((item, index) => (
            <li key={index} className='result'>
              <Link to={`/${classData.idClassroom}/exercises/${item.idExercise}/answer`}>
                <Avatar style={{ m: 1, backgroundColor: 'rgb (255,255,0)' }}>
                  <CheckCircleOutlinedIcon />
                </Avatar>
              </Link>
              <div className='grade_information'>
                <div className='name'> {item.name} </div>
                <div className='grade'>Đang chờ chấm</div>
              </div>
            </li>
          ))}

        </ul>
        {exercisesNotGrade.length == 0 &&
          <div>
            <p style={{ textAlign: 'center', fontSize: '18px' }}> Chưa có bài tập</p>
          </div>}
        <div className='status'>
          <h1>Hết hạn</h1>
        </div>
        <ul className='list_results'>

          {exercisesGradeExpired.map((item, index) => (
            <li key={index} className='result'>
              <Link to={`/${classData.idClassroom}/exercises/${item.idExercise}/answer`}>
                <Avatar style={{ m: 1, backgroundColor: 'rgb(233, 0, 0)' }}>
                  <CancelOutlinedIcon />
                </Avatar>
              </Link>
              <div className='grade_information'>
                <div className='name'>{item.name}</div>
                <div className='grade'>Điểm số: 0 </div>
              </div>
            </li>
          ))}
        </ul>
        {exercisesGradeExpired.length == 0 &&
          <div>
            <p style={{ textAlign: 'center', fontSize: '18px' }}> Chưa có bài tập</p>
          </div>}
      </div>}
    </div>

  )
}

export default Grade
