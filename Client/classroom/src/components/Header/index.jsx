import {
    AppBar,
    Avatar,
    Menu,
    MenuItem,
    Toolbar,
    Typography,
    IconButton
} from "@material-ui/core";
import React, { useState, useEffect } from "react";
import { useStyles } from "./style";
import { Link } from "react-router-dom";
import Button from '@material-ui/core/Button';
import "./style.css";
import Info from "components/Information";
import accountImg from 'images/account.png'
import { logout } from 'components/Auth/userSlice';
import { useDispatch, useSelector } from 'react-redux';
import Dialog from '@material-ui/core/Dialog';
import DialogContent from '@material-ui/core/DialogContent';
import { Close } from '@material-ui/icons';
import CreateClass from "components/classroom/create";
import JoinClass from "components/classroom/join";
import { useHistory } from 'react-router-dom';
import userApi from "api/userApi";
import StorageKeys from 'constants/storage-keys'

const MODE = {
    CREATE: 'CREATE',
    JOIN: 'JOIN',
};

const Header = ({ children }) => {
    const user = JSON.parse(localStorage.getItem(StorageKeys.USER))
    const classes = useStyles();
    const dispatch = useDispatch();
    const history = useHistory();
    const [open, setOpen] = useState(false);
    const [mode, setMode] = useState('');
    const [anchorEl, setAnchorEl] = useState(null);

    const handleClickCreateOpen = () => {
        setOpen(true);
        setMode(MODE.CREATE);
    };
    const handleClickJionOpen = () => {
        setOpen(true);
        setMode(MODE.JOIN);
    };
    const handleClose = () => {
        setOpen(false);
    };
    const handleCloseMenu = () => {
        setAnchorEl(null);
    };
    const handleUserClick = (e) => {
        setAnchorEl(e.currentTarget);
    };

    const handleLogoutClick = () => {
        const action = logout();
        dispatch(action);
        history.push('/signin')
        window.location.reload(false);
        
    };
    return (
        <div className={classes.root}>
            <AppBar className={classes.appBar} position="sticky">
                <Toolbar className={classes.toolbar}>
                    <div className={classes.headerWrapper}>
                        {children}

                        <Typography variant="h6" className={classes.title}>
                            <Link className='logo' to={`/`}>
                                HKC Classroom
                            </Link>
                        </Typography>
                    </div>
                    <div className={classes.header__wrapper__right}>
                        <Button
                            onClick={handleClickJionOpen}
                            type="submit"
                            fullWidth
                            variant="contained"
                            className={classes.button}
                        >
                            Tham gia lớp học
                        </Button>
                        <Button
                            onClick={handleClickCreateOpen}
                            type="submit"
                            fullWidth
                            variant="contained"
                            className={classes.button}                          
                        >
                            Tạo lớp học
                        </Button>
                        <div>
                            <Avatar
                                onClick={handleUserClick}
                                src={user.avatar != '/' ? user.avatar : accountImg}
                                className={classes.icon}
                            />
                            <Menu
                                id="simple-menu"
                                anchorEl={anchorEl}
                                keepMounted
                                open={Boolean(anchorEl)}
                                onClose={handleCloseMenu}
                                getContentAnchorEl={null}
                            >
                                <MenuItem> <a href="/infor">Thông tin tài khoản</a></MenuItem>
                                <MenuItem onClick={handleLogoutClick}>Đăng xuất</MenuItem>
                            </Menu>
                        </div>
                    </div>
                </Toolbar>
            </AppBar>
            <Dialog
                disableBackdropClick
                disableEscapeKeyDown
                open={open}
                onClose={handleClose}
                aria-labelledby="form-dialog-title"
            >
                <IconButton className={classes.closeButton} onClick={handleClose}>
                    <Close />
                </IconButton>

                <DialogContent>
                    {mode === MODE.CREATE && (
                        <>
                            <CreateClass closeDialog={handleClose} />
                        </>
                    )}

                    {mode === MODE.JOIN && (
                        <>

                            <JoinClass closeDialog={handleClose} />


                        </>
                    )}
                </DialogContent>
            </Dialog>
        </div>
    );
};

export default Header;
