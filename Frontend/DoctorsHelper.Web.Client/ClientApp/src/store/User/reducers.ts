import {SET_USER_INFO, UserKnownAction, UserState} from "./types";
import {Reducer} from "redux";

const initialState: UserState = {UserInfo: undefined};

export const UserReducer: Reducer<UserState,UserKnownAction> = (
    state = initialState,
    action: UserKnownAction
): UserState => {
    switch (action.type) {
        case SET_USER_INFO:
            return {...state, UserInfo: action.userInfo};
        default:
            return state;
    }
}