import React, { useState, useEffect } from 'react';
import "./style.css";
import { Avatar } from '@material-ui/core';
import PermIdentityOutlinedIcon from '@material-ui/icons/PermIdentityOutlined';
import PermContactCalendarOutlinedIcon from '@material-ui/icons/PermContactCalendarOutlined';
import classApi from 'api/classApi';
import Role from 'constants/role';
import { Redirect, Route, Switch, useRouteMatch } from 'react-router-dom';
import SubmitExercise from 'components/Exercises/SubmitExercise/SubmitExercise';
import GoBackButton from 'components/GoBackButton';

const GradeDetail = ({ exercise, classData, userHost }) => {
    const match = useRouteMatch();
    const userGraded = exercise.listAnswer.filter(x => x.point != null);
    const userNotGraded = exercise.listAnswer.filter(x => x.point == null);
    // const countUser = classData.listMembers.filter(x=>x.role==Role.MEMBER).length;
    const listUserAnswer = exercise.listAnswer;
    const isexerciseGraded = userGraded.length == listUserAnswer.length ? true : false;
    return (
        <div>
            {isexerciseGraded && <div>
                <div className='role'>
                    <h1>Bảng điểm</h1>
                    <div className='quantity'>({userGraded.length}) sinh viên</div>
                </div>
                <ul className='list_informations'>
                    {userGraded.map((item, index) => (
                        <li key={index} className='graded_information'>
                            <a href={`${match.url}/answer/${item.idMember}`}>
                                <Avatar style={{ m: 1, backgroundColor: 'rgb(4, 214, 46)' }}>
                                    <PermContactCalendarOutlinedIcon />
                                </Avatar>
                            </a>
                            <div className='submit_information'>
                                <div className='name'>{classData.listMembers.find(x => x.idMember == item.idMember).nameMember}</div>
                                <div className='grade'>Điểm số: {item.point} </div>
                            </div>
                        </li>
                    ))}

                </ul>
                <div style={{margin: '0px 1050px'}}>
                    <GoBackButton/>
                </div>
            </div>}
            {!isexerciseGraded && <div>
                {/* <div className='role'>
                    <h1>Sinh viên đã chấm</h1>
                    <div className='quantity'>({userGraded.length}) sinh viên</div>
                </div>
                <ul className='list_informations'>
                    {userGraded.map((item, index) => (
                        <li key={index} className='graded_information'>
                            <a href={`${match.url}/answer/${item.idMember}`}>
                                <Avatar style={{ m: 1, backgroundColor: 'rgb(4, 214, 46)' }}>
                                    <PermContactCalendarOutlinedIcon />
                                </Avatar>
                            </a>
                            <div className='submit_information'>
                                <div className='name'>{classData.listMembers.find(x => x.idMember == item.idMember).nameMember}</div>
                                <div className='grade'>Điểm số: {item.point} </div>
                            </div>

                        </li>
                    ))}

                </ul> */}
                <div className='role'>
                    <h1>Sinh viên chưa chấm</h1>
                    <div className='quantity'>({userNotGraded.length}) sinh viên</div>
                </div>
                <ul className='list_informations'>
                    {userNotGraded.map((item, index) => (
                        <li key={index} className='submit_student_information'>
                            <a href={`${match.url}/answer/${item.idMember}`}>
                                <Avatar style={{ m: 1, backgroundColor: 'rgb(227, 227, 0)' }}>
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
                <div style={{margin: '0px 1050px'}}>
                    <GoBackButton/>
                </div>

            </div>}
        </div>

    )
}

export default GradeDetail
