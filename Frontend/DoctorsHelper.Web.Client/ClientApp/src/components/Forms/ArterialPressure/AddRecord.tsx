import * as React from "react";
import {Button, DatePicker, Form, InputNumber, Select, Typography} from 'antd';
import {useSelector} from "react-redux";
import {userInfoSelector} from "../../../store/User/selectors";
import {NotLoggedUser} from "./NotLoggedUser";
import {useState} from "react";
import moment from 'moment';
import TextArea from "antd/es/input/TextArea";
import {addRecord} from "./Actions/addRecord";

const {Option} = Select;

const {Title} = Typography;

export const AddRecord = () => {
    const userInfo = useSelector(userInfoSelector);

    const layout = {
        labelCol: {span: 8},
        wrapperCol: {span: 8},
    };
    const tailLayout = {
        wrapperCol: {offset: 8, span: 8},
    };

    const dateFormat = 'DD-MM-YYYY';


    const loginCallback = async (values: any) => {
        setIsLoading(true);
        setError([]);
        setResult(undefined);
        let errors = await addRecord(
            values.systolicBloodPressure as number,
            values.diastolicBloodPressure as number,
            values.description as string,
            values.ambulanceDrugsNumber ?? 0,
            values.pulse as number,
            values.glucoseLevel as number | undefined,
            new Date((values.date as moment.Moment).format("MM/DD/YYYY")),
            getIsMorning(values.isMorning)
            )
        ;
        if (errors)
            setError(errors);
        else
            setResult("Запись добавлена")
        setIsLoading(false);
    }

    const getIsMorning = (val: string | undefined) => {
        if (val) return val === "isMorning";
        return new Date(Date.now()).getHours() < 15
    }

    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState([] as string[]);
    const [result, setResult] = useState(undefined as string | undefined);

    const validateMessages = {
        required: '${label} обязателен для ввода!',
        types: {
            email: '${label} введен не корректно!',
        },
    };

    if (!userInfo) return <NotLoggedUser/>
    return (
        <>
            <Title style={{textAlign: "center"}}>Добавление записи в дневник артериального
                давления</Title>

            <Form
                {...layout}
                name="basic"
                initialValues={{
                    remember: true,
                    ambulanceDrugsNumber: 0,
                    date: moment(new Date(Date.now()), dateFormat),
                    isMorning: new Date(Date.now()).getHours() < 15 ? "isMorning" : "noIsMorning"
                }}
                onFinish={loginCallback}
                validateMessages={validateMessages}
            >

                <Form.Item label="Дата записи" name="date">
                    <DatePicker format={dateFormat}/>
                </Form.Item>

                <Form.Item label="Время суток" name="isMorning">
                    <Select style={{width: 145}}>
                        <Option value="isMorning">утро</Option>
                        <Option value="noIsMorning">вечер</Option>
                    </Select>
                </Form.Item>


                <Form.Item
                    label="Верхнее давление (систолическое) мм.рт.ст."
                    name="systolicBloodPressure"
                    rules={[{required: true}]}
                >
                    <InputNumber min={0} max={400}/>
                </Form.Item>

                <Form.Item
                    label="Нижнее давление (диастолическое) мм.рт.ст."
                    name="diastolicBloodPressure"
                    rules={[{required: true}]}
                >
                    <InputNumber min={0} max={200}/>
                </Form.Item>

                <Form.Item
                    label="Пульс уд/мин"
                    name="pulse"
                    rules={[{required: true}]}
                >
                    <InputNumber min={0} max={600}/>
                </Form.Item>

                <Form.Item
                    label="Сахар крови"
                    name="glucoseLevel"
                >
                    <InputNumber min={0} max={150} step={0.1} placeholder={"ммоль/л"}/>
                </Form.Item>

                <Form.Item
                    label="Количество принятых препаратов скорой помощи"
                    name="ambulanceDrugsNumber"
                >
                    <InputNumber min={0} max={100}/>
                </Form.Item>

                <Form.Item
                    label="Примечание"
                    name="description"
                >
                    <TextArea/>
                </Form.Item>


                {error.map(item =>
                    <p style={{color: "red", textAlign: "center"}} key={item}>{item}</p>
                )}

                {result ? <p style={{color: "green", textAlign: "center"}}>{result}</p> : null}
                <Form.Item {...tailLayout}>
                    <Button type="primary" htmlType="submit" loading={isLoading}>
                        Записать
                    </Button>
                </Form.Item>

            </Form>
        </>
    )
};