import React, { useEffect, useState } from 'react';
import { Avatar, TextField, Grid } from "@material-ui/core";
import Button from '@material-ui/core/Button';
import AssignmentOutlinedIcon from '@material-ui/icons/AssignmentOutlined';
import SearchOutlinedIcon from '@material-ui/icons/SearchOutlined';
import classApi from 'api/classApi';
import Role from 'constants/role';
import { useLocalContext } from 'context';
import "./style.css";
import UploadDocument from './UploadDocument';
import Dialog from '@material-ui/core/Dialog';
import DialogContent from '@material-ui/core/DialogContent';
import { Close, ExitToAppOutlined, VideoLabelOutlined } from '@material-ui/icons';
import { IconButton } from '@material-ui/core';
import ConfirmationDialog from 'components/ConfirmationDialog';
import formatDate from 'constants/formatdate';
import { useSnackbar } from 'notistack';
import getFileExtension from 'constants/extentionfile';
import { Link } from 'react-router-dom';

const Document = ({ classData }) => {
    const { user } = useLocalContext();
    const { enqueueSnackbar } = useSnackbar();
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
    const extesionvieo = ['mp4', 'mov', 'avi', 'wmv', 'mkv']
    useEffect(() => {
        const fetchData = async () => {
            const params = new URLSearchParams([['idClassroom', classData.idClassroom]]);
            const result = await classApi.getClassById(params);
            setisUserHost(result.listMembers.filter(x => x.role == Role.HOST && user.id == x.idMember).length > 0 ? true : false);
            setisUserMember(result.listMembers.filter(x => x.role == Role.MEMBER && user.id == x.idMember).length > 0 ? true : false);
            setdocument(result.listDocument.sort((a, b) => new Date(b.uploadDate) - new Date(a.uploadDate)));
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
        try {
            const params = new URLSearchParams([['nameFile', idDocument]]);
            const result = await classApi.deletedocument(params);
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
    }

    const [searchTerm, setSearchTerm] = useState('');
    const [searchResults, setSearchResults] = useState([]);
    const handleInputChange = (event) => {
        const term = event.target.value;
        setSearchTerm(term);
        if (term.trim() === '') {
            setSearchResults([]);
        } else {
            const filteredDoc = document.filter(document =>
                document.description.toLowerCase().includes(term.toLowerCase())
            );
            setSearchResults(filteredDoc);
        }
    };
    const displayDoc = searchTerm.trim() === '' ? document : searchResults;
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
                    <div className='search_area'>
                        <Grid container spacing={1} alignItems="flex-end">
                            <Grid item>
                                <SearchOutlinedIcon />
                            </Grid>
                            <Grid item>
                                <TextField id="input-with-icon-grid" type="text"
                                    value={searchTerm}
                                    onChange={handleInputChange}
                                    placeholder="tìm kiếm..." />
                            </Grid>
                        </Grid>

                    </div>
                </div>
                <ul className='list_docs'>
                    {displayDoc.map((item, index) => (
                        <li key={index} className='doc'>
                            <a href={item.linkFile} target='_blank'>
                                {!extesionvieo.includes(getFileExtension(item.linkFile)) &&
                                    <Avatar style={{ m: 1, backgroundColor: 'rgb(0, 159, 212)' }}>
                                        <AssignmentOutlinedIcon />
                                    </Avatar>
                                }
                                {extesionvieo.includes(getFileExtension(item.linkFile)) &&
                                    <Avatar style={{ m: 1, backgroundColor: 'rgb(0, 159, 212)' }}>
                                        <VideoLabelOutlined />
                                    </Avatar>
                                }
                            </a>
                            <div className='doc_information'>
                                <div className='doc_name'>{item.description}</div>
                                <div style={{ display: 'flex' }}>
                                    <div className='doc_upload'>Thời gian đăng: {formatDate(item.uploadDate)}</div>
                                    {isUserHost && <Button variant="contained" onClick={() => handleIdDocument(item.nameFile)} color="secondary" startIcon={<ExitToAppOutlined />}>
                                        xóa
                                    </Button>}
                                </div>
                            </div>
                        </li>
                    ))}
                </ul>
            </div>}
            {isUserMember && <div>
                <div className='doc_title'>
                    <h1>Danh sách tài liệu</h1>
                    <div className='search_area'>
                        <Grid container spacing={1} alignItems="flex-end">
                            <Grid item>
                                <SearchOutlinedIcon />
                            </Grid>
                            <Grid item>
                                <TextField id="input-with-icon-grid" type="text"
                                    value={searchTerm}
                                    onChange={handleInputChange}
                                    placeholder="tìm kiếm..." />
                            </Grid>
                        </Grid>
                    </div>
                </div>
                <ul className='list_docs'>
                    {displayDoc.map((item, index) => (
                        <li key={index} className='doc'>
                            <a href={item.linkFile} target='blank'>
                                <Avatar style={{ m: 1, backgroundColor: 'rgb(0, 159, 212)' }}>
                                    <AssignmentOutlinedIcon />
                                </Avatar>
                            </a>
                            <div className='doc_information'>
                                <div className='doc_name1'>{item.description}</div>
                                <div className='doc_upload1'>Thời gian đăng: {formatDate(item.uploadDate)}</div>
                            </div>
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
                message="Bạn có chắc muốn xóa tài liệu này?"
            />
        </div>

    )
}

export default Document;
