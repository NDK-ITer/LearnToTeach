import {
    AppBar,
    Avatar,
    Menu,
    MenuItem,
    Toolbar,
    Typography,
} from "@material-ui/core";
import React from "react";
import CreateClass from 'components/CreateClass';
import JoinClass from 'components/JoinClass';
import { useLocalContext } from "context";
import { useStyles } from "./style";
import { Link } from "react-router-dom";
import Button from '@material-ui/core/Button';
import "./style.css";
import Info from "components/Information";
import accountImg from 'images/account.png'
import { logout } from 'components/Auth/userSlice';
import { useDispatch, useSelector } from 'react-redux';
import { useHistory } from 'react-router-dom';

const Header = ({ children }) => {
    const classes = useStyles();
    const dispatch = useDispatch();
    const history = useHistory();
    const [anchorEl, setAnchorEl] = React.useState(null);

    const handleClick = (event) => setAnchorEl(event.currentTarget);
    const handleClose = () => setAnchorEl(null);

    const {
        setCreateClassDialog,
        setJoinClassDialog,
    } = useLocalContext();

    const handleCreate = () => {
        handleClose();
        setCreateClassDialog(true);
    };

    const handleLogoutClick = () => {
        const action = logout();
        dispatch(action);
        window.location.reload(false);
    };
    const handleJoin = () => {
        handleClose();
        setJoinClassDialog(true);
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
                            onClick={handleJoin}
                            type="submit"
                            fullWidth
                            variant="contained"
                            sx={{ margin: 1, whiteSpace: "nowrap", backgroundColor: "rgb(108, 144, 46)", pr: 5, pl: 5 }}

                        >
                            Tham gia lớp học
                        </Button>
                        <Button
                            onClick={handleCreate}
                            type="submit"
                            fullWidth
                            variant="contained"
                            sx={{ margin: 1, whiteSpace: "nowrap", backgroundColor: "rgb(108, 144, 46)", pr: 5, pl: 5 }}

                        >
                            Tạo lớp học
                        </Button>
                        <div>
                            <Avatar
                                onClick={handleClick}
                                src={accountImg}
                                className={classes.icon}
                            />
                            <Menu
                                id="simple-menu"
                                anchorEl={anchorEl}
                                keepMounted
                                open={Boolean(anchorEl)}
                                onClose={handleClose}
                            >
                                <MenuItem onClick={() => Info()}>Thông tin tài khoản</MenuItem>
                                <MenuItem >Phản hồi</MenuItem>
                                <MenuItem onClick={handleLogoutClick}>Đăng xuất</MenuItem>
                            </Menu>
                        </div>
                    </div>
                </Toolbar>
            </AppBar>
            <CreateClass />
            <JoinClass />
        </div>
    );
};

export default Header;
