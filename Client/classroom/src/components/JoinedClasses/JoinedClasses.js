import { Avatar } from "@material-ui/core";
import { FolderOpen, PermContactCalendar } from "@material-ui/icons";
import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import "./style.css";
import classApi from "api/classApi";
import Role from "constants/role";
import userApi from "api/userApi";
const JoinedClasses = ({ classData }) => {
  const [userHost, settuserHost] = useState([]);
  const [userInfor, setUserInfor] = useState('');
  useEffect(() => {
    const fetchData = async () => {
      const params = new URLSearchParams([['idClassroom', classData.idClassroom]]);
      const result = await classApi.getClassById(params);
      settuserHost(result.listMembers.find(x => x.role == Role.HOST));
      console.log(result.listMembers.find(x => x.role == Role.HOST))

      const formData = new FormData()
      formData.append('idUser', result.listMembers.find(x => x.role == Role.HOST).idMember);
      const user = await userApi.getclassroom(formData);
      setUserInfor(user);

    };
    fetchData();
  }, []);
  return (
    <li className="joined__list">
      <div className="joined__wrapper">
        <div className="joined__container">
          <div className="joined__imgWrapper" />
          <div className="joined__image" />
          <div className="joined__content">
            <Link className="joined__title" to={`/${classData.idClassroom}`}>
              <h2>{classData.name}</h2>
            </Link>
            <p className="joined__owner">{userHost.nameMember}</p>
          </div>
        </div>
        <Avatar
          className="joined__avatar"
          src={userInfor.avatar != null ? userInfor.avatar : "https://lh3.googleusercontent.com/-XdUIqdMkCWA/AAAAAAAAAAI/AAAAAAAAAAA/4252rscbv5M/s75-c-fbw=1/photo.jpg"}
        />
      </div>
      <div className="joined__bottom">
        <PermContactCalendar />
        <FolderOpen />
      </div>
    </li>
  );
};

export default JoinedClasses;
