import * as React from "react";
import styles from "./SettingsMenu.module.css";
import {Button, Row} from "antd";
import {Link} from "react-router-dom";
import {useDispatch} from "react-redux";
import {useCallback, useState} from "react";
import {logout, logoutFromAllDevices} from "../../../../store/User/thunks";

export const SettingsMenu = () => {

    const [isLoading, setIsLoading] = useState(false);
    const dispatch = useDispatch();
    const logoutCallback = useCallback(
        async () => {
            setIsLoading(true);
            await logout()(dispatch);
            setIsLoading(false);
            window.location.replace(document.location.href.replace(document.location.pathname, ''));
        },
        [dispatch]);
    
    const logoutFromAllDevicesCallback = useCallback(
        async () => {
            setIsLoading(true);
            await logoutFromAllDevices()(dispatch);
            setIsLoading(false);
            window.location.replace(document.location.href.replace(document.location.pathname, ''));
        },
        [dispatch]);

    return (
        <>
            <h1 style={{textAlign: "center", fontSize: "1.2rem"}}>Меню настроек пользователя</h1>
            <Row className={styles.row}>
                <Link to={"/EditUserInfo"}>
                    <Button type="primary" htmlType="submit" loading={isLoading}>
                        Изменить данные пользователя
                    </Button>
                </Link>
            </Row>
            <Row className={styles.row}>
                <Button type="primary" loading={isLoading} onClick={logoutCallback}>
                    Выйти из данного устройства
                </Button>
            </Row>
            <Row className={styles.row}>
                <Button type="primary" loading={isLoading} onClick={logoutFromAllDevicesCallback}>
                    Выйти из всех устройств
                </Button>
            </Row>
        </>
    );
}
