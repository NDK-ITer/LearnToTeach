import React, { useEffect, useState } from 'react';
import { Avatar } from "@material-ui/core";
import Button from '@material-ui/core/Button';
import AssignmentOutlinedIcon from '@material-ui/icons/AssignmentOutlined';
import classApi from 'api/classApi';
import Role from 'constants/role';
import { useLocalContext } from 'context';
import "./style.css";
import UploadDocument from './UploadDocument';
import Dialog from '@material-ui/core/Dialog';
import DialogContent from '@material-ui/core/DialogContent';
import { Close, ExitToAppOutlined } from '@material-ui/icons';
import { IconButton } from '@material-ui/core';
import ConfirmationDialog from 'components/ConfirmationDialog';


const Document = ({ classData }) => {
    const { user } = useLocalContext();
    const [isUserHost, setisUserHost] = useState(false);
    const [isUserMember, setisUserMember] = useState(false);
    const [document, setdocument] = useState([]);
    const [open, setOpen] = useState(false);
    const handleClickOpen = () => {
        setOpen(true);
    };
    const handleClose = () => {
        setOpen(false);
    };
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

    const [dialogOpenDocument, setDialogOpenDocument] = useState(false);
    const [idDocument, setIdDocument] = useState(null);
    const handleIdDocument = (item) => {
        setIdDocument(item);
        setDialogOpenDocument(true);
    };
    const handleCloseDocument = () => {
        setIdDocument(null);
        setDialogOpenDocument(false);
    };
    const handledeleteDocument = async () => {
        // try {
        //     const formData = new FormData()
        //     formData.append('idClassroom', classData.idClassroom);
        //     formData.append('idMember', userHost.idMember);
        //     formData.append('IdNotify', idNotify);
        //     const result = await classApi.dele(formData);
        //     if (result.status == 1) {
        //         enqueueSnackbar(result.message, { variant: 'success' });
        //         window.location.reload();
        //     } else {
        //         enqueueSnackbar(result.message, { variant: 'error' });
        //     }

        // } catch (error) {
        //     console.log('Failed to login:', error);
        //     enqueueSnackbar(error.message, { variant: 'error' });
        // }
    }
    return (
        <div>
            {isUserHost && <div>
                <Button
                    onClick={handleClickOpen}
                    variant="contained"
                    className='btn_create'
                    style={{ marginLeft: 400, marginTop: 20, borderRadius: 20, backgroundColor: "rgb(25, 118, 210)", color: "#fff" }}
                >
                    + Tải tài liệu
                </Button>
                <div className='doc_title'>
                    <h1>Danh sách tài liệu</h1>
                </div>
                <ul className='list_docs'>
                    {document.map((item, index) => (
                        <li key={index} className='doc'>
                            <a href={item.linkFile}>
                                <Avatar style={{ m: 1, backgroundColor: 'rgb(0, 159, 212)' }}>
                                    <AssignmentOutlinedIcon />
                                </Avatar>
                            </a>
                            <div className='doc_infomation'>
                                <div className='doc_name'>{item.description}</div>
                                <div className='doc_upload'>Thời gian đăng</div>
                                {isUserHost && <Button variant="contained" onClick={() => handleIdDocument(item.nameFile)} color="secondary" startIcon={<ExitToAppOutlined />} style={{ marginBottom: '20px' }}>
                                    xóa
                                </Button>}
                            </div>
                        </li>
                    ))}
                </ul>
            </div>}
            {isUserMember && <div>
                <div className='doc_title'>
                    <h1>Danh sách tài liệu</h1>
                </div>
                <ul className='list_docs'>
                    {document.map((item, index) => (
                        <li key={index} className='doc'>
                            <a href={item.linkFile}>
                                <Avatar style={{ m: 1, backgroundColor: 'rgb(0, 159, 212)' }}>
                                    <AssignmentOutlinedIcon />
                                </Avatar>
                            </a>
                            <div className='doc_name'>{item.description}</div>
                        </li>
                    ))}
                </ul>
            </div>}

            <Dialog
                disableBackdropClick
                disableEscapeKeyDown
                open={open}
                onClose={handleClose}
                aria-labelledby="form-dialog-title"
            >
                <IconButton onClick={handleClose}>
                    <Close />
                </IconButton>

                <DialogContent>
                    <UploadDocument closeDialog={handleClose} classData={classData} />
                </DialogContent>
            </Dialog>
            <ConfirmationDialog
                open={dialogOpenDocument}
                onClose={handleCloseDocument}
                onConfirm={handledeleteDocument}
                message="Are you sure you want to delete document?"
            />
        </div>

    )
}

export default Document;
