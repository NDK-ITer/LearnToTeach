import React, { useEffect, useState } from 'react';
import { Avatar } from "@material-ui/core";
import Button from '@material-ui/core/Button';
import LibraryBooksOutlinedIcon from '@material-ui/icons/LibraryBooksOutlined';
import classApi from 'api/classApi';
import Role from 'constants/role';
import { useLocalContext } from 'context';
import "./style.css";
import formatDate from 'constants/formatdate';



const Document = ({ classData }) => {
    const { user } = useLocalContext();
    const [isUserHost, setisUserHost] = useState(false);
    const [isUserMember, setisUserMember] = useState(false);
    const [document, setdocument] = useState([]);

    const currentDate = new Date();
    useEffect(() => {
        const fetchData = async () => {
            const params = new URLSearchParams([['idClassroom', classData.idClassroom]]);
            const result = await classApi.getClassById(params);
            setisUserHost(result.listMembers.filter(x => x.role == Role.HOST && user.id == x.idMember).length > 0 ? true : false);
            setisUserMember(result.listMembers.filter(x => x.role == Role.MEMBER && user.id == x.idMember).length > 0 ? true : false);
            setdocument(result.listDocument);
        };
        fetchData();
    }, []);
    return (
        <div>
            {isUserHost && <div>
                <Button
                    type="submit"
                    variant="contained"
                    className='btn_create'
                    style={{ marginLeft: 400, marginTop: 20, borderRadius: 20, backgroundColor: "rgb(25, 118, 210)", color: "#fff" }}
                >
                    tải tài liệu
                </Button>
                <div className='status'>
                    <h1>danh sách tài liệu</h1>
                </div>
                <ul className='list_tasks'>
                    {document.map((item, index) => (
                        <li key={index} className='task'>
                            <a href={`/${classData.idClassroom}/document/${item.nameFile}`}>
                                <Avatar style={{ m: 1, backgroundColor: 'rgb(4, 214, 46)' }}>
                                    <LibraryBooksOutlinedIcon />
                                </Avatar>
                            </a>
                            <div className='task_name'>{item.description}</div>
                        </li>
                    ))}
                </ul>
            </div>}
            {isUserMember && <div>
                <div className='status'>
                    <h1>danh sách tài liệu</h1>
                </div>
                <ul className='list_tasks'>
                    {document.map((item, index) => (
                        <li key={index} className='task'>
                            <a href={`/${classData.idClassroom}/document/${item.nameFile}`}>
                                <Avatar style={{ m: 1, backgroundColor: 'rgb(4, 214, 46)' }}>
                                    <LibraryBooksOutlinedIcon />
                                </Avatar>
                            </a>
                            <div className='task_name'>{item.description}</div>
                        </li>
                    ))}
                </ul>
            </div>}
        </div>

    )
}

export default Document;
