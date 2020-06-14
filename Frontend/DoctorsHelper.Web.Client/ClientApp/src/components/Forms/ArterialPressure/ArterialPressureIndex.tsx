import * as React from "react";
import {Button, Space, Typography} from 'antd';
import {useSelector} from "react-redux";
import {userInfoSelector} from "../../../store/User/selectors";
import {Link} from "react-router-dom";
import {NotLoggedUser} from "./NotLoggedUser";

const {Title, Paragraph} = Typography;

export const ArterialPressureIndex = () => {

    const userInfo = useSelector(userInfoSelector);

    return (
        <>
            <Title style={{textAlign: "center"}}>Дневник артериального давления</Title>
            <Paragraph>Данный сервис позволяет людям, страдающим гипертонией и/или сахарным диабетом вести дневниковые
                записи. Это облегчает подбор гипотензивной терапии. Если быть откровенным, то без этих записей
                невозможно
                подобрать правильно дозировку и группу гипотензивного препарата.</Paragraph>
            <Paragraph>Людям страдающим сахарным диабетом - тоже необходимо вести периодически записи уровня глюкозы
                крови,
                для коррекции лечения.</Paragraph>
            <Paragraph>Имеется возможность просмотра всех записей, выборки по заданному периоду а также имеется
                возможность
                вывода на печать.</Paragraph>

            {userInfo &&
            <Space>
                <Button><Link to="/AddNote">Внесение записей </Link></Button>
                <Button><Link to="/ViewRecords">Просмотр записей </Link></Button>
            </Space>
            }
            {!userInfo && <NotLoggedUser/>}
        </>
    )
};

