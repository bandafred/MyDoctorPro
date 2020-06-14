import {Button, Checkbox, DatePicker, Form, Input, Select} from "antd";
import * as React from "react";
import {useCallback, useState} from "react";
import {useDispatch, useSelector} from "react-redux";
import {editUserInfo, register} from "../../../../store/User/thunks";
import {userInfoSelector} from "../../../../store/User/selectors";
import {UserGetInfoResponse} from "../../../../apiClient/apiClient";
import moment from "moment";

const {Option} = Select;

export const EditUserInfo = () => {

    const layout = {
        labelCol: {span: 8},
        wrapperCol: {span: 8},
    };
    const tailLayout = {
        wrapperCol: {offset: 8, span: 8},
    };

    const userInfo = useSelector(userInfoSelector);
    const [isLoading, setIsLoading] = useState(false);
    const [errors, setErrors] = useState([] as string[]);
    const [result, setResult] = useState(undefined as string | undefined);

    const dispatch = useDispatch();

    const editUserInfoCallback = useCallback(
        async (values: any) => {
            setErrors([]);
            setResult(undefined);
            setIsLoading(true);
            let action = await editUserInfo(userInfo ?? {} as UserGetInfoResponse, values.userName, values.birthDate, values.sex == "man");
            
            let errors = await action(dispatch);
            if (errors) setErrors(errors);
            else setResult("Удачное изменение данных.");
            setIsLoading(false);
        },
        [dispatch]);

    const validateMessages = {
        required: '${label} обязателен для ввода!',
        types: {
            email: '${label} введен не корректно!',
        },
    };
    
    if(!userInfo) return (<></>);
    return (<>
        <p style={{textAlign: "center", fontSize: "1.5rem"}}>Изменение данных пользователя</p>
        <Form
            {...layout}
            name="basic"
            initialValues={{userName: userInfo?.userName, birthDate: moment(userInfo?.birthDate), sex: userInfo?.isMen === true ? "man" : "woman"}}
            onFinish={editUserInfoCallback}
            validateMessages={validateMessages}            
        >
            <Form.Item
                label="ФИО"
                name="userName"
            >
                <Input/>
            </Form.Item>

            <Form.Item label="Пол" name="sex" rules={[{required: true}]}>
                <Select>
                    <Option value="woman">Женский</Option>
                    <Option value="man">Мужской</Option>
                </Select>
            </Form.Item>

            <Form.Item label="Дата рождения" name="birthDate" rules={[{required: true}]}>
                <DatePicker/>
            </Form.Item>

            {errors.map(item =>
                <p style={{color: "red", textAlign: "center"}} key={item}>{item}</p>
            )}
            {result
                ?
                <p style={{textAlign: "center"}}>{result}</p>
                : null}
            <Form.Item {...tailLayout}>
                <Button type="primary" htmlType="submit" loading={isLoading}>
                    Изменить данные
                </Button>
            </Form.Item>

        </Form>
    </>)
} 