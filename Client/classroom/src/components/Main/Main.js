
import React, { useState, useEffect } from "react";
import "./style.css";
import { useLocalContext } from "context";
import { unwrapResult } from '@reduxjs/toolkit';
import { useSnackbar } from 'notistack';
import { useDispatch } from 'react-redux';
import { useHistory } from 'react-router-dom';
import FormNotify from "./FormNotify";
import { deleteclassroom, leaveclassroom, uploadnotify } from "components/classroom/classSilce";
import { Avatar } from "@material-ui/core";
import Role from "constants/role";
import classApi from "api/classApi";
import { Button } from '@material-ui/core';
import ExitToAppOutlinedIcon from '@material-ui/icons/ExitToAppOutlined';
import ConfirmationDialog from "components/ConfirmationDialog";
import formatDate from "constants/formatdate";
const Main = ({ classData }) => {
  const { user } = useLocalContext();
  const history = useHistory();
  const dispatch = useDispatch();
  const { enqueueSnackbar } = useSnackbar();
  const [isUserHost, setisUserHost] = useState(false);
  const [isClassPrivate, setisClassPrivate] = useState(false);
  const [userHost, setuserHost] = useState([]);
  const [isUserMember, setisUserMember] = useState(false);
  const [notify, setnotify] = useState([]);
  const [listExercisesUserhost, setListExerciceUserhost] = useState([]);
  const [listExercisesUserMember, setListExerciceUserMember] = useState([]);
  const currentDate = new Date();
  useEffect(() => {
    const fetchData = async () => {
      const params = new URLSearchParams([['idClassroom', classData.idClassroom]]);
      const result = await classApi.getClassById(params);
      setisUserHost(result.listMembers.filter(x => x.role == Role.HOST && user.id == x.idMember).length > 0 ? true : false);
      setuserHost(result.listMembers.find(x => x.role == Role.HOST));
      setisClassPrivate(result.key)
      setisUserMember(result.listMembers.filter(x => x.role == Role.MEMBER && user.id == x.idMember).length > 0 ? true : false);
      setnotify(result.listNotify.sort((a, b) => new Date(b.createDate) - new Date(a.createDate)));
      setListExerciceUserhost(result.listExercises.filter(x => (x.listAnswer.filter(c => c.point != null).length < x.listAnswer.length || x.listAnswer.filter(c => c.point != null).length == 0) && new Date(x.deadline) >= currentDate).sort((a, b) => new Date(a.deadline) - new Date(b.deadline)).slice(0, 5));
      setListExerciceUserMember(result.listExercises.filter(x => (x.listAnswer.filter(c => c.idMember == user.id).length >= 0) && new Date(x.deadline) >= currentDate).sort((a, b) => new Date(a.deadline) - new Date(b.deadline)).slice(0, 5))
    };
    fetchData();
  }, []);
  const handleSubmit = async (values) => {
    try {
      values.IdClassroom = classData.idClassroom;
      values.IdMember = user.id;
      const action = uploadnotify(values);
      const resultAction = await dispatch(action);
      unwrapResult(resultAction);
      const check = resultAction.payload
      console.log(resultAction.payload)
      if (check.status == 1) {
        enqueueSnackbar(check.message, { variant: 'success' });
        window.location.reload(true);
      } else {
        enqueueSnackbar(check.message, { variant: 'error' });
      }

    } catch (error) {
      console.log('Failed to login:', error);
      enqueueSnackbar(error.message, { variant: 'error' });
    }
  };
  const [dialogOpenDeletelassroom, setDialogOpenDeletelassroom] = useState(false);
  const [dialogOpenLeaveClassroom, setDialogOpenLeaveClassroom] = useState(false);
  const [dialogOpenNotify, setDialogOpenNotify] = useState(false);
  const [idNotify, setIdNotify] = useState(null);
  const OpenDeletelassroom = () => {
    setDialogOpenDeletelassroom(true);
  };
  const handleCloseDeletelassroom = () => {
    setDialogOpenDeletelassroom(false);
  };
  const OpenLeaveClassroom = () => {
    setDialogOpenLeaveClassroom(true);
  };

  const handleCloseLeaveClassroom = () => {
    setDialogOpenLeaveClassroom(false);
  };

  const handledeleteclassroom = async () => {
    try {
      const params = new URLSearchParams([['idClassroom', classData.idClassroom]]);
      const result = await classApi.deleteclassroom(params);
      console.log(result)
      if (result.status == 1) {
        enqueueSnackbar(result.message, { variant: 'success' });
        history.push('/');
        window.location.reload();
      } else {
        enqueueSnackbar(result.message, { variant: 'error' });
      }

    } catch (error) {
      console.log('Failed to login:', error);
      enqueueSnackbar(error.message, { variant: 'error' });
    }
  };
  const handleLeaveClassroom = async () => {
    try {
      const formData = new FormData()
      formData.append('idClassroom', classData.idClassroom);
      formData.append('idMember', user.id);
      const result = await classApi.leaveclassroom(formData);
      if (result.status == 1) {
        enqueueSnackbar(result.message, { variant: 'success' });
        history.push('/');
        window.location.reload();
      } else {
        enqueueSnackbar(result.message, { variant: 'error' });
      }

    } catch (error) {
      console.log('Failed to login:', error);
      enqueueSnackbar(error.message, { variant: 'error' });
    }

  }
  const handleIdNotify = (item) => {
    setIdNotify(item);
    setDialogOpenNotify(true);
  };
  const handleCloseNotify = () => {
    setIdNotify(null);
    setDialogOpenNotify(false);
  };
  const handledeleteNotify = async () => {
    try {
      const formData = new FormData()
      formData.append('idClassroom', classData.idClassroom);
      formData.append('idMember', userHost.idMember);
      formData.append('IdNotify', idNotify);
      const result = await classApi.deletenotify(formData);
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
    <div className="main">
      <div className="main__wrapper">
        <div className="main__content">
          <div className="main__wrapper1">
            <div className="main__bgImage">
              <div className="main__emptyStyles" />
            </div>
            <div className="main__text">
              <h1 className="main__heading main__overflow">
                {classData.name}
              </h1>
              <div className="main__section main__overflow">
                {classData.description}
              </div>
              <div className="main__wrapper2">
                <em className="main__code">Mã lớp học :</em>
                <div className="main__id">{classData.idClassroom}</div>
                {isUserHost &&
                  <div>
                    <em className="main__code">Mã khóa lớp học :</em>
                    <div className="main__id">{isClassPrivate}</div>
                  </div>
                }

              </div>
            </div>
          </div>
        </div>
        <div className="main__announce">
          <div className="main__status">
            <p>Sắp đến hạn</p>
            <div className="main__subText">
              {isUserHost &&
                <ul className='list_notifies'>
                  {listExercisesUserhost.map((item, index) => (
                    <li key={index}>
                      <a href={`/${classData.idClassroom}/exercises/${item.idExercise}`}>{item.name}</a>
                    </li>
                  ))}
                  {listExercisesUserhost.length <= 0 && <span>không có bài tập nào</span>}
                </ul>
              }
              {!isUserHost &&
                <ul className='list_notifies'>
                  {listExercisesUserMember.map((item, index) => (
                    <li key={index}>
                      <a href={`/${classData.idClassroom}/exercises/${item.idExercise}/answer`}>{item.name}</a>
                    </li>
                  ))}
                  {listExercisesUserMember.length <= 0 && <span>không có bài tập nào</span>}
                </ul>}

            </div>
          </div>
          <div className="main_announcements_and_notifies">
            {isUserHost && <FormNotify onSubmit={handleSubmit} />}
            <ul className='list_notifies'>
              {notify.map((item, index) => (
                <li className="notify" key={index}>
                  <div className="post_information">
                    <Avatar></Avatar>
                    <div className="posted_by">
                      <div className="author" key={index}>{userHost.nameMember}</div>
                      <div className="post_time">Thời gian : {formatDate(item.createDate)}</div>
                    </div>
                  </div>
                  <div>
                    <p>{item.nameNotify}</p>
                    <p>{item.description}</p>
                    {isUserHost && <Button variant="contained" onClick={() => handleIdNotify(item.idNotify)} color="secondary" startIcon={<ExitToAppOutlinedIcon />}>
                      xóa thông báo
                    </Button>}
                  </div>

                </li>
              ))}
              {isUserHost && <Button variant="contained" onClick={OpenDeletelassroom} color="secondary" startIcon={<ExitToAppOutlinedIcon />} style={{ marginBottom: '20px' }}>
                xóa lớp
              </Button>}
              {isUserMember && <Button variant="contained" onClick={OpenLeaveClassroom} color="secondary" startIcon={<ExitToAppOutlinedIcon />} style={{ marginBottom: '20px' }}>
                rời khỏi lớp
              </Button>}
            </ul>
            <ConfirmationDialog
              open={dialogOpenDeletelassroom}
              onClose={handleCloseDeletelassroom}
              onConfirm={handledeleteclassroom}
              message="Are you sure you want to delete classroom?"
            />
            <ConfirmationDialog
              open={dialogOpenLeaveClassroom}
              onClose={handleCloseLeaveClassroom}
              onConfirm={handleLeaveClassroom}
              message="Are you sure you want to Leave classroom?"
            />
            <ConfirmationDialog
              open={dialogOpenNotify}
              onClose={handleCloseNotify}
              onConfirm={handledeleteNotify}
              message="Are you sure you want to Notify?"
            />
          </div>
        </div>
      </div>
    </div>
  );
};

export default Main;

