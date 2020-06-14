import {UserGetInfoResponse} from "../../apiClient/apiClient";

export interface UserState {
    UserInfo: UserGetInfoResponse | undefined;
}

export const SET_USER_INFO = 'SET_USER_INFO';

interface SetUserInfoAction {
    type: typeof SET_USER_INFO,
    userInfo: UserGetInfoResponse | undefined
}

export type UserKnownAction = SetUserInfoAction;