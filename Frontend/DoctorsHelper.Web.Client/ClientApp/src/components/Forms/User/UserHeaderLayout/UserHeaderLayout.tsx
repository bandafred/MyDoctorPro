import {Link} from "react-router-dom";
import styles from "./UserHeaderLayout.module.css";
import {Spin, Tooltip} from "antd";
import * as React from "react";
import {LogoutOutlined, SettingOutlined} from '@ant-design/icons';
import {useDispatch, useSelector} from 'react-redux'
import {useCallback, useState} from "react";
import {userInfoSelector} from "../../../../store/User/selectors";
import {logout} from "../../../../store/User/thunks";

export const UserHeaderLayout = () => {
    const [isLoading, setIsLoading] = useState(false);
    const userInfo = useSelector(userInfoSelector);

    const dispatch = useDispatch();    
    const logoutCallback = useCallback(
        async () => {
            setIsLoading(true);
            await logout()(dispatch);
            setIsLoading(false);
        },
        [dispatch]);

    if (isLoading)
        return (<Spin/>);

    if (userInfo)
        return (
            <>
                <span style={{color: "#fff"}}>{userInfo.userName}</span>
                <Link to={"/"} className={styles.link} onClick={logoutCallback}>
                    <Tooltip title={"Выйти"}>
                        <LogoutOutlined style={{fontSize: "1.2rem", margin: "5px"}}/>
                    </Tooltip>
                </Link>
                <Link to={"/SettingsMenu"} className={styles.link}>
                    <Tooltip title={"Настройки пользователя"}>
                        <SettingOutlined style={{fontSize: "1.2rem", margin: "5px"}}/>
                    </Tooltip>
                </Link>
            </>
        )
    else
        return (
            <>
                <Link to={"/Login"} className={styles.link}>
                    Вход
                </Link>
                <span style={{color: "#fff"}}> / </span>
                <Link to={"/Registration"} className={styles.link}>
                    Регистрация
                </Link>
            </>
        )
}
