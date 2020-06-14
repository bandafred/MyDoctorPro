import * as React from "react";
import {Button, Typography} from 'antd';
import {useSelector} from "react-redux";
import {userInfoSelector} from "../../../store/User/selectors";
import {NotLoggedUser} from "./NotLoggedUser";
import {Table} from 'antd';
import {useEffect, useState} from "react";
import {getRecords} from "./Actions/getRecords";
import {DiaryGetRecordsResponseRecord} from "../../../apiClient/apiClient";

const {Title, Paragraph} = Typography;

export const RecordsList = () => {

    const userInfo = useSelector(userInfoSelector);
    const [loading, setLoading] = useState(false)
    const [items, setItems] = useState([] as DiaryGetRecordsResponseRecord[])

    const loadData = async () => {
        setLoading(true);
        let records = await getRecords(undefined, undefined);
        if (records && records.records) setItems(records.records);
        setLoading(false);
    }

    useEffect(() => {
        loadData().then();
    }, []);

    const columns = [
        {
            title: 'Дата',
            dataIndex: 'date',
            render: (date: string) => new Date(date).toLocaleDateString(),
        },
        {
            title: 'Утро/вечер',
            dataIndex: 'isMorning',
            render: (isMorning: boolean) => isMorning ? "утро" : "вечер",
        },
        {
            title: 'Артериальное давление',
            render: (val: DiaryGetRecordsResponseRecord) => val.systolicBloodPressure + "/" + val.diastolicBloodPressure,
        },
        {
            title: 'Пульс',
            dataIndex: 'pulse',
        },
        {
            title: 'Глюкоза',
            dataIndex: 'glucoseLevel',
        },
        {
            title: 'Препараты скорой помощи',
            dataIndex: 'ambulanceDrugsNumber',
        },
        {
            title: 'Примечание',
            dataIndex: 'description',
        },
    ];

    if (!userInfo) return <NotLoggedUser/>

    return (
        <>
            <Title style={{textAlign: "center"}}>Просмотр дневниковых записей</Title>
            <Table
                columns={columns}
                dataSource={items}
                pagination={{pageSize: 30}}
                scroll={{y: 500}}
                loading={loading}
                rowKey={(record) => record.date.toString() + record.isMorning}
            />
        </>
    )
};

