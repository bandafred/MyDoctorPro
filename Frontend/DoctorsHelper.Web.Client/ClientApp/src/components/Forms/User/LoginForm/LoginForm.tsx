import * as React from "react";
import {Form, Input, Button, Checkbox} from 'antd';
import styles from './LoginForm.module.css';
import {useCallback, useState} from "react";
import {Link} from "react-router-dom";
import {useDispatch} from "react-redux";
import {login} from "../../../../store/User/thunks";

export const LoginForm = () => {
    const layout = {
        labelCol: {span: 8},
        wrapperCol: {span: 8},
    };
    const tailLayout = {
        wrapperCol: {offset: 8, span: 8},
    };

    const dispatch = useDispatch()
    const loginCallback = useCallback(
        async (values: any) => {
            setError([]);
            setIsLoading(true);
            let errors = await login(values.email, values.password, values.rememberMy)(dispatch);
            setIsLoading(false);
            if(errors)
                setError(errors);
            else
                window.location.replace(document.location.href.replace(document.location.pathname, ''));
        },
        [dispatch]
    )
    
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState([] as string[]);

    const validateMessages = {
        required: '${label} обязателен для ввода!',
        types: {
            email: '${label} введен не корректно!',
        },
    };

    return (
        <>
            <p className={styles.title}>Вход в систему</p>
            <Form
                {...layout}
                name="basic"
                initialValues={{remember: true}}
                onFinish={loginCallback}
                validateMessages={validateMessages}
            >
                <Form.Item
                    label="Почтовый ящик"
                    name="email"
                    rules={[{type: 'email', required: true}]}
                >
                    <Input/>
                </Form.Item>

                <Form.Item
                    label="Пароль"
                    name="password"
                    rules={[{required: true}]}
                >
                    <Input.Password/>
                </Form.Item>

                <Form.Item {...tailLayout} name="rememberMy" valuePropName="checked">
                    <Checkbox>Запомнить меня</Checkbox>
                </Form.Item>

                {error.map(item =>
                    <p style={{color: "red", textAlign: "center"}} key={item}>{item}</p>
                )}

                <Form.Item {...tailLayout}>
                    <Button type="primary" htmlType="submit" loading={isLoading}>
                        Войти
                    </Button>
                    <Link to={"/PasswordRecovery/"}>
                        <Button type="link">
                            Забыли пароль?
                        </Button>
                    </Link>
                </Form.Item>
            </Form>
        </>
    )
}