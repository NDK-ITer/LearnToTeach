import React, { useState, useEffect } from 'react';
import "./style.css";
import { Avatar } from '@material-ui/core';
import PermIdentityOutlinedIcon from '@material-ui/icons/PermIdentityOutlined';
import PermContactCalendarOutlinedIcon from '@material-ui/icons/PermContactCalendarOutlined';
import classApi from 'api/classApi';
import Role from 'constants/role';
import { Redirect, Route, Switch, useRouteMatch } from 'react-router-dom';
import SubmitExercise from 'components/Exercises/SubmitExercise/SubmitExercise';

const GradeDetail = ({ exercise, classData, userHost }) => {
    const match = useRouteMatch();
    const userGraded = exercise.listAnswer.filter(x => x.point != null);
    const userNotGraded = exercise.listAnswer.filter(x => x.point == null);
    // const countUser = classData.listMembers.filter(x=>x.role==Role.MEMBER).length;
    const listUserAnswer = exercise.listAnswer;

    return (
        <div>
            <div className='role'>
                <h1>Sinh viên đã chấm</h1>
                <div className='quantity'>({userGraded.length}) sinh viên</div>
            </div>
            <ul className='list_informations'>
                {userGraded.map((item, index) => (
                    <li key={index} className='information'>
                        <a href={`${match.url}/answer/${item.idMember}`}>
                            <Avatar style={{ m: 1, backgroundColor: 'rgb(204, 204, 55)', color: 'black' }}>
                                <PermContactCalendarOutlinedIcon />
                            </Avatar>
                        </a>
                        <div className='name'>{classData.listMembers.find(x => x.idMember == item.idMember).nameMember}</div>
                    </li>
                ))}

            </ul>
            <div className='role'>
                <h1>Sinh viên chưa chấm</h1>
                <div className='quantity'>({userNotGraded.length}) sinh viên</div>
            </div>
            <ul className='list_informations'>
                {userNotGraded.map((item, index) => (
                    <li key={index} className='submit_student_information'>
                        <a href={`${match.url}/${item.idMember}`}>
                            <Avatar style={{ m: 1, backgroundColor: 'rgb(219, 127, 52)', color: 'black' }}>
                                <PermIdentityOutlinedIcon />
                            </Avatar>
                        </a>
                        <div className='submit_information'>
                            <div className='name'>{classData.listMembers.find(x => x.idMember == item.idMember).nameMember}</div>
                            <div>Thời gian nộp</div>
                        </div>

                    </li>
                ))}

            </ul>

        </div>
    )
}

export default GradeDetail
