import React, { useState, useEffect } from 'react';
import "./style.css";
import { Avatar, Button } from '@material-ui/core';
import PermIdentityOutlinedIcon from '@material-ui/icons/PermIdentityOutlined';
import PermContactCalendarOutlinedIcon from '@material-ui/icons/PermContactCalendarOutlined';
import classApi from 'api/classApi';
import Role from 'constants/role';
import { Redirect, Route, Switch, useRouteMatch, Link } from 'react-router-dom';
import SubmitExercise from 'components/Exercises/SubmitExercise/SubmitExercise';
import GoBackButton from 'components/GoBackButton';
import formatDate from 'constants/formatdate';
import axios from 'axios';
import userApi from 'api/userApi';

const GradeDetail = ({ exercise, classData, userHost }) => {
    const match = useRouteMatch();
    const currentDate = new Date();
    const userGraded = exercise.listAnswer.filter(x => x.point != null);
    const userNotGraded = exercise.listAnswer.filter(x => x.point == null);
    // const countUser = classData.listMembers.filter(x=>x.role==Role.MEMBER).length;
    const listUserAnswer = exercise.listAnswer;
    const isexerciseGraded = userGraded.length == listUserAnswer.length ? true : false;
    const handleExportToExcel = async () => {
        const params = new URLSearchParams([['idExercise', exercise.idExercise]]);
        axios.get('https://localhost:9000/Member/export-grade', {
            params,
            responseType: 'blob'
        })
            .then(response => {
                const url = window.URL.createObjectURL(new Blob([response.data]));
                const link = document.createElement('a');
                link.href = url;
                link.setAttribute('download', 'Answer.xlsx'); // Tên tệp khi tải về
                document.body.appendChild(link);
                link.click();
                link.parentNode.removeChild(link);
            })
            .catch(error => {
                // Xử lý lỗi
            });


    };
    const [user, setUser] = useState(null);
    useEffect(() => {
        const fetchData = async () => {
            const result = await userApi.Getall();
            setUser(result);
            console.log(result)
        };

        fetchData();
    }, []);
    console.log(user);
    return (
        <div>
            {isexerciseGraded && new Date(exercise.deadline) < currentDate && <div>
                <div>
                    <Button
                        type="submit"
                        variant="contained"
                        onClick={handleExportToExcel}
                        className='btn_create'
                        style={{ marginLeft: 400, marginTop: 20, borderRadius: 20, backgroundColor: "rgb(25, 118, 210)", color: "#fff" }}
                    >
                        thống kê
                    </Button>
                </div>
                <div className='role'>
                    <h1>Bảng điểm</h1>
                    <div className='quantity'>({userGraded.length}) sinh viên</div>
                </div>
                <ul className='list_informations'>
                    {userGraded.map((item, index) => (
                        <li key={index} className='graded_information'>
                            <Link to={`${match.url}/answer/${item.idMember}`}>
                                <Avatar style={{ m: 1, backgroundColor: 'rgb(4, 214, 46)' }}>
                                    <PermContactCalendarOutlinedIcon />
                                </Avatar>
                            </Link>
                            <div className='submit_information'>
                                <div className='name'>{ user!=null && user.find(x=>x.id==item.idMember).fullName} {classData.listMembers.filter(x=>x.idMember==item.idMember).length>0?'':'(không còn trong lớp)'}</div>
                                <div className='grade'>Điểm số: {item.point} </div>
                            </div>
                        </li>
                    ))}

                </ul>
                <div style={{ margin: '0px 1050px' }}>
                    <GoBackButton />
                </div>
            </div>}
            {isexerciseGraded && new Date(exercise.deadline) > currentDate && <div>
                <div className='role'>
                    <h1>Sinh viên đã chấm</h1>
                    <div className='quantity'>({userGraded.length}) sinh viên</div>
                </div>
                <ul className='list_informations'>
                    {userGraded.map((item, index) => (
                        <li key={index} className='graded_information'>
                            <Link to={`${match.url}/answer/${item.idMember}`}>
                                <Avatar style={{ m: 1, backgroundColor: 'rgb(4, 214, 46)' }}>
                                    <PermContactCalendarOutlinedIcon />
                                </Avatar>
                            </Link>
                            <div className='submit_information'>
                                <div className='name'>{ user!=null && user.find(x=>x.id==item.idMember).fullName} {classData.listMembers.filter(x=>x.idMember==item.idMember).length>0?'':'(không còn trong lớp)'} </div>
                                <div className='grade'>Điểm số: {item.point} </div>
                            </div>

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
                            <Link to={`${match.url}/answer/${item.idMember}`}>
                                <Avatar style={{ m: 1, backgroundColor: 'rgb(227, 227, 0)' }}>
                                    <PermIdentityOutlinedIcon />
                                </Avatar>
                            </Link>
                            <div className='submit_information'>
                                <div className='name'>{ user!=null && user.find(x=>x.id==item.idMember).fullName} {classData.listMembers.filter(x=>x.idMember==item.idMember).length>0?'':'(không còn trong lớp)'}</div>
                                <div>Thời gian nộp {formatDate(item.dateAnswer)} </div>
                            </div>

                        </li>
                    ))}

                </ul>
                <div style={{ margin: '0px 1050px' }}>
                    <GoBackButton />
                </div>

            </div>}
            {!isexerciseGraded && <div>
                <div className='role'>
                    <h1>Sinh viên đã chấm</h1>
                    <div className='quantity'>({userGraded.length}) sinh viên</div>
                </div>
                <ul className='list_informations'>
                    {userGraded.map((item, index) => (
                        <li key={index} className='graded_information'>
                            <Link to={`${match.url}/answer/${item.idMember}`}>
                                <Avatar style={{ m: 1, backgroundColor: 'rgb(4, 214, 46)' }}>
                                    <PermContactCalendarOutlinedIcon />
                                </Avatar>
                            </Link>
                            <div className='submit_information'>
                                <div className='name'>{ user!=null && user.find(x=>x.id==item.idMember).fullName} {classData.listMembers.filter(x=>x.idMember==item.idMember).length>0?'':'(không còn trong lớp)'}</div>
                                <div className='grade'>Điểm số: {item.point} </div>
                            </div>

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
                            <Link to={`${match.url}/answer/${item.idMember}`}>
                                <Avatar style={{ m: 1, backgroundColor: 'rgb(227, 227, 0)' }}>
                                    <PermIdentityOutlinedIcon />
                                </Avatar>
                            </Link>
                            <div className='submit_information'>
                                <div className='name'>{ user!=null && user.find(x=>x.id==item.idMember).fullName} {classData.listMembers.filter(x=>x.idMember==item.idMember).length>0?'':'(không còn trong lớp)'} </div>
                                <div>Thời gian nộp {formatDate(item.dateAnswer)}</div>
                            </div>

                        </li>
                    ))}

                </ul>
                <div style={{ margin: '0px 1050px' }}>
                    <GoBackButton />
                </div>

            </div>}
        </div>

    )
}

export default GradeDetail
