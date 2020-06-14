import {AppActionWithDispatch} from "../index";
import {AccessTokenAuthClient, AuthClient, UserClient, UserGetInfoResponse} from "../../apiClient/apiClient";
import {baseUrl} from "../../apiClient/baseUrl";
import {setUserInfo} from "./actions";
import {IErrors} from "../../common/Interfaces";
import {getErrorsFromApiException} from "../../apiClient/getErrorsFromApiException";

export const getUserInfo = (): AppActionWithDispatch => async dispatch => {
    try {
        let token = localStorage.getItem("apiToken");
        if (token) {
            let authClient = new AccessTokenAuthClient(baseUrl, token as string);
            let client = new UserClient(authClient, baseUrl);
            let result = await client.getInfo();
            dispatch(setUserInfo(result));
        } else
            dispatch(setUserInfo(undefined));
    } catch (error) {
        // localStorage.removeItem("apiToken");
        //notify error.response?
        dispatch(setUserInfo(undefined));
    }
};

export const logout = (): AppActionWithDispatch => async dispatch => {
    try {
        let token = localStorage.getItem("apiToken");
        if (token) {
            let authClient = new AccessTokenAuthClient(baseUrl, token as string);
            let client = new UserClient(authClient, baseUrl);
            let result = await client.logout();
        }
    } catch (error) {
        //notify error.response?
    }
    localStorage.removeItem("apiToken");
    dispatch(setUserInfo(undefined));
};

export const logoutFromAllDevices = (): AppActionWithDispatch => async dispatch => {
    try {
        let token = localStorage.getItem("apiToken");
        if (token) {
            let authClient = new AccessTokenAuthClient(baseUrl, token as string);
            let client = new UserClient(authClient, baseUrl);
            let result = await client.logoutFromAllDevices();
        }
    } catch (error) {
        //notify error.response?
    }
    localStorage.removeItem("apiToken");
    dispatch(setUserInfo(undefined));
};

export const register = (birthDate: Date, isMen: boolean, userName: string, email: string, password: string, isRememberMy: boolean):
    AppActionWithDispatch<Promise<string[] | undefined>> => async dispatch => {

    try {
        let authClient = new AuthClient(baseUrl);
        let client = new UserClient(authClient, baseUrl);
        let result = await client.register(birthDate, isMen, userName, email, password);

        if (result.token) {
            localStorage.setItem('apiToken', result.token);
        }
        await getUserInfo()(dispatch);
        return undefined;
    } catch (error) {
        return getErrorsFromApiException(error);
    }
};

export const login = (email: string, password: string, rememberMy: boolean): AppActionWithDispatch<Promise<string[] | undefined>> => async dispatch => {
    try {
        let authClient = new AuthClient(baseUrl);
        let client = new UserClient(authClient, baseUrl);
        let result = await client.login(email, password, rememberMy);

        if (result?.token) {
            localStorage.setItem('apiToken', result.token);
        }
        await getUserInfo()(dispatch);
        return undefined;
    } catch (error) {
        return getErrorsFromApiException(error);
    }
};

export const editUserInfo = (userInfo: UserGetInfoResponse, userName: string, birthDate: Date, isMen: boolean):
    AppActionWithDispatch<Promise<string[] | undefined>> => async dispatch => {

    let token = localStorage.getItem("apiToken");
    if (!token) return undefined;
    try {
        let authClient = new AccessTokenAuthClient(baseUrl, token as string);
        let client = new UserClient(authClient, baseUrl);
        let result = await client.edit(userName, birthDate, isMen);
        dispatch(setUserInfo({...userInfo, userName: userName, birthDate: birthDate, isMen: isMen}));
        return undefined;
    } catch (error) {
        return getErrorsFromApiException(error);
    }
};
