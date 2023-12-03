
import React, { useState, useEffect } from "react";
import "./style.css";
import { useLocalContext } from "context";
import { unwrapResult } from '@reduxjs/toolkit';
import { useSnackbar } from 'notistack';
import { useDispatch } from 'react-redux';
import { useHistory } from 'react-router-dom';
import FormNotify from "./FormNotify";
import { uploadnotify } from "components/classroom/classSilce";
import { Avatar } from "@material-ui/core";
import Role from "constants/role";
import classApi from "api/classApi";
import { Button } from '@material-ui/core';
import ExitToAppOutlinedIcon from '@material-ui/icons/ExitToAppOutlined';
import ConfirmationDialog from "components/ConfirmationDialog";

const Main = ({ classData }) => {
  const { user } = useLocalContext();
  const dispatch = useDispatch();
  const { enqueueSnackbar } = useSnackbar();
  const [isUserHost, setisUserHost] = useState(false);
  const [userHost, setuserHost] = useState([]);
  const [isUserMember, setisUserMember] = useState(false);
  const [notify, setnotify] = useState([]);
  useEffect(() => {
    const fetchData = async () => {
      const params = new URLSearchParams([['idClassroom', classData.idClassroom]]);
      const result = await classApi.getClassById(params);
      setisUserHost(result.listMembers.filter(x => x.role == Role.HOST && user.id == x.idMember).length > 0 ? true : false);
      setuserHost(result.listMembers.filter(x => x.role == Role.HOST));
      setisUserMember(result.listMembers.filter(x => x.role == Role.MEMBER && user.id == x.idMember).length > 0 ? true : false);
      setnotify(result.listNotify.sort((a, b) => new Date(b.createDate) - new Date(a.createDate)));
    };
    fetchData();
  }, []);
  console.log(userHost)
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
  const [dialogOpen, setDialogOpen] = useState(false);

  const handleOpen = () => {
    setDialogOpen(true);
  };

  const handleClose = () => {
    setDialogOpen(false);
  };

  const handleConfirmation = () => {
    // Perform action on confirmation
    console.log('Confirmed!');
    // Add your custom logic here for "Yes" button click
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
              </div>
            </div>
          </div>
        </div>
        <div className="main__announce">
          <div className="main__status">
            <p>Sắp đến hạn</p>
            <p className="main__subText">Không có công việc</p>
          </div>
          <div className="main_announcements_and_notifies">
            {isUserHost && <FormNotify onSubmit={handleSubmit} />}
            <ul className='list_notifies'>
              {notify.map((item, index) => (
                <li className="notify" key={index}>
                  <div className="post_information">
                    <Avatar></Avatar>
                    <div className="posted_by">
                      {userHost.map((item, index) => (
                        <div className="author" key={index}>{item.nameMember}</div>
                      ))}
                      <div className="post_time">Thời gian đăng</div>
                    </div>
                  </div>
                  <div>
                    <p>{item.nameNotify}</p>
                    <p>{item.description}</p>
                  </div>

                </li>
              ))}
              <Button variant="contained" onClick={handleOpen} color="secondary" startIcon={<ExitToAppOutlinedIcon />} style={{ marginBottom: '20px' }}>
                Rời khỏi lớp
              </Button>
            </ul>
            <ConfirmationDialog
              open={dialogOpen}
              onClose={handleClose}
              onConfirm={handleConfirmation}
              message="Are you sure you want to proceed?"
            />
          </div>
        </div>
      </div>
    </div>
  );
};

export default Main;

