import React from "react";
import clsx from "clsx";
import { makeStyles } from "@material-ui/core/styles";
import SwipeableDrawer from "@material-ui/core/SwipeableDrawer";
import List from "@material-ui/core/List";
import Divider from "@material-ui/core/Divider";
import ListItem from "@material-ui/core/ListItem";
import ListItemIcon from "@material-ui/core/ListItemIcon";
import ListItemText from "@material-ui/core/ListItemText";
import SearchOutlinedIcon from '@material-ui/icons/SearchOutlined';
import ClassOutlinedIcon from '@material-ui/icons/ClassOutlined';
import ArrowForwardIosOutlinedIcon from '@material-ui/icons/ArrowForwardIosOutlined';
import AssistantPhotoOutlinedIcon from '@material-ui/icons/AssistantPhotoOutlined';
import AssistantPhotoIcon from '@material-ui/icons/AssistantPhoto';
import TextField from '@material-ui/core/TextField';
import { Link } from 'react-router-dom';
import Header from "components/Header";
import { Menu } from "@material-ui/icons";
import { IconButton } from "@material-ui/core";
import { useHistory } from "react-router-dom/cjs/react-router-dom";
const useStyles = makeStyles({
  list: {
    width: 250,
  },
  fullList: {
    width: "auto",
  },
});

export default function SwipeableTemporaryDrawer({ classData }) {
  const classes = useStyles();
  const history = useHistory();
  const [state, setState] = React.useState({
    top: false,
  });
  const classDataIsHost = classData.filter(x => x.isHost == true);
  const classDataNotIsHost = classData.filter(x => x.isHost == false);

  const hanldeClass = (idClassroom) => {
    history.push(`/${idClassroom}`);
  }
  const toggleDrawer = (anchor, open) => (event) => {
    if (
      event &&
      event.type === "keydown" &&
      (event.key === "Tab" || event.key === "Shift")
    ) {
      return;
    }

    setState({ ...state, [anchor]: open });
  };
  //const han
  const list = (anchor) => (
    <div
      className={clsx(classes.list, {
        [classes.fullList]: anchor === "top" || anchor === "bottom",
      })}
      role="presentation"
      //onClick={toggleDrawer(anchor, false)}
      onKeyDown={toggleDrawer(anchor, false)}
    >
      <Divider />
      <List>

        <ListItem key="ĐÃ TẠO">
          <ListItemIcon>
            <ArrowForwardIosOutlinedIcon />
          </ListItemIcon>
          <ListItemText primary="ĐÃ TẠO" />
        </ListItem>
        {classDataIsHost.map((item, index) => (
          <Link to={`/${item.idClassroom}`}>
            <ListItem button key={index} style={{borderRadius: "25px"}} >
              <ListItemIcon>
                <AssistantPhotoIcon />
              </ListItemIcon>
              <ListItemText primary={item.name} />
            </ListItem>
          </Link>
        ))}
      </List>
      <hr style={{width: "90%"}}></hr>
      <List>
        <ListItem key="ĐÃ THAM GIA">
          <ListItemIcon>
            <ArrowForwardIosOutlinedIcon />
          </ListItemIcon>
          <ListItemText primary="ĐÃ THAM GIA" />
        </ListItem>
        {classDataNotIsHost.map((item, index) => (
          <Link to={`/${item.idClassroom}`}>
            <ListItem button key={index} style={{borderRadius: "25px"}} >
              <ListItemIcon>
                <AssistantPhotoOutlinedIcon />
              </ListItemIcon>
              <ListItemText primary={item.name} />
            </ListItem>
          </Link>
        ))}
      </List>
    </div>
  );

  return (
    <div>
      {["left"].map((anchor) => (
        <React.Fragment key={anchor}>
          <Header>
            <IconButton
              edge="start"
              className={classes.menuButton}
              color="inherit"
              aria-label="menu"
              onClick={toggleDrawer(anchor, true)}
            >
              <Menu />
            </IconButton>
          </Header>
          <SwipeableDrawer
            anchor={anchor}
            open={state[anchor]}
            onClose={toggleDrawer(anchor, false)}
            onOpen={toggleDrawer(anchor, false)}
          >
            {list(anchor)}
          </SwipeableDrawer>
        </React.Fragment>
      ))}
    </div>
  );
}
