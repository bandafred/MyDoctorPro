import {createSelector} from "reselect";
import {ApplicationState} from "../index";
import {UserGetInfoResponse} from "../../apiClient/apiClient";
import {UserState} from "./types";

export const userInfoSelector =
    createSelector<ApplicationState, UserState | undefined, UserGetInfoResponse | null | undefined>(
        state => state.user,
        user => user?.UserInfo);