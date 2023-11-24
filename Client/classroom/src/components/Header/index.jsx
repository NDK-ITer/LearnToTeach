import {
    AppBar,
    Avatar,
    Menu,
    MenuItem,
    Toolbar,
    Typography,
    IconButton
} from "@material-ui/core";
import React, { useState } from "react";
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


const MODE = {
    CREATE: 'CREATE',
    JOIN: 'JOIN',
};

const Header = ({ children }) => {
    const classes = useStyles();
    const dispatch = useDispatch();
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
        window.location.reload(false);
    };
    return (
        <div className={classes.root}>
            <AppBar className={classes.appBar} position="static">
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
                            style={{ margin: 1, whiteSpace: "nowrap", backgroundColor: "rgb(108, 144, 46)", pr: 5, pl: 5 }}

                        >
                            Tham gia lớp học
                        </Button>
                        <Button
                            onClick={handleClickCreateOpen}
                            type="submit"
                            fullWidth
                            variant="contained"
                            style={{ margin: 1, whiteSpace: "nowrap", backgroundColor: "rgb(108, 144, 46)", pr: 5, pl: 5 }}

                        >
                            Tạo lớp học
                        </Button>
                        <div>
                            <Avatar
                                onClick={handleUserClick}
                                src={accountImg}
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
                                <MenuItem onClick={() => Info()}>Thông tin tài khoản</MenuItem>
                                <MenuItem >Phản hồi</MenuItem>
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

                            <div>JOIN</div>


                        </>
                    )}
                </DialogContent>
            </Dialog>
        </div>
    );
};

export default Header;
