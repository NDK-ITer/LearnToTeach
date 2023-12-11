import React from 'react'
import "./style.css";

const NavigationBar = ({ classData }) => {
    return (
        <div className="main_navBar">
            <div className="navigation">
                <ul className="navigationBar">
                    <li className="nav_item">
                        <a className="nav_link" href={`/${classData}`}>Trang chủ</a>
                    </li>
                    <li className="nav_item">
                        <a className="nav_link" href={`/${classData}/document`}>Tài liệu</a>
                    </li>
                    <li className="nav_item">
                        <a className="nav_link" href={`/${classData}/exercises`}>Bài tập</a>
                    </li>
                    <li className="nav_item">
                        <a className="nav_link" href={`/${classData}/community`}>Mọi người</a>
                    </li>
                    <li className="nav_item">
                        <a className="nav_link" href={`/${classData}/grades`}>Điểm</a>
                    </li>
                </ul>
            </div>
        </div>
    )
}

export default NavigationBar
