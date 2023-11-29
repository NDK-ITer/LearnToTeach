
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
          {isUserHost && <FormNotify onSubmit={handleSubmit} />}
        </div>
        <div>
          <ul>
            {notify.map((item, index) => (
              <li key={index}>
                <Avatar></Avatar>
                {userHost.map((item, index) => (
                  <p key={index}>{item.nameMember}</p>
                ))}
                <p>{item.nameNotify}</p>
                <p>{item.description}</p>
              </li>
            ))}

          </ul>
        </div>
      </div>
    </div>
  );
};

export default Main;

