import React, { useState, useEffect } from 'react';
import "./style.css";
import { Avatar } from '@material-ui/core';
import DescriptionOutlinedIcon from '@material-ui/icons/DescriptionOutlined';
import Switch from '@material-ui/core/Switch';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import FactCheckOutlinedIcon from '@material-ui/icons/FaceOutlined';
import formatDate from 'constants/formatdate';
import Role from 'constants/role';

const ExerciseDetail = ({ exercise, classData, userHost }) => {

    const countAnswer = exercise.listAnswer.length;
    const countUser = classData.listMembers.filter(x => x.role == Role.MEMBER).length;
    const listUserAnswer = exercise.listAnswer;
    return (
        <div>
            <div className='exercise_detail'>
                <div className='main_detail'>
                    <Avatar style={{ backgroundColor: 'grey', marginTop: '10px' }}>
                        <DescriptionOutlinedIcon />
                    </Avatar>
                    <div className='upload_detail'>
                        <h1 className='title_text'>{exercise.name}</h1>
                        <p style={{ fontSize: '14px' }}>--- {userHost.nameMember} --- Thời gian giao {formatDate(exercise.createDate)} --- </p>
                    </div>
                </div>
                <div className='content'>
                    <div className='content_text'>

                        <div className='deadline'> Thời hạn {formatDate(exercise.deadline)} </div>
                    </div>
                    <div className='content_detail'>
                        <p>{exercise.description}</p>

                    </div>
                </div>
                <div className='switch'>
                    <FormControlLabel control={<Switch defaultChecked />} label="Nhận bài nộp muộn" />
                </div>
                <div className='list_submit'>
                    <h2 className='submit_quantity'>({countAnswer}) Đã nộp/({countUser}) Sinh viên</h2>
                    <ul className='list_submited'>
                        {listUserAnswer.map((item, index) => (
                            <li key={index} className='student'>
                                <a href={`/${classData.idClassroom}/grades/${exercise.idExercise}/answer/${item.idMember}`}>
                                    <Avatar style={{ m: 1, backgroundColor: 'rgb(34, 186, 34)' }}>
                                        <FactCheckOutlinedIcon />
                                    </Avatar>
                                </a>
                                <div className='submit_information'>
                                    <div className='student_name'>{classData.listMembers.find(x => x.idMember == item.idMember).nameMember}</div>
                                    <div>Thời gian nộp {formatDate(item.dateAnswer)} </div>
                                </div>
                            </li>
                        ))}
                    </ul>
                </div>
            </div>

        </div>
    )
}

export default ExerciseDetail
