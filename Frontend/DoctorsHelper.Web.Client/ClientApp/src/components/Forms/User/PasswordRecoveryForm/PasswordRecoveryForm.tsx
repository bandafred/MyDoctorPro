import * as React from "react";
import {Form, Input, Button} from 'antd';
import {useCallback, useState} from "react";
import {useParams} from "react-router";
import {useDispatch} from "react-redux";
import {sendResetPasswordEmail} from "./Actions/sendResetPasswordEmail";
import {resetPassword} from "./Actions/resetPassword";

export const PasswordRecoveryForm = () => {
    const layout = {
        labelCol: {span: 8},
        wrapperCol: {span: 8},
    };
    const tailLayout = {
        wrapperCol: {offset: 8, span: 8},
    };

    let {token} = useParams();

    const [isLoading, setIsLoading] = useState(false);
    const [errors, setErrors] = useState([] as string[]);
    const [result, setResult] = useState(undefined as string | undefined);

    const sendResetPasswordEmailCallback = async (values: any) => {
        setErrors([]);
        setResult(undefined);
        setIsLoading(true);
        let errors = await sendResetPasswordEmail(values.email);
        if (errors)
            setErrors(errors);
        else
            setResult("Письмо отправлено на электронную почту");
        setIsLoading(false);
    };
    const resetPasswordCallback = async (values: any) => {
        setErrors([]);
        setResult(undefined);
        setIsLoading(true);
        let errors = await resetPassword(token ?? "", values.password);
        if (errors)
            setErrors(errors);
        else
            setResult("Пароль заменен. Войдите в систему с новым паролем");
        setIsLoading(false);
    };

    const validateMessages = {
        required: '${label} обязателен для ввода!',
        types: {
            email: '${label} введен не корректно!',
        },
    };

    if (!token)
        return (
            <>
                <p style={{textAlign: "center", fontSize: "1.5rem"}}>Восстановление пароля</p>
                <p style={{textAlign: "center", marginBottom: "50px"}}>Для восстановления пароля Вам будет отправлено
                    письмо
                    на почтовый ящик, указанный при регистрации</p>
                <Form
                    {...layout}
                    name="basic"
                    initialValues={{remember: true}}
                    onFinish={sendResetPasswordEmailCallback}
                    validateMessages={validateMessages}
                >
                    <Form.Item
                        label="Почтовый ящик"
                        name="email"
                        rules={[{type: 'email', required: true}]}
                    >
                        <Input/>
                    </Form.Item>

                    {errors.map(item =>
                        <p style={{color: "red", textAlign: "center"}} key={item}>{item}</p>
                    )}
                    {result
                        ?
                        <p style={{textAlign: "center"}}>{result}</p>
                        :
                        <Form.Item {...tailLayout}>
                            <Button type="primary" htmlType="submit" loading={isLoading}>
                                Отправить письмо для восстановления пароля
                            </Button>
                        </Form.Item>
                    }
                </Form>
            </>
        )
    else
        return (
            <>
                <p style={{textAlign: "center", fontSize: "1.5rem"}}>Восстановление пароля</p>
                <p style={{textAlign: "center", marginBottom: "50px"}}>Введите новый пароль</p>
                <Form
                    {...layout}
                    name="basic"
                    initialValues={{remember: true}}
                    onFinish={resetPasswordCallback}
                    validateMessages={validateMessages}
                >
                    <Form.Item
                        name="password"
                        label="Пароль"
                        rules={[
                            {
                                required: true,
                                message: 'Please input your password!',
                            },
                        ]}
                        hasFeedback
                    >
                        <Input.Password/>
                    </Form.Item>

                    <Form.Item
                        name="confirm"
                        label="Подтверждение пароля"
                        dependencies={['password']}
                        hasFeedback
                        rules={[
                            {
                                required: true,
                                message: 'Please confirm your password!',
                            },
                            ({getFieldValue}) => ({
                                validator(rule, value) {
                                    if (!value || getFieldValue('password') === value) {
                                        return Promise.resolve();
                                    }
                                    return Promise.reject('Пароли не совпадают!');
                                },
                            }),
                        ]}
                    >
                        <Input.Password/>
                    </Form.Item>

                    {errors.map(item =>
                        <p style={{color: "red", textAlign: "center"}} key={item}>{item}</p>
                    )}

                    {result
                        ?
                        <p style={{textAlign: "center"}}>{result}</p>
                        :
                        <Form.Item {...tailLayout}>
                            <Button type="primary" htmlType="submit" loading={isLoading}>
                                Сменить пароль
                            </Button>
                        </Form.Item>
                    }
                </Form>
            </>
        )
}