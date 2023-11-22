import {
    AppBar,
    Avatar,
    Menu,
    MenuItem,
    Toolbar,
    Typography,
} from "@material-ui/core";
import React from "react";
import { CreateClass, JoinClass } from "..";
import { useLocalContext } from "../../context";
import { useStyles } from "./style";
import { Link } from "react-router-dom";
import Button from '@material-ui/core/Button';
import "./style.css";
import Info from "../Information";

const Header = ({ children }) => {
    const classes = useStyles();

    const [anchorEl, setAnchorEl] = React.useState(null);

    const handleClick = (event) => setAnchorEl(event.currentTarget);
    const handleClose = () => setAnchorEl(null);

    const {
        setCreateClassDialog,
        setJoinClassDialog,
        loggedInUser,
        logout,
    } = useLocalContext();

    const handleCreate = () => {
        handleClose();
        setCreateClassDialog(true);
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
                            onclick={handleCreate}
                            type="submit"
                            fullWidth
                            variant="contained"
                            sx={{ margin: 1, backgroundColor: "rgb(108, 144, 46)" }}
                        //className='button'
                        >
                            Tạo lớp học
                        </Button>
                        <div>
                            <Avatar
                                onClick={handleClick}
                                src={loggedInUser?.photoURL}
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
                                <MenuItem onClick={""}>Phản hồi</MenuItem>
                                <MenuItem onClick={() => logout()}>Đăng xuất</MenuItem>
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
