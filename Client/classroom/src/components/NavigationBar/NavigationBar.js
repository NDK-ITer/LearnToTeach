import React from 'react'
import "./style.css";
import { Link } from 'react-router-dom';
const NavigationBar = ({ classData }) => {
    return (
        <div className="main_navBar">
            <div className="navigation">
                <ul className="navigationBar">
                    <li className="nav_item">
                        <Link className="nav_link" to={`/${classData}`}>Trang chủ</Link>
                    </li>
                    <li className="nav_item">
                        <Link className="nav_link" to={`/${classData}/document`}>Tài liệu</Link>
                    </li>
                    <li className="nav_item">
                        <Link className="nav_link" to={`/${classData}/exercises`}>Bài tập</Link>
                    </li>
                    <li className="nav_item">
                        <Link className="nav_link" to={`/${classData}/community`}>Mọi người</Link>
                    </li>
                    <li className="nav_item">
                        <Link className="nav_link" to={`/${classData}/grades`}>Điểm</Link>
                    </li>
                </ul>
            </div>
        </div>
    )
}

export default NavigationBar
