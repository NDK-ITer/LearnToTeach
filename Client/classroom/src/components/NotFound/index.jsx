import React from 'react';
import img404 from 'images/404.png'
import { Button, Link } from '@material-ui/core';
import "./style.css";
NotFound.propTypes = {

};

function NotFound(props) {
  return (
    <div className="error">
      <img className="error__logo" src={img404} alt="error" />
      <Link href="/">
        <Button variant="contained" color="default">
          Trở Về Trang Chủ
        </Button>
      </Link>

    </div>
  );
}

export default NotFound;