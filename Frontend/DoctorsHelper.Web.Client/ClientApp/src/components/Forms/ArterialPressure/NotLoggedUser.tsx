import * as React from "react";
import {Typography} from 'antd';
import {Link} from "react-router-dom";

const {Title} = Typography;

export const NotLoggedUser = () => {
    return (
        <>
            <Title style={{textAlign: "center", fontSize: "1.2rem"}}>Для использования данного сервиса необходимо
                <Link to="/Login"> Войти</Link> или
                <Link to="/Registration"> Зарегистрироваться</Link>
            </Title>
        </>
    )
};

